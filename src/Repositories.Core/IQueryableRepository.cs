using System;
using System.Linq;
using System.Linq.Expressions;

namespace KamiSama.Repositories
{
	/// <summary>
	/// Queryable Repository Interface, these repositories can be searched throughout
	/// </summary>
	/// <typeparam name="TEntity"></typeparam>
	public interface IQueryableRepository<TEntity> : IRepository<TEntity>
	{
		/// <summary>
		/// Queries items in repository for the predicate specified
		/// </summary>
		/// <param name="predicate">the predicate to search, if null it returns all items</param>
		/// <returns></returns>
		IQueryable<TEntity> Where(Expression<Func<TEntity, bool>>? predicate = null);
	}
}
