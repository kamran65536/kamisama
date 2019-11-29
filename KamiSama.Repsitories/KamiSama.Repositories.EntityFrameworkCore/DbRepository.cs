using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KamiSama.Repositories.EntityFrameworkCore
{
	public class DbRepository<_EntityType> : IAsyncQueryableRepository<_EntityType>
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
		public Task AddAsync(_EntityType item)
		{
			dbSet.Add(item);
			return context.SaveChangesAsync();
		}
		public virtual void Add(_EntityType item)
		{
			dbSet.Add(item);
			context.SaveChanges();
		}
		public virtual void Update(_EntityType item)
		{
			var entry = context.Entry(item);

			if (entry.State != EntityState.Modified)
				entry.State = EntityState.Modified;

			context.SaveChanges();
		}
		public Task UpdateAsync(_EntityType item)
		{
			var entry = context.Entry(item);

			if (entry.State != EntityState.Modified)
				entry.State = EntityState.Modified;

			return context.SaveChangesAsync();
		}
		public virtual void Delete(_EntityType item)
		{
			dbSet.Remove(item);
			context.SaveChanges();
		}
		public virtual Task DeleteAsync(_EntityType item)
		{
			dbSet.Remove(item);
			return context.SaveChangesAsync();
		}
		public virtual IQueryable<_EntityType> Where(Expression<Func<_EntityType, bool>> predicate)
			=> dbSet.Where(predicate);
		public IQueryable<_EntityType> WhereAsync(Expression<Func<_EntityType, bool>> predicate)
			=> Where(predicate);
		public virtual _EntityType Find(Expression<Func<_EntityType, bool>> predicate)
			=> dbSet.FirstOrDefault(predicate);
		public Task<_EntityType> FindAsync(Expression<Func<_EntityType, bool>> predicate)
			=> dbSet.FirstOrDefaultAsync(predicate);
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
			where _EntityType : class
	{
		public DbRepository(_ContextType context)
			: base(context)
		{
		}
	}
}
