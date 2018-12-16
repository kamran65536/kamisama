using System;
using System.Linq.Expressions;

namespace KamiSama.Repositories
{
	public interface IRepository<_EntityType> : IDisposable
    {
		void Add(_EntityType item);
		void Update(_EntityType item);
		void Delete(_EntityType item);
		_EntityType Find(Expression<Func<_EntityType, bool>> predicate);
    }
}
