using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace KamiSama.Repositories
{
	public class DbRepository<_ContextType, _EntityType> : IRepository<IContextBasedUnitOfWork<_ContextType>, _EntityType>
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

		public _EntityType Add(IContextBasedUnitOfWork<_ContextType> unitOfWork, _EntityType item)
		{
			var context = unitOfWork.GetContext();

			var result = context.Set<_EntityType>().Add(item);

			context.SaveChanges();

			return item;
		}

		public bool Remove(IContextBasedUnitOfWork<_ContextType> unitOfWork, _EntityType item)
		{
			var context = unitOfWork.GetContext();

			context.Set<_EntityType>().Remove(item);

			context.SaveChanges();

			return true;
		}

		public IEnumerable<_EntityType> Where(IContextBasedUnitOfWork<_ContextType> unitOfWork, Expression<Func<_EntityType, bool>> predicate)
			=> unitOfWork.GetContext().Set<_EntityType>().Where(predicate);
	}
}
