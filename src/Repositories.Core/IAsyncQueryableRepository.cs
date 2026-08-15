using System.Linq.Expressions;

namespace KamiSama.Repositories;

/// <summary>
/// Combines asynchronous repository operations with a synchronous query-returning <c>Where</c> method.
/// </summary>
/// <typeparam name="TEntity">The entity type exposed by the query.</typeparam>
public interface IAsyncQueryableRepository<TEntity> : IAsyncRepository<TEntity>
{
	/// <summary>
	/// Returns a query for entities that satisfy the predicate; this method itself is synchronous.
	/// </summary>
	/// <param name="predicate">The predicate used to filter entities. Implementations may accept <see langword="null"/> to return all entities.</param>
	/// <returns>A query containing matching entities.</returns>
	IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
}
