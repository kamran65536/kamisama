using System;
using System.Linq;
using System.Linq.Expressions;

namespace KamiSama.Repositories
{
	/// <summary>
	/// IAsyncQueryable Repository
	/// </summary>
	/// <typeparam name="TEntity"></typeparam>
	public interface IAsyncQueryableRepository<TEntity> : IAsyncRepository<TEntity>
	{
		/// <summary>
		/// the same as Where, just to indicate async behavior
		/// </summary>
		/// <param name="predicate"></param>
		/// <returns></returns>
		IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate = null);
	}
}
