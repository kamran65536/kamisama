using System.Linq.Expressions;

namespace KamiSama.Repositories
{
	/// <summary>
	/// Defines predicate-based querying in addition to synchronous repository operations.
	/// </summary>
	/// <typeparam name="TEntity">The entity type exposed by the query.</typeparam>
	public interface IQueryableRepository<TEntity> : IRepository<TEntity>
	{
		/// <summary>
		/// Returns a query for entities that satisfy the predicate.
		/// </summary>
		/// <param name="predicate">The predicate used to filter entities. Implementations may accept <see langword="null"/> to return all entities.</param>
		/// <returns>A query containing matching entities.</returns>
		IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
	}
}
