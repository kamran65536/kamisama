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
	/// Json File Repository
	/// </summary>
	/// <typeparam name="TEntity"></typeparam>
	/// <remarks>
	/// constructor
	/// </remarks>
	/// <param name="filePath">path to json file as repository</param>
	/// <param name="equalityComparer"></param>
	public class JsonRepository<TEntity>(string filePath,
					IEqualityComparer<TEntity>? equalityComparer = null) : IQueryableRepository<TEntity>, IAsyncQueryableRepository<TEntity>
	{
		/// <summary>
		/// empty collection for queries
		/// </summary>
		private static readonly IQueryable<TEntity> Empty = (Array.Empty<TEntity>()).AsQueryable();
		/// <summary>
		/// raised when loading items from file fails
		/// </summary>
		public event Action<JsonRepository<TEntity>, Exception>? LoadFailed;
		/// <summary>
		/// raised when saving items to file fails
		/// </summary>
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
		/// loads the json file if not loaded already
		/// </summary>
		/// <returns></returns>
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
					entities = new HashSet<TEntity>(all);
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
		/// <inheritdoc />
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
		/// <inheritdoc />
		public Task AddAsync(TEntity item, CancellationToken cancellationToken)
			=> ModifyAndSaveToFileAsync(() => entities?.Add(item), cancellationToken);
		/// <inheritdoc />
		public Task DeleteAsync(TEntity item, CancellationToken cancellationToken)
			=> ModifyAndSaveToFileAsync(() => entities?.Remove(item), cancellationToken);
		/// <inheritdoc />
		public Task UpdateAsync(TEntity item, CancellationToken cancellationToken)
			=> ModifyAndSaveToFileAsync(() => { }, cancellationToken);
		/// <inheritdoc />
		public async Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>>? predicate, CancellationToken cancellationToken)
		{
			if (!await TryLoadFileAsync(false, cancellationToken))
				return default;
			else if (predicate == null)
				return default;
			else
				return entities!.FirstOrDefault(predicate.Compile());
		}
		/// <inheritdoc />
		public async Task<IQueryable<TEntity>> WhereAsync(Expression<Func<TEntity, bool>>? predicate, CancellationToken cancellationToken)
		{
			if (!await TryLoadFileAsync(forceReload:false, cancellationToken))
				return Empty;
			else if (predicate == null)
				return entities!.AsQueryable();
			else
				return entities!.Where(predicate.Compile()).AsQueryable();
		}
		/// <inheritdoc />
		public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>>? predicate = null)
			=> WhereAsync(predicate, CancellationToken.None).Result;
		/// <summary>
		/// Adds a new item in the repository; Modify to json repository is not recommended for performance issues
		/// </summary>
		/// <param name="item"></param>
		public void Add(TEntity item) => AddAsync(item, CancellationToken.None).Wait();
		/// <summary>
		/// Update method, updates the json file; Modify to json repository is not recommended for performance issues
		/// </summary>
		/// <param name="item"></param>
		public void Update(TEntity item) => UpdateAsync(item, CancellationToken.None).Wait();
		/// <summary>
		/// Deletes an item from repository; Modify to json repository is not recommended for performance issues
		/// </summary>
		/// <param name="item"></param>
		public void Delete(TEntity item) => DeleteAsync(item, CancellationToken.None).Wait();
		/// <summary>
		/// Finds an single item in the repository
		/// </summary>
		/// <param name="predicate">the predicate to search, if null it returns null</param>
		/// <returns></returns>
		public TEntity? Find(Expression<Func<TEntity, bool>>? predicate = null) => FindAsync(predicate, CancellationToken.None).Result;
	}
}