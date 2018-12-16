using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace KamiSama.Repositories.EntityFramework
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

		public virtual void Add(_EntityType item)
		{
			dbSet.Add(item);
			context.SaveChanges();
		}
		public virtual void Update(_EntityType item)
		{
			context.Entry(item).State = EntityState.Modified;
			context.SaveChanges();
		}

		public virtual void Delete(_EntityType item)
		{
			dbSet.Remove(item);
			context.SaveChanges();
		}

		public virtual IEnumerable<_EntityType> Where(Expression<Func<_EntityType, bool>> predicate)
			=> dbSet.Where(predicate);

		public virtual void Dispose()
		{
			try
			{
				if (contextMustBeDisposed)
					context.Dispose();
			}
			catch { }
		}
	}
	public class DbRepository<_EntityType, _ContextType> : DbRepository<_EntityType>
		where _ContextType : DbContext
		where _EntityType: class
	{
		public DbRepository(_ContextType context)
			: base(context)
		{
		}
	}
}
