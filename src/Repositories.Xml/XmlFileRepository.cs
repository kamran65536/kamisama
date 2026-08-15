using KamiSama.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace KamiSama.Repositories.Xml
{
	/// <summary>
	/// Provides read-oriented access to one XML entity per file in a directory.
	/// </summary>
	/// <typeparam name="TEntity">The entity type deserialized from each XML file.</typeparam>
	/// <remarks>
	/// In version 10.0.0, the default array serializer is incompatible with per-entity reads, so pass an <see cref="XmlSerializer"/> for <typeparamref name="TEntity"/>.
	/// Mutation is not durable: the save path writes serialized entities to the directory path instead of mapped file paths, does not use the supplied serializer, and never deletes stale files. Add, update, and delete must not be used for XML persistence.
	/// Load and save failures are reported through events and otherwise suppressed. Duplicate semantics follow the configured comparer, and synchronization is limited to one repository instance.
	/// </remarks>
	/// <param name="filePath">The directory containing one XML file per entity.</param>
	/// <param name="fileNameFunc">A function that returns the exact file name expected for a deserialized entity.</param>
	/// <param name="serializer">A serializer for one <typeparamref name="TEntity"/>. The default serializer targets an array and cannot read the per-entity files.</param>
	/// <param name="equalityComparer">The comparer used to collapse equal entities loaded from different files, or <see langword="null"/> to use the default comparer.</param>
	public class XmlFileRepository<TEntity>(string filePath,
						   Func<TEntity, string> fileNameFunc,
						   XmlSerializer? serializer = null,
						   IEqualityComparer<TEntity>? equalityComparer = null) : IQueryableRepository<TEntity>, IAsyncQueryableRepository<TEntity>
	{
		/// <summary>
		/// empty collection for queries
		/// </summary>
		private static readonly IQueryable<TEntity> Empty = (Array.Empty<TEntity>()).AsQueryable();
		/// <summary>
		/// Occurs when directory enumeration, XML deserialization, or file-name validation fails.
		/// </summary>
		/// <remarks>One failing file prevents the complete directory load. The load method then returns <see langword="false"/> unless an event handler throws.</remarks>
		public event Action<XmlFileRepository<TEntity>, Exception>? LoadFailed;
		/// <summary>
		/// Occurs when the broken mutation path fails to write serialized entities to the directory path.
		/// </summary>
		/// <remarks>The in-memory mutation is not rolled back, and the repository method otherwise completes normally unless an event handler throws.</remarks>
		public event Action<XmlFileRepository<TEntity>, Exception>? SaveFailed;
		/// <summary>
		/// XML directory path
		/// </summary>
		private readonly string directoryPath = filePath;
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
		/// Serializer used for per-entity reads; the default array serializer is incompatible with that operation.
		/// </summary>
		private readonly XmlSerializer serializer = serializer ?? new XmlSerializer(typeof(TEntity[]));
		/// <summary>
		/// a function to determine file names
		/// </summary>
		private readonly Func<TEntity, string> fileNameFunc = fileNameFunc;

		/// <summary>
		/// Loads all <c>*.xml</c> files from the directory unless entities are already cached.
		/// </summary>
		/// <remarks>
		/// Each file is deserialized as one entity and must have exactly the name returned by the mapping function. Equal entities from separate files are silently collapsed by the set.
		/// The version 10.0.0 default serializer targets <typeparamref name="TEntity"/> arrays and therefore fails for these per-entity reads.
		/// </remarks>
		/// <param name="forceReload">Whether to discard the cached set and enumerate the directory again.</param>
		/// <param name="cancellationToken">A token that can cancel file reads or the semaphore wait.</param>
		/// <returns><see langword="true"/> when every file loads and validates; otherwise <see langword="false"/> after raising <see cref="LoadFailed"/>.</returns>
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
				var dir = new DirectoryInfo(directoryPath);

				var all = (equalityComparer == null) ? [] : new HashSet<TEntity>(equalityComparer);

				foreach (var file in dir.GetFiles("*.xml"))
				{
					var entity = (await File.ReadAllTextAsync(file.FullName, cancellationToken)).DeserializeFromXml<TEntity>(serializer);

					if (fileNameFunc(entity!) != file.Name)
						throw new InvalidOperationException($"entity name {fileNameFunc(entity!)} does not match file name: {file.Name}");

					all.Add(entity!);
				}

				entities = all;

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
		/// Mutates the cache and attempts the version 10.0.0 save path, which writes to the directory path rather than mapped files.
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

				foreach (var entity in entities!)
				{
					await File.WriteAllTextAsync(directoryPath, entity!.SerializeToXml(), cancellationToken);
				}
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
		/// <summary>Adds an entity to memory and invokes the broken XML save path.</summary>
		/// <remarks>In version 10.0.0 this cannot durably add an XML entity file. A write failure raises <see cref="SaveFailed"/> after the cache has changed.</remarks>
		/// <param name="item">The entity to add in memory.</param>
		/// <param name="cancellationToken">A token that can cancel loading, the semaphore wait, or the attempted write.</param>
		/// <returns>A task that completes after the failed or ineffective persistence attempt.</returns>
		public Task AddAsync(TEntity item, CancellationToken cancellationToken)
			=> ModifyAndSaveToFileAsync(() => entities!.Add(item), cancellationToken);
		/// <summary>Removes an equal entity from memory and invokes the broken XML save path.</summary>
		/// <remarks>In version 10.0.0 this does not delete the entity's XML file, including when deleting the final cached entity.</remarks>
		/// <param name="item">The entity used for equality-based removal.</param>
		/// <param name="cancellationToken">A token that can cancel loading, the semaphore wait, or the attempted write.</param>
		/// <returns>A task that completes after the failed or ineffective persistence attempt.</returns>
		public Task DeleteAsync(TEntity item, CancellationToken cancellationToken)
			=> ModifyAndSaveToFileAsync(() => entities!.Remove(item), cancellationToken);
		/// <summary>Ignores the supplied entity and invokes the broken XML save path.</summary>
		/// <remarks>In version 10.0.0 this does not durably update an XML entity file and does not use the supplied serializer for output.</remarks>
		/// <param name="item">The entity value, which is ignored.</param>
		/// <param name="cancellationToken">A token that can cancel loading, the semaphore wait, or the attempted write.</param>
		/// <returns>A task that completes after the failed or ineffective persistence attempt.</returns>
		public Task UpdateAsync(TEntity? item, CancellationToken cancellationToken)
			=> ModifyAndSaveToFileAsync(() => { }, cancellationToken);
		/// <summary>Loads on demand and returns the first cached entity matching the predicate.</summary>
		/// <param name="predicate">The predicate to compile and apply, or <see langword="null"/> to return the default value.</param>
		/// <param name="cancellationToken">A token that can cancel loading.</param>
		/// <returns>The first matching entity, or the default value when loading fails, the predicate is <see langword="null"/>, or no entity matches.</returns>
		public async Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>>? predicate, CancellationToken cancellationToken)
		{
			if (!await TryLoadFileAsync(forceReload: false, cancellationToken))
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
			if (!await TryLoadFileAsync(false, cancellationToken))
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
		/// <summary>Synchronously invokes the broken add path; it does not durably create an XML entity file in version 10.0.0.</summary>
		/// <param name="item">The entity to add in memory.</param>
		public void Add(TEntity item) => AddAsync(item, CancellationToken.None).Wait();
		/// <summary>Synchronously invokes the broken update path; it does not durably update XML in version 10.0.0.</summary>
		/// <param name="item">The entity value, which is ignored.</param>
		public void Update(TEntity item) => UpdateAsync(item, CancellationToken.None).Wait();
		/// <summary>Synchronously invokes the broken delete path; it does not remove the entity's XML file in version 10.0.0.</summary>
		/// <param name="item">The entity used for equality-based removal.</param>
		public void Delete(TEntity item) => DeleteAsync(item, CancellationToken.None).Wait();
		/// <summary>Synchronously blocks on the load-on-demand lookup.</summary>
		/// <param name="predicate">The predicate to apply, or <see langword="null"/> to return the default value.</param>
		/// <returns>The first matching entity, or the default value when loading fails or no predicate matches.</returns>
		public TEntity? Find(Expression<Func<TEntity, bool>>? predicate = null) => FindAsync(predicate, CancellationToken.None).Result;
	}
}
