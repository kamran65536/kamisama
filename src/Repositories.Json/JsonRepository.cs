using KamiSama.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace KamiSama.Repositories.Json
{
	public class JsonRepository<TEntity> : IQueryableRepository<TEntity>, IAsyncQueryableRepository<TEntity>
	{
		/// <summary>
		/// the internal collection of items
		/// </summary>
		private HashSet<TEntity> items;
		private readonly SemaphoreSlim semaphore;
		private readonly string filePath;
		private readonly IEqualityComparer<TEntity> comparer;

		/// <summary>
		/// Constructor with initial items
		/// </summary>
		/// <param name="initialItems"></param>
		/// <param name="comparer"></param>
		/// <param name="filePath"></param>
		public JsonRepository(string filePath, IEqualityComparer<TEntity> comparer = null)
		{
			this.semaphore = new SemaphoreSlim(1);
			this.filePath = filePath;
			this.comparer = comparer;

			LoadFromFile();
		}
		/// <summary>
		/// Dispose method, clears internal cache
		/// </summary>
		[ExcludeFromCodeCoverage]
		public virtual void Dispose()
		{
			try { items.Clear(); } catch { }
		}
		/// <summary>
		/// Loads items from file, if any exception happens, the initial items will be empty
		/// </summary>
		internal virtual void LoadFromFile()
		{
			TEntity[] initialItems;

			try
			{
				initialItems = File
					.ReadAllText(filePath)
					.DeserializeFromJson<TEntity[]>();
			}
			catch
			{
				initialItems = new TEntity[0];
			}
			
			if (comparer == null)
				items = new HashSet<TEntity>(initialItems);
			else
				items = new HashSet<TEntity>(initialItems, comparer);

		}
		/// <summary>
		/// Saves items into the file
		/// </summary>
		internal virtual void SaveToFile()
		{
			File.WriteAllText(filePath, items.ToArray().SerializeToJson());
		}
		/// <summary>
		/// Reloads input file
		/// </summary>
		public void ReloadFile()
		{
			semaphore.Wait();
			LoadFromFile();
			semaphore.Release();
		}
		/// <summary>
		/// Adds a new item in the repository; Modify to json repository is not recommanded for performance issues
		/// </summary>
		/// <param name="item"></param>
		public virtual void Add(TEntity item)
		{
			semaphore.Wait();
			items.Add(item);
			SaveToFile();
			semaphore.Release();
		}
		/// <summary>
		/// Update method, updates the json file; Modify to json repository is not recommanded for performance issues
		/// </summary>
		/// <param name="item"></param>
		public virtual void Update(TEntity item)
		{
			semaphore.Wait();
			SaveToFile();
			semaphore.Release();
		}
		/// <summary>
		/// Deletes an item from repository; Modify to json repository is not recommanded for performance issues
		/// </summary>
		/// <param name="item"></param>
		public virtual void Delete(TEntity item)
		{
			semaphore.Wait();
			items.Remove(item);
			SaveToFile();
			semaphore.Release();
		}
		/// <summary>
		/// Queries items in repository for the predicate specified
		/// </summary>
		/// <param name="predicate">the predicate to search, if null it returns all items</param>
		/// <returns></returns>
		public virtual IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate = null)
			=> (predicate == null) ? items.AsQueryable() : items.Where(predicate.Compile()).AsQueryable();
		/// <summary>
		/// Finds an single item in the repository
		/// </summary>
		/// <param name="predicate">the predicate to search, if null it returns null</param>
		/// <returns></returns>
		public virtual TEntity Find(Expression<Func<TEntity, bool>> predicate)
			=> (predicate == null) ? default : items.FirstOrDefault(predicate.Compile());
		/// <summary>
		/// Adds a new item in the repository; Modify to json repository is not recommanded for performance issues
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public virtual async Task AddAsync(TEntity item)
		{
			await semaphore.WaitAsync();
			items.Add(item);
			SaveToFile();
			semaphore.Release();
		}
		/// <summary>
		/// Update method, does nothing; Modify to json repository is not recommanded for performance issues
		/// </summary>
		/// <param name="item"></param>
		public async Task UpdateAsync(TEntity item)
		{
			await semaphore.WaitAsync();
			SaveToFile();
			semaphore.Release();
		}
		/// <summary>
		/// Deletes an item from repository; Modify to json repository is not recommanded for performance issues
		/// </summary>
		/// <param name="item"></param>
		public virtual async Task DeleteAsync(TEntity item)
		{
			await semaphore.WaitAsync();
			items.Remove(item);
			SaveToFile();
			semaphore.Release();
		}
		/// <summary>
		/// Finds an single item in the repository
		/// </summary>
		/// <param name="predicate">the predicate to search, if null it returns null</param>
		/// <returns></returns>
		public virtual Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate = null)
			=> Task.FromResult(Find(predicate));
	}
}
