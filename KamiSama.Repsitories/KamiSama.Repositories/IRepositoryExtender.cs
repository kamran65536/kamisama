using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace KamiSama.Repositories
{
	public static class IRepositoryExtender
    {
		public static _EntityType FirstOrDefault< _EntityType>(this IQueryableRepository<_EntityType> repository, Expression<Func<_EntityType, bool>> predicate)
			=> repository.Where(predicate).FirstOrDefault();

		public static IEnumerable<_EntityType> GetAll<_EntityType>(this IQueryableRepository<_EntityType> repository)
			=> repository.Where(x => true);
	}
}
