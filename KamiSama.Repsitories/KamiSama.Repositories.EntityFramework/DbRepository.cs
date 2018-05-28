using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace KamiSama.Repositories
{
	public class DbRepository<_UnitOfWorkType, _ContextType, _EntityType> : IRepository<_UnitOfWorkType, _EntityType>
		where _UnitOfWorkType : IContextBasedUnitOfWork<_ContextType>
		where _ContextType : DbContext
		where _EntityType : class

	{
		private bool autoSaveChanges;

		public DbRepository()
			: this(true)
		{
		}
		public DbRepository(bool autoSaveChanges)
		{
			this.autoSaveChanges = autoSaveChanges;
		}

		public _EntityType Add(_UnitOfWorkType unitOfWork, _EntityType item)
		{
			var context = unitOfWork.GetContext();

			var result = context.Set<_EntityType>().Add(item);

			context.SaveChanges();

			return item;
		}

		public bool Remove(_UnitOfWorkType unitOfWork, _EntityType item)
		{
			var context = unitOfWork.GetContext();

			context.Set<_EntityType>().Remove(item);

			context.SaveChanges();

			return true;
		}

		public IEnumerable<_EntityType> Where(_UnitOfWorkType unitOfWork, Expression<Func<_EntityType, bool>> predicate)
			=> unitOfWork.GetContext().Set<_EntityType>().Where(predicate);

		public void SaveChanges(_UnitOfWorkType unitOfWork)
			=> unitOfWork.GetContext().SaveChanges();
	}
}
