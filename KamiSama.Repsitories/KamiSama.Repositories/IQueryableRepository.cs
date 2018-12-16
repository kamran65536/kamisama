using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace KamiSama.Repositories
{
	public interface IQueryableRepository<_EntityType> : IRepository<_EntityType>
	{
		IEnumerable<_EntityType> Where(Expression<Func<_EntityType, bool>> predicate);
	}
}
