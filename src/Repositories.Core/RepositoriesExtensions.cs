using System;
using System.Linq;
using System.Linq.Expressions;

namespace KamiSama.Repositories
{
	/// <summary>
	/// Repositories Extensions
	/// </summary>
	public static class RepositoriesExtensions
    {
		/// <summary>
		/// Returns first or default item for IQueryableRepository
		/// </summary>
		/// <remarks>if you want to search on IRepository, you can also use Find method</remarks>
		/// <typeparam name="TEntity"></typeparam>
		/// <param name="repository"></param>
		/// <param name="predicate"></param>
		/// <returns></returns>
		public static TEntity? FirstOrDefault< TEntity>(this IQueryableRepository<TEntity> repository, Expression<Func<TEntity, bool>> predicate)
			=> repository.Where(predicate).FirstOrDefault();
		/// <summary>
		/// Returns all Items in the repository
		/// </summary>
		/// <typeparam name="TEntity"></typeparam>
		/// <param name="repository"></param>
		/// <returns></returns>
		public static IQueryable<TEntity> GetAll<TEntity>(this IQueryableRepository<TEntity> repository)
			=> repository.Where(x => true);
	}
}
