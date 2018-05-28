using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace KamiSama.Repositories
{
	public abstract class CachedRepository<_UnitOfWorkType, _EntityType> : IRepository<_UnitOfWorkType, _EntityType>
	{
		protected _EntityType[] Items { get; private set; }
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

			if (Items == null)
				return new _EntityType[0];

			return Items.Where(predicate.Compile());
		}

		private void CheckForItems(_UnitOfWorkType unitOfWork, bool forceUpdate)
		{
			if (forceUpdate ||
				(Items == null) ||
				(DateTime.Now - LastUpdate > RefreshInterval))
			{
				try
				{
					Items = LoadItems(unitOfWork);
				}
				catch (Exception)
				{
					throw;
				}

				LastUpdate = DateTime.Now;
			}
		}

		protected abstract _EntityType[] LoadItems(_UnitOfWorkType unitOfWork);

		public virtual void SaveChanges(_UnitOfWorkType unitOfWork)
		{
		}
	}
}
