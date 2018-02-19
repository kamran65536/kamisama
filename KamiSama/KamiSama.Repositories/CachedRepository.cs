using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace KamiSama.Repositories
{
	public abstract class CachedRepository<_UnitOfWorkType, _EntityType> : IRepository<_UnitOfWorkType, _EntityType>
	{
		private _EntityType[] items;
		public DateTime LastUpdate { get; private set; } = DateTime.MinValue;
		public TimeSpan RefreshInterval { get; private set; }

		public CachedRepository(TimeSpan refreshInterval)
		{
			this.RefreshInterval = refreshInterval;
		}
		public virtual _EntityType Add(_UnitOfWorkType unitOfWork, _EntityType item)
		{
			throw new NotImplementedException();
		}

		public virtual bool Remove(_UnitOfWorkType unitOfWork, _EntityType item)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<_EntityType> Where(_UnitOfWorkType unitOfWork, Expression<Func<_EntityType, bool>> predicate)
		{
			CheckForItems(unitOfWork, forceUpdate: false);

			if (items == null)
				return new _EntityType[0];

			return items.Where(predicate.Compile());
		}

		private void CheckForItems(_UnitOfWorkType unitOfWork, bool forceUpdate)
		{
			if (forceUpdate ||
				(items == null) ||
				(DateTime.Now - LastUpdate > RefreshInterval))
			{
				try
				{
					items = LoadItems(unitOfWork);
				}
				catch (Exception)
				{
					throw;
				}

				LastUpdate = DateTime.Now;
			}
		}

		protected abstract _EntityType[] LoadItems(_UnitOfWorkType unitOfWork);
	}
}
