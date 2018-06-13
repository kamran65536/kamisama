using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace KamiSama.Repositories.EntityFrameworkCore
{
	public class DbRepository<_EntityType> : IRepository<_EntityType>
		where _EntityType : class

	{
		private DbContext context;
		private bool contextMustBeDisposed;
		private DbSet<_EntityType> dbSet;

		public DbRepository(DbContext context)
			: this(context, true)
		{
		}
		public DbRepository(DbContext context, bool contextMustBeDisposed = false)
		{
			this.context = context;
			this.contextMustBeDisposed = contextMustBeDisposed;
			this.dbSet = context.Set<_EntityType>();
		}

		public void Add(_EntityType item)
		{
			dbSet.Add(item);
			context.SaveChanges();
		}
		public void Update(_EntityType item)
		{
			context.Entry(item).State = EntityState.Modified;
			context.SaveChanges();
		}

		public void Delete(_EntityType item)
		{
			dbSet.Remove(item);
			context.SaveChanges();
		}

		public IEnumerable<_EntityType> Where(Expression<Func<_EntityType, bool>> predicate)
			=> dbSet.Where(predicate);

		public void Dispose()
		{
			try
			{
				if (contextMustBeDisposed)
					context.Dispose();
			}
			catch { }
		}
	}
}
