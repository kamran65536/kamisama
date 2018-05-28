using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace KamiSama.Repositories
{
	public static class IRepositoryExtender
    {
		public static _EntityType FirstOrDefault<_UnitOfWorkType, _EntityType>(this IRepository<_UnitOfWorkType, _EntityType> repository, _UnitOfWorkType unitOfWork, Expression<Func<_EntityType, bool>> predicate)
			=> repository.Where(unitOfWork, predicate).FirstOrDefault();

		public static IEnumerable<_EntityType> GetAll<_UnitOfWorkType, _EntityType>(this IRepository<_UnitOfWorkType, _EntityType> repository, _UnitOfWorkType unitOfWork)
			=> repository.Where(unitOfWork, x => true);
	}
}
