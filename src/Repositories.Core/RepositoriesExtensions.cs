using System;
using System.Linq;
using System.Linq.Expressions;

namespace KamiSama.Repositories
{
	/// <summary>
	/// Provides convenience queries for <see cref="IQueryableRepository{TEntity}"/> implementations.
	/// </summary>
	public static class RepositoriesExtensions
    {
		/// <summary>
		/// Returns the first entity matching the predicate, or the default value when none matches.
		/// </summary>
		/// <remarks>This delegates filtering to <see cref="IQueryableRepository{TEntity}.Where"/> and then applies LINQ <c>FirstOrDefault</c>.</remarks>
		/// <typeparam name="TEntity">The entity type exposed by the repository.</typeparam>
		/// <param name="repository">The queryable repository to search.</param>
		/// <param name="predicate">The predicate used to select an entity.</param>
		/// <returns>The first matching entity, or the default value for <typeparamref name="TEntity"/>.</returns>
		public static TEntity? FirstOrDefault< TEntity>(this IQueryableRepository<TEntity> repository, Expression<Func<TEntity, bool>> predicate)
			=> repository.Where(predicate).FirstOrDefault();
		/// <summary>
		/// Returns all entities by querying the repository with an always-true predicate.
		/// </summary>
		/// <typeparam name="TEntity">The entity type exposed by the repository.</typeparam>
		/// <param name="repository">The queryable repository to enumerate.</param>
		/// <returns>A query containing all repository entities.</returns>
		public static IQueryable<TEntity> GetAll<TEntity>(this IQueryableRepository<TEntity> repository)
			=> repository.Where(x => true);
	}
}
