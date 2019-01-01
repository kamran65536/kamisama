using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace KamiSama.Repositories
{
	public class InMemoryRepository<_EntityType> : IQueryableRepository<_EntityType>
	{
		private HashSet<_EntityType> items;


		public InMemoryRepository()
			: this(null, null)
		{
		}
		public InMemoryRepository(IEnumerable<_EntityType> initialItems, IEqualityComparer<_EntityType> comparer = null)
		{
			initialItems = initialItems ?? new _EntityType[0];

			if (comparer == null)
				items = new HashSet<_EntityType>(initialItems);
			else
				items = new HashSet<_EntityType>(initialItems, comparer);
		}

		public void Dispose()
		{
			try { items.Clear(); } catch { }
		}

		public void Add(_EntityType item)
			=> items.Add(item);
		public void Update(_EntityType item)
		{
		}

		public void Delete(_EntityType item)
			=> items.Remove(item);

		public IQueryable<_EntityType> Where(Expression<Func<_EntityType, bool>> predicate)
			=> (predicate == null) ? new _EntityType[0].AsQueryable() : items.Where(predicate.Compile()).AsQueryable();
		public _EntityType Find(Expression<Func<_EntityType, bool>> predicate)
			=> (predicate == null) ? default(_EntityType) : items.FirstOrDefault(predicate.Compile());
	}
}
