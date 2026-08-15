using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace KamiSama.Repositories;

/// <summary>
/// Stores entities in an in-process <see cref="HashSet{T}"/> for tests and lightweight transient scenarios.
/// </summary>
/// <remarks>
/// Add and delete operations are serialized per repository instance, but reads and returned queries are not locked.
/// Do not enumerate a query while another operation mutates the repository. Duplicate and removal matching follow the configured equality comparer, and update operations intentionally do nothing.
/// </remarks>
/// <typeparam name="TEntity">The entity type stored in memory.</typeparam>
public class InMemoryRepository<TEntity> : IQueryableRepository<TEntity>, IAsyncQueryableRepository<TEntity>
{
	/// <summary>
	/// the internal collection of items
	/// </summary>
	private readonly HashSet<TEntity> items;
	private readonly SemaphoreSlim semaphore;
	/// <summary>
	/// Initializes the repository with optional entities and an optional equality comparer.
	/// </summary>
	/// <param name="initialItems">The entities copied into the internal set, or <see langword="null"/> for an empty repository.</param>
	/// <param name="comparer">The comparer that controls duplicate and removal semantics, or <see langword="null"/> to use the default comparer.</param>
	public InMemoryRepository(IEnumerable<TEntity>? initialItems,
						IEqualityComparer<TEntity>? comparer = null)
	{
		initialItems ??= [];
		semaphore = new SemaphoreSlim(1, 1);

		if (comparer == null)
			items = [.. initialItems];
		else
			items = new HashSet<TEntity>(initialItems, comparer);
	}
	/// <summary>
	/// Initializes an empty repository using the default equality comparer.
	/// </summary>
	public InMemoryRepository()
		: this(initialItems: null, comparer: null)
	{
	}
	/// <summary>
	/// Clears the in-memory entity set. The instance must not be used after disposal.
	/// </summary>
	[ExcludeFromCodeCoverage]
	void IDisposable.Dispose()
	{
		try { items.Clear(); } catch { }
		GC.SuppressFinalize(this);
	}
	/// <summary>
	/// Adds an entity when the set does not already contain an equal entity.
	/// </summary>
	/// <param name="item">The entity to add. Equal duplicates are ignored by <see cref="HashSet{T}"/>.</param>
	public virtual void Add(TEntity item)
	{
		semaphore.Wait();
		items.Add(item);
		semaphore.Release();
	}
	/// <summary>
	/// Performs no operation; callers must mutate a stored reference directly when appropriate.
	/// </summary>
	/// <param name="item">The entity value, which is ignored.</param>
	public virtual void Update(TEntity item)
	{
	}
	/// <summary>
	/// Removes the entity equal to the supplied value when one exists.
	/// </summary>
	/// <param name="item">The entity used for equality-based removal.</param>
	public virtual void Delete(TEntity item)
	{
		semaphore.Wait();
		items.Remove(item);
		semaphore.Release();
	}
	/// <summary>
	/// Returns a live query over all entities or those matching the predicate.
	/// </summary>
	/// <remarks>The returned query is not a snapshot and is not synchronized with mutations.</remarks>
	/// <param name="predicate">The predicate to compile and apply, or <see langword="null"/> to return all entities.</param>
	/// <returns>A live query over the internal set.</returns>
	public virtual IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
		=> (predicate == null) ? items.AsQueryable() : items.Where(predicate.Compile()).AsQueryable();
	/// <summary>
	/// Returns the first matching entity, or the default value when the predicate is <see langword="null"/> or no entity matches.
	/// </summary>
	/// <param name="predicate">The predicate to compile and apply.</param>
	/// <returns>The first matching entity, or the default value for <typeparamref name="TEntity"/>.</returns>
	public virtual TEntity? Find(Expression<Func<TEntity, bool>>? predicate)
		=> (predicate == null) ? default : items.FirstOrDefault(predicate.Compile());
	/// <summary>
	/// Asynchronously waits for mutation access and adds an entity unless an equal entity already exists.
	/// </summary>
	/// <param name="item">The entity to add.</param>
	/// <param name="cancellationToken">A token that can cancel the semaphore wait.</param>
	/// <returns>A task that represents the in-memory add operation.</returns>
	public virtual async Task AddAsync(TEntity item, CancellationToken cancellationToken)
	{
		await semaphore.WaitAsync(cancellationToken);
		items.Add(item);
		semaphore.Release();
	}
	/// <summary>
	/// Completes immediately without changing the repository.
	/// </summary>
	/// <param name="item">The entity value, which is ignored.</param>
	/// <param name="cancellationToken">A token that is not observed because no work is performed.</param>
	/// <returns>An already-completed task.</returns>
	public Task UpdateAsync(TEntity item, CancellationToken cancellationToken) => Task.CompletedTask;
	/// <summary>
	/// Asynchronously waits for mutation access and removes an equal entity when one exists.
	/// </summary>
	/// <param name="item">The entity used for equality-based removal.</param>
	/// <param name="cancellationToken">A token that can cancel the semaphore wait.</param>
	/// <returns>A task that represents the in-memory delete operation.</returns>
	public virtual async Task DeleteAsync(TEntity item, CancellationToken cancellationToken)
	{
		await semaphore.WaitAsync(cancellationToken);
		items.Remove(item);
		semaphore.Release();
	}
	/// <summary>
	/// Returns a completed task containing the first matching entity.
	/// </summary>
	/// <param name="predicate">The predicate to compile and apply, or <see langword="null"/> to return the default value.</param>
	/// <param name="cancellationToken">A token that is not observed because the lookup runs synchronously.</param>
	/// <returns>A task containing the first matching entity, or the default value for <typeparamref name="TEntity"/>.</returns>
	public virtual Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>>? predicate, CancellationToken cancellationToken)
		=> Task.FromResult(Find(predicate));
}
