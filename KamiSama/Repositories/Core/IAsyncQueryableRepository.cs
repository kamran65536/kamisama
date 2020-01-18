using System;
using System.Linq;
using System.Linq.Expressions;

namespace KamiSama.Repositories
{
	public interface IAsyncQueryableRepository<_EntityType> : IQueryableRepository<_EntityType>, IAsyncRepository<_EntityType>
	{
		/// <summary>
		/// the same as Where, just to indicate async behavior
		/// </summary>
		/// <param name="predicate"></param>
		/// <returns></returns>
		IQueryable<_EntityType> WhereAsync(Expression<Func<_EntityType, bool>> predicate);
	}
}
