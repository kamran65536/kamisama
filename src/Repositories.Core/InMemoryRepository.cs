using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace KamiSama.Repositories
{
	/// <summary>
	/// The internal memory repository, this class can be used for testing
	/// The class operations are thread safe
	/// </summary>
	/// <typeparam name="TEntity"></typeparam>
	public class InMemoryRepository<TEntity> : IQueryableRepository<TEntity>, IAsyncQueryableRepository<TEntity>
	{
		/// <summary>
		/// the internal collection of items
		/// </summary>
		private readonly HashSet<TEntity> items;
		private readonly SemaphoreSlim semaphore;
		/// <summary>
		/// Constructor with initial items
		/// </summary>
		/// <param name="initialItems"></param>
		/// <param name="comparer"></param>
		public InMemoryRepository(IEnumerable<TEntity>? initialItems,
							IEqualityComparer<TEntity>? comparer = null)
		{
			initialItems ??= new TEntity[0];
			semaphore = new SemaphoreSlim(1, 1);

			if (comparer == null)
				items = new HashSet<TEntity>(initialItems);
			else
				items = new HashSet<TEntity>(initialItems, comparer);
		}
		/// <summary>
		/// Constructor with no parameter (generally used for dependency injection)
		/// </summary>
		public InMemoryRepository()
			: this(initialItems: null, comparer: null)
		{
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
		/// Adds a new item in the repository
		/// </summary>
		/// <param name="item"></param>
		public virtual void Add(TEntity item)
		{
			semaphore.Wait();
			items.Add(item);
			semaphore.Release();
		}
		/// <summary>
		/// Update method, does nothing
		/// </summary>
		/// <param name="item"></param>
		public virtual void Update(TEntity item)
		{
		}
		/// <summary>
		/// Deletes an item from repository
		/// </summary>
		/// <param name="item"></param>
		public virtual void Delete(TEntity item)
		{
			semaphore.Wait();
			items.Remove(item);
			semaphore.Release();
		}
		/// <summary>
		/// Queries items in repository for the predicate specified
		/// </summary>
		/// <param name="predicate">the predicate to search, if null it returns all items</param>
		/// <returns></returns>
		public virtual IQueryable<TEntity> Where(Expression<Func<TEntity, bool>>? predicate = null)
			=> (predicate == null) ? items.AsQueryable() : items.Where(predicate.Compile()).AsQueryable();
		/// <summary>
		/// Finds an single item in the repository
		/// </summary>
		/// <param name="predicate">the predicate to search, if null it returns null</param>
		/// <returns></returns>
		public virtual TEntity? Find(Expression<Func<TEntity, bool>>? predicate)
			=> (predicate == null) ? default : items.FirstOrDefault(predicate.Compile());
		///
		public virtual async Task AddAsync(TEntity item, CancellationToken cancellationToken = default)
		{
			await semaphore.WaitAsync();
			items.Add(item);
			semaphore.Release();
		}
		/// <inheritdoc />
		public Task UpdateAsync(TEntity item, CancellationToken cancellationToken = default) => Task.CompletedTask;
		/// <inheritdoc />
		public virtual async Task DeleteAsync(TEntity item, CancellationToken cancellationToken = default)
		{
			await semaphore.WaitAsync();
			items.Remove(item);
			semaphore.Release();
		}
		/// <inheritdoc />
		public virtual Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
			=> Task.FromResult(Find(predicate));
	}
}
