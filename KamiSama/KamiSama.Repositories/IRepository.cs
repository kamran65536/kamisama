using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace KamiSama.Repositories
{
	public interface IRepository<_UnitOfWorkType, _EntityType>
    {
		IEnumerable<_EntityType> Where(_UnitOfWorkType unitOfWork, Expression<Func<_EntityType, bool>> predicate);
		_EntityType Add(_UnitOfWorkType unitOfWork, _EntityType item);
		bool Remove(_UnitOfWorkType unitOfWork, _EntityType item);

		void SaveChanges(_UnitOfWorkType unitOfWork);
    }
}
