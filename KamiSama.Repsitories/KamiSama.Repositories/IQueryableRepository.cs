using System;
using System.Linq;
using System.Linq.Expressions;

namespace KamiSama.Repositories
{
	public interface IQueryableRepository<_EntityType> : IRepository<_EntityType>
	{
		IQueryable<_EntityType> Where(Expression<Func<_EntityType, bool>> predicate);
	}
}
