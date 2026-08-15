using KamiSama.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace KamiSama.Repositories.Json
{
	/// <summary>
	/// Lazily loads a JSON array into an in-memory set and rewrites the complete file after mutations.
	/// </summary>
	/// <typeparam name="TEntity">The entity type serialized in the JSON array.</typeparam>
	/// <remarks>
	/// The file must already exist and contain valid JSON before queries or mutations can succeed. Duplicate semantics follow the configured comparer.
	/// Writes are non-atomic, update only rewrites the current set, and load or save failures are reported through events instead of being returned or rethrown.
	/// Synchronization is per instance and protects loading and mutation only; returned queries are live and multiple instances or processes can overwrite each other's changes.
	/// </remarks>
	/// <param name="filePath">The path to an existing JSON file containing an array of entities.</param>
	/// <param name="equalityComparer">The comparer that controls duplicate and removal semantics, or <see langword="null"/> to use the default comparer.</param>
	public class JsonRepository<TEntity>(string filePath,
					IEqualityComparer<TEntity>? equalityComparer = null) : IQueryableRepository<TEntity>, IAsyncQueryableRepository<TEntity>
	{
		/// <summary>
		/// empty collection for queries
		/// </summary>
		private static readonly IQueryable<TEntity> Empty = (Array.Empty<TEntity>()).AsQueryable();
		/// <summary>
		/// Occurs when reading or deserializing the JSON file fails.
		/// </summary>
		/// <remarks>After this event is raised, the load method returns <see langword="false"/> unless an event handler throws.</remarks>
		public event Action<JsonRepository<TEntity>, Exception>? LoadFailed;
		/// <summary>
		/// Occurs when mutating the in-memory set or writing the JSON file fails.
		/// </summary>
		/// <remarks>The in-memory mutation is not rolled back. The repository method otherwise completes normally unless an event handler throws.</remarks>
		public event Action<JsonRepository<TEntity>, Exception>? SaveFailed;
		/// <summary>
		/// json file path
		/// </summary>
		private readonly string filePath = filePath;
		/// <summary>
		/// internal entities collection
		/// </summary>
		internal HashSet<TEntity>? entities;
		/// <summary>
		/// semaphore for concurrent scenarios
		/// </summary>
		private readonly SemaphoreSlim semaphore = new(1);
		/// <summary>
		/// equality comparer for hash set
		/// </summary>
		private readonly IEqualityComparer<TEntity>? equalityComparer = equalityComparer;

		/// <summary>
		/// Loads and deserializes the JSON array unless it is already cached, optionally discarding the cache first.
		/// </summary>
		/// <remarks><paramref name="forceReload"/> is applied before the per-instance semaphore is acquired and does not coordinate with other repository instances or processes.</remarks>
		/// <param name="forceReload">Whether to discard the cached set and read the file again.</param>
		/// <param name="cancellationToken">A token that can cancel file access or the semaphore wait.</param>
		/// <returns><see langword="true"/> when entities are available; otherwise <see langword="false"/> after raising <see cref="LoadFailed"/>.</returns>
		public async Task<bool> TryLoadFileAsync(bool forceReload, CancellationToken cancellationToken)
		{
			if (forceReload)
				entities = null;

			if (entities != null)
				return true;
			await semaphore.WaitAsync(cancellationToken);
			if (entities != null)
			{
				semaphore.Release();
				return true;
			}

			try
			{
				var all = (await File.ReadAllTextAsync(filePath, cancellationToken)).DeserializeFromJson<TEntity[]>() ?? [];

				if (equalityComparer == null)
					entities = [.. all];
				else
					entities = new HashSet<TEntity>(all, equalityComparer);

				return true;
			}
			catch (Exception exp)
			{
				LoadFailed?.Invoke(this, exp);

				return false;
			}
			finally
			{
				semaphore.Release();
			}
		}
		/// <summary>
		/// modifies (add,delete, update) the collection and saves the result into the file
		/// </summary>
		/// <param name="action"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		private async Task ModifyAndSaveToFileAsync(Action action, CancellationToken cancellationToken)
		{
			if (!await TryLoadFileAsync(false, cancellationToken))
				return;

			await semaphore.WaitAsync(cancellationToken);
			try
			{
				action();

				await File.WriteAllTextAsync(filePath, entities?.ToArray().SerializeToJson(), cancellationToken);
			}
			catch (Exception exp)
			{
				SaveFailed?.Invoke(this, exp);
			}
			finally
			{
				semaphore.Release();
			}
		}
		/// <summary>Clears the cached entities. The instance must not be used after disposal.</summary>
		void IDisposable.Dispose()
		{
			try
			{
				entities?.Clear();
			}
			catch
			{
			}
			GC.SuppressFinalize(this);
		}
		/// <summary>Adds an entity to the cached set and then attempts to rewrite the complete JSON file.</summary>
		/// <remarks>An equal duplicate is ignored by the set but the file is still rewritten. A save failure leaves the changed cache in memory.</remarks>
		/// <param name="item">The entity to add.</param>
		/// <param name="cancellationToken">A token that can cancel loading, the semaphore wait, or file writing.</param>
		/// <returns>A task that completes after the write attempt; inspect <see cref="LoadFailed"/> and <see cref="SaveFailed"/> for suppressed failures.</returns>
		public Task AddAsync(TEntity item, CancellationToken cancellationToken)
			=> ModifyAndSaveToFileAsync(() => entities?.Add(item), cancellationToken);
		/// <summary>Removes an equal entity from the cached set and then attempts to rewrite the complete JSON file.</summary>
		/// <remarks>A missing entity is ignored but the file is still rewritten. A save failure does not restore a removed entity.</remarks>
		/// <param name="item">The entity used for equality-based removal.</param>
		/// <param name="cancellationToken">A token that can cancel loading, the semaphore wait, or file writing.</param>
		/// <returns>A task that completes after the write attempt; inspect <see cref="LoadFailed"/> and <see cref="SaveFailed"/> for suppressed failures.</returns>
		public Task DeleteAsync(TEntity item, CancellationToken cancellationToken)
			=> ModifyAndSaveToFileAsync(() => entities?.Remove(item), cancellationToken);
		/// <summary>Ignores the supplied entity and attempts to rewrite the current cached set to the JSON file.</summary>
		/// <remarks>This method does not replace or merge an entity. It only persists prior mutations made to an object already held by the set.</remarks>
		/// <param name="item">The entity value, which is ignored.</param>
		/// <param name="cancellationToken">A token that can cancel loading, the semaphore wait, or file writing.</param>
		/// <returns>A task that completes after the write attempt; inspect <see cref="LoadFailed"/> and <see cref="SaveFailed"/> for suppressed failures.</returns>
		public Task UpdateAsync(TEntity item, CancellationToken cancellationToken)
			=> ModifyAndSaveToFileAsync(() => { }, cancellationToken);
		/// <summary>Loads on demand and returns the first cached entity matching the predicate.</summary>
		/// <param name="predicate">The predicate to compile and apply, or <see langword="null"/> to return the default value.</param>
		/// <param name="cancellationToken">A token that can cancel loading.</param>
		/// <returns>The first matching entity, or the default value when loading fails, the predicate is <see langword="null"/>, or no entity matches.</returns>
		public async Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>>? predicate, CancellationToken cancellationToken)
		{
			if (!await TryLoadFileAsync(false, cancellationToken))
				return default;
			else if (predicate == null)
				return default;
			else
				return entities!.FirstOrDefault(predicate.Compile());
		}
		/// <summary>Loads on demand and returns a live query over all cached entities or those matching the predicate.</summary>
		/// <remarks>The returned query is not a snapshot and is not protected from later mutations.</remarks>
		/// <param name="predicate">The predicate to compile and apply, or <see langword="null"/> to return all cached entities.</param>
		/// <param name="cancellationToken">A token that can cancel loading.</param>
		/// <returns>A live query, or an empty query when loading fails.</returns>
		public async Task<IQueryable<TEntity>> WhereAsync(Expression<Func<TEntity, bool>>? predicate, CancellationToken cancellationToken)
		{
			if (!await TryLoadFileAsync(forceReload:false, cancellationToken))
				return Empty;
			else if (predicate == null)
				return entities!.AsQueryable();
			else
				return entities!.Where(predicate.Compile()).AsQueryable();
		}
		/// <summary>Synchronously blocks on <see cref="WhereAsync"/> and returns its live query.</summary>
		/// <param name="predicate">The predicate to apply, or <see langword="null"/> to return all cached entities.</param>
		/// <returns>A live query, or an empty query when loading fails.</returns>
		public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>>? predicate = null)
			=> WhereAsync(predicate, CancellationToken.None).Result;
		/// <summary>
		/// Synchronizes the asynchronous add operation and rewrites the complete JSON file.
		/// </summary>
		/// <param name="item">The entity to add.</param>
		public void Add(TEntity item) => AddAsync(item, CancellationToken.None).Wait();
		/// <summary>
		/// Synchronizes the asynchronous update operation, which ignores the supplied entity and rewrites the current set.
		/// </summary>
		/// <param name="item">The entity value, which is ignored.</param>
		public void Update(TEntity item) => UpdateAsync(item, CancellationToken.None).Wait();
		/// <summary>
		/// Synchronizes the asynchronous delete operation and rewrites the complete JSON file.
		/// </summary>
		/// <param name="item">The entity used for equality-based removal.</param>
		public void Delete(TEntity item) => DeleteAsync(item, CancellationToken.None).Wait();
		/// <summary>
		/// Synchronously blocks on the load-on-demand lookup.
		/// </summary>
		/// <param name="predicate">The predicate to apply, or <see langword="null"/> to return the default value.</param>
		/// <returns>The first matching entity, or the default value when loading fails or no predicate matches.</returns>
		public TEntity? Find(Expression<Func<TEntity, bool>>? predicate = null) => FindAsync(predicate, CancellationToken.None).Result;
	}
}
