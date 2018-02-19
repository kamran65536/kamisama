using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace KamiSama.Repositories
{
	public class InMemoryRepository<_UnitOfWorkType, _EntityType> : IRepository<_UnitOfWorkType, _EntityType>
	{
		private HashSet<_EntityType> items;

		public InMemoryRepository(_UnitOfWorkType unitOfWork, IEnumerable<_EntityType> initialItems = null, IEqualityComparer<_EntityType> comparer = null)
		{
			initialItems = initialItems ?? new _EntityType[0];

			if (comparer == null)
				items = new HashSet<_EntityType>(initialItems);
			else
				items = new HashSet<_EntityType>(initialItems, comparer);
		}

		public _EntityType Add(_UnitOfWorkType unitOfWork, _EntityType item)
		{
			items.Add(item);

			return item;
		}

		public bool Remove(_UnitOfWorkType unitOfWork, _EntityType item)
			=> items.Remove(item);

		public IEnumerable<_EntityType> Where(_UnitOfWorkType unitOfWork, Expression<Func<_EntityType, bool>> predicate)
			=> items.Where(predicate.Compile());
	}
}
