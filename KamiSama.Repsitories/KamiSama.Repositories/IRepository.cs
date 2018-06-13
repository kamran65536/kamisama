using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace KamiSama.Repositories
{
	public interface IRepository<_EntityType> : IDisposable
    {
		IEnumerable<_EntityType> Where(Expression<Func<_EntityType, bool>> predicate);
		void Add(_EntityType item);
		void Update(_EntityType item);
		void Delete(_EntityType item);
    }
}
