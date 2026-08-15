using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace KamiSama.Repositories.EntityFramework;

/// <summary>
/// Implements synchronous and asynchronous repository operations over an Entity Framework 6 <see cref="DbSet{TEntity}"/>.
/// </summary>
/// <typeparam name="TEntity">The tracked entity type.</typeparam>
/// <remarks>
/// Every mutation immediately calls <see cref="DbContext.SaveChanges()"/> or <see cref="DbContext.SaveChangesAsync(CancellationToken)"/>.
/// Queries use EF6's default tracking behavior. The repository borrows the supplied context and does not dispose it.
/// </remarks>
/// <param name="context">The context that owns the entity set and its lifetime.</param>
public class DbRepository<TEntity>(DbContext context) : IQueryableRepository<TEntity>, IAsyncQueryableRepository<TEntity>
	where TEntity : class

{
	/// <summary>
	/// Gets the borrowed context used for queries and persistence.
	/// </summary>
	/// <value>The context supplied to the constructor.</value>
	protected DbContext Context { get; } = context;
	private readonly DbSet<TEntity> dbSet = context.Set<TEntity>();

	/// <summary>Adds an entity to the set and immediately saves the context asynchronously.</summary>
	/// <param name="item">The entity to add and track.</param>
	/// <param name="cancellationToken">A token that can cancel the save operation.</param>
	/// <returns>A task that completes after EF6 saves the context.</returns>
	public virtual Task AddAsync(TEntity item, CancellationToken cancellationToken)
	{
		dbSet.Add(item);
		return Context.SaveChangesAsync(cancellationToken);
	}
	/// <summary>Adds an entity to the set and immediately saves the context.</summary>
	/// <param name="item">The entity to add and track.</param>
	public virtual void Add(TEntity item)
	{
		dbSet.Add(item);
		Context.SaveChanges();
	}
	/// <summary>
	/// Marks an entity as modified and immediately saves the context.
	/// </summary>
	/// <param name="item">The entity whose complete mapped state should be treated as modified.</param>
	public virtual void Update(TEntity item)
	{
		var entry = Context.Entry(item);

		if (entry.State != EntityState.Modified)
			entry.State = EntityState.Modified;

		Context.SaveChanges();
	}
	/// <summary>Marks an entity as modified and immediately saves the context asynchronously.</summary>
	/// <param name="item">The entity whose complete mapped state should be treated as modified.</param>
	/// <param name="cancellationToken">A token that can cancel the save operation.</param>
	/// <returns>A task that completes after EF6 saves the context.</returns>
	public virtual Task UpdateAsync(TEntity item, CancellationToken cancellationToken)
	{
		var entry = Context.Entry(item);

		if (entry.State != EntityState.Modified)
			entry.State = EntityState.Modified;

		return Context.SaveChangesAsync(cancellationToken);
	}
	/// <summary>
	/// Marks an entity for deletion and immediately saves the context.
	/// </summary>
	/// <param name="item">The entity to remove.</param>
	public virtual void Delete(TEntity item)
	{
		dbSet.Remove(item);
		Context.SaveChanges();
	}
	/// <summary>Marks an entity for deletion and immediately saves the context asynchronously.</summary>
	/// <param name="item">The entity to remove.</param>
	/// <param name="cancellationToken">A token that can cancel the save operation.</param>
	/// <returns>A task that completes after EF6 saves the context.</returns>
	public virtual Task DeleteAsync(TEntity item, CancellationToken cancellationToken)
	{
		dbSet.Remove(item);
		return Context.SaveChangesAsync(cancellationToken);
	}
	/// <summary>
	/// Returns the tracked entity set as a deferred query.
	/// </summary>
	/// <returns>The underlying <see cref="DbSet{TEntity}"/> as an <see cref="IQueryable{TEntity}"/>.</returns>
	public virtual IQueryable<TEntity> AsQueryable()
		=> dbSet;
	/// <summary>
	/// Creates a tracked, deferred query filtered by a predicate.
	/// </summary>
	/// <param name="predicate">The expression translated by the EF6 query provider.</param>
	/// <returns>A deferred query over matching entities.</returns>
	public virtual IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
		=> dbSet.Where(predicate);
	/// <summary>
	/// Determines synchronously whether any entity matches a predicate.
	/// </summary>
	/// <param name="predicate">The expression translated by the EF6 query provider.</param>
	/// <returns><see langword="true"/> when at least one entity matches; otherwise, <see langword="false"/>.</returns>
	public virtual bool Any(Expression<Func<TEntity, bool>> predicate)
		=> dbSet.Any(predicate);
	/// <summary>
	/// Determines asynchronously whether any entity matches a predicate.
	/// </summary>
	/// <param name="predicate">The expression translated by the EF6 query provider.</param>
	/// <param name="cancellationToken">A token that can cancel query execution.</param>
	/// <returns>A task containing <see langword="true"/> when at least one entity matches; otherwise, <see langword="false"/>.</returns>
	public virtual Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
		=> dbSet.AnyAsync(predicate, cancellationToken);
	/// <summary>
	/// Returns the first tracked entity matching a predicate.
	/// </summary>
	/// <param name="predicate">The expression translated by the EF6 query provider.</param>
	/// <returns>The first matching entity, or <see langword="null"/> when no entity matches.</returns>
	public virtual TEntity? Find(Expression<Func<TEntity, bool>> predicate)
		=> dbSet.FirstOrDefault(predicate);
	/// <summary>Asynchronously returns the first tracked entity matching a predicate.</summary>
	/// <param name="predicate">The expression translated by the EF6 query provider.</param>
	/// <param name="cancellationToken">A token that can cancel query execution.</param>
	/// <returns>A task containing the first matching entity, or <see langword="null"/> when no entity matches.</returns>
	public virtual Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
		=> dbSet.FirstOrDefaultAsync(predicate, cancellationToken)!;
	/// <summary>
	/// Releases no resources because the repository does not own the injected context.
	/// </summary>
	/// <remarks>The context owner remains responsible for disposing the context.</remarks>
	[ExcludeFromCodeCoverage]
	void IDisposable.Dispose()
	{
		GC.SuppressFinalize(this);
	}
}
/// <summary>
/// Exposes a strongly typed protected context while retaining the EF6 repository behavior.
/// </summary>
/// <typeparam name="TEntity">The tracked entity type.</typeparam>
/// <typeparam name="TDbContext">The concrete EF6 context type.</typeparam>
/// <param name="context">The concrete context that owns the entity set and its lifetime.</param>
/// <remarks>Mutations save immediately, queries track by default, and disposal does not dispose the supplied context.</remarks>
[ExcludeFromCodeCoverage]
public class DbRepository<TEntity, TDbContext>(TDbContext context) : DbRepository<TEntity>(context)
	where TDbContext : DbContext
	where TEntity : class
{
	/// <summary>
	/// Gets the borrowed context as <typeparamref name="TDbContext"/> for derived repositories.
	/// </summary>
	/// <value>The context supplied to the constructor.</value>
	protected new TDbContext Context => (TDbContext)base.Context;
}
