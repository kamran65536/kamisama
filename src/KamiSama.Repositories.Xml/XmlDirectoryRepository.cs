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
	/// Json File Repository
	/// </summary>
	/// <typeparam name="TEntity"></typeparam>
	public class XmlDirectoryRepository<TEntity> : IQueryableRepository<TEntity>, IAsyncQueryableRepository<TEntity>
	{
		/// <summary>
		/// empty collection for queries
		/// </summary>
		private static readonly IQueryable<TEntity> Empty = (new TEntity[0]).AsQueryable();
		/// <summary>
		/// raised when loading items from file fails
		/// </summary>
		public event Action<XmlDirectoryRepository<TEntity>, Exception> LoadFailed;
		/// <summary>
		/// raised when saving items to file fails
		/// </summary>
		public event Action<XmlDirectoryRepository<TEntity>, Exception> SaveFailed;
		/// <summary>
		/// xml directory path
		/// </summary>
		private readonly string directoryPath;
		/// <summary>
		/// internal entities collection
		/// </summary>
		internal HashSet<TEntity> entities;
		/// <summary>
		/// semaphore for concurrent scenarios
		/// </summary>
		private readonly SemaphoreSlim semaphore;
		/// <summary>
		/// equality comparer for hashset
		/// </summary>
		private readonly IEqualityComparer<TEntity> equalityComparer;
		/// <summary>
		/// 
		/// </summary>
		private readonly XmlSerializer serializer;
		/// <summary>
		/// a function to determine file names
		/// </summary>
		private readonly Func<TEntity, string> fileNameFunc;

		/// <summary>
		/// constructor
		/// </summary>
		/// <param name="filePath">path to json file as repository</param>
		/// <param name="equalityComparer"></param>
		/// <param name="serializer"></param>
		/// <param name="fileNameFunc"></param>
		public XmlDirectoryRepository(string filePath, Func<TEntity, string> fileNameFunc, XmlSerializer serializer = null, IEqualityComparer<TEntity> equalityComparer = null)
		{
			this.directoryPath = filePath;
			this.equalityComparer = equalityComparer;
			this.semaphore = new SemaphoreSlim(1);
			this.serializer = serializer ?? new XmlSerializer(typeof(TEntity[]));
			this.fileNameFunc = fileNameFunc;
		}
		/// <summary>
		/// loads the json file if not loaded already
		/// </summary>
		/// <returns></returns>
		public async Task<bool> TryLoadFileAsync(bool forceReload = false)
		{
			if (forceReload)
				entities = null;

			if (entities != null)
				return true;
			await semaphore.WaitAsync();
			if (entities != null)
			{
				semaphore.Release();
				return true;
			}

			try
			{
				var dir = new DirectoryInfo(directoryPath);
			
				var all = (equalityComparer == null) ? new HashSet<TEntity>() : new HashSet<TEntity>(equalityComparer);
				
				foreach (var file in dir.GetFiles("*.xml"))
				{
					var entity = (await File.ReadAllTextAsync(file.FullName)).DeserializeFromXml<TEntity>();

					if (fileNameFunc(entity) != file.Name)
						throw new InvalidOperationException($"entity name {fileNameFunc(entity)} does not match file name: {file.Name}");

					all.Add(entity);
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
		/// modifies (add,delete, update) the collection and saves the result into the file
		/// </summary>
		/// <param name="action"></param>
		/// <returns></returns>
		private async Task ModifyAndSaveToFileAsync(Action action)
		{
			if (!await TryLoadFileAsync())
				return;

			await semaphore.WaitAsync();
			try
			{
				action();

				foreach (var entity in entities)
				{
					await File.WriteAllTextAsync(directoryPath, entity.SerializeToXml());
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
		/// <inheritdoc />
		public void Dispose()
		{
			try
			{
				entities?.Clear();
			}
			catch
			{
			}
		}
		/// <summary>
		/// Adds a new item in the repository; Modify to json repository is not recommanded for performance issues
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public Task AddAsync(TEntity item)
			=> ModifyAndSaveToFileAsync(() => entities.Add(item));
		/// <summary>
		/// Deletes an item from repository; Modify to json repository is not recommanded for performance issues
		/// </summary>
		/// <param name="item"></param>
		public Task DeleteAsync(TEntity item)
			=> ModifyAndSaveToFileAsync(() => entities.Remove(item));
		/// <summary>
		/// Update method, does nothing; Modify to json repository is not recommanded for performance issues
		/// </summary>
		/// <param name="item"></param>
		public Task UpdateAsync(TEntity item)
			=> ModifyAndSaveToFileAsync(() => { });
		/// <summary>
		/// Finds an single item in the repository
		/// </summary>
		/// <param name="predicate">the predicate to search, if null it returns null</param>
		/// <returns></returns>
		public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate)
		{
			if (!await TryLoadFileAsync())
				return default;
			else if (predicate == null)
				return default;
			else
				return entities.FirstOrDefault(predicate.Compile());
		}
		/// <summary>
		/// Queries items in repository asynchronously for the predicate specified
		/// </summary>
		/// <param name="predicate">the predicate to search, if null it returns all items</param>
		/// <returns></returns>
		public async Task<IQueryable<TEntity>> WhereAsync(Expression<Func<TEntity, bool>> predicate = null)
		{
			if (!await TryLoadFileAsync())
				return Empty;
			else if (predicate == null)
				return entities.AsQueryable();
			else
				return entities.Where(predicate.Compile()).AsQueryable();
		}
		/// <summary>
		/// Queries items in repository for the predicate specified
		/// </summary>
		/// <param name="predicate">the predicate to search, if null it returns all items</param>
		/// <returns></returns>
		public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate = null)
			=> WhereAsync(predicate).Result;
		/// <summary>
		/// Adds a new item in the repository; Modify to json repository is not recommanded for performance issues
		/// </summary>
		/// <param name="item"></param>
		public void Add(TEntity item) => AddAsync(item).Wait();
		/// <summary>
		/// Update method, updates the json file; Modify to json repository is not recommanded for performance issues
		/// </summary>
		/// <param name="item"></param>
		public void Update(TEntity item) => UpdateAsync(item).Wait();
		/// <summary>
		/// Deletes an item from repository; Modify to json repository is not recommanded for performance issues
		/// </summary>
		/// <param name="item"></param>
		public void Delete(TEntity item) => DeleteAsync(item).Wait();
		/// <summary>
		/// Finds an single item in the repository
		/// </summary>
		/// <param name="predicate">the predicate to search, if null it returns null</param>
		/// <returns></returns>
		public TEntity Find(Expression<Func<TEntity, bool>> predicate = null) => FindAsync(predicate).Result;
	}
}