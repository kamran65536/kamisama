using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace KamiSama.Repositories.EntityFrameworkCore
{
	/// <summary>
	/// Database Repository for entity framework
	/// </summary>
	/// <typeparam name="TEntity"></typeparam>
	public class DbRepository<TEntity> : IQueryableRepository<TEntity>, IAsyncQueryableRepository<TEntity>
		where TEntity : class

	{
		/// <summary>
		/// context class
		/// </summary>
		protected DbContext Context { get; }
		private readonly DbSet<TEntity> dbSet;
		/// <summary>
		/// initiates an db repository
		/// </summary>
		/// <param name="context"></param>
		public DbRepository(DbContext context)
		{
			this.Context = context;
			this.dbSet = context.Set<TEntity>();
		}
		/// <inheritdoc />
		public Task AddAsync(TEntity item, CancellationToken cancellationToken = default)
		{
			dbSet.Add(item);
			return Context.SaveChangesAsync();
		}
		/// <inheritdoc />
		public virtual void Add(TEntity item)
		{
			dbSet.Add(item);
			Context.SaveChanges();
		}
		/// <inheritdoc />
		public virtual void Update(TEntity item)
		{
			var entry = Context.Entry(item);

			if (entry.State != EntityState.Modified)
				entry.State = EntityState.Modified;

			Context.SaveChanges();
		}
		/// <inheritdoc />
		public Task UpdateAsync(TEntity item, CancellationToken cancellationToken = default)
		{
			var entry = Context.Entry(item);

			if (entry.State != EntityState.Modified)
				entry.State = EntityState.Modified;

			return Context.SaveChangesAsync();
		}
		/// <inheritdoc />
		public virtual void Delete(TEntity item)
		{
			dbSet.Remove(item);
			Context.SaveChanges();
		}
		/// <inheritdoc />
		public virtual Task DeleteAsync(TEntity item, CancellationToken cancellationToken = default)
		{
			dbSet.Remove(item);
			return Context.SaveChangesAsync();
		}
		/// <inheritdoc />
		public virtual IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
			=> dbSet.Where(predicate);
		/// <inheritdoc />
		public virtual TEntity Find(Expression<Func<TEntity, bool>> predicate)
			=> dbSet.FirstOrDefault(predicate);
		/// <inheritdoc />
		public virtual Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
			=> dbSet.FirstOrDefaultAsync(predicate);
		/// <summary>
		/// Dispose method, does nothing
		/// </summary>
		[ExcludeFromCodeCoverage]
		public virtual void Dispose()
		{
		}
	}
	/// <summary>
	/// Database Repository with context type
	/// </summary>
	/// <typeparam name="TEntity"></typeparam>
	/// <typeparam name="TDbContext"></typeparam>
	[ExcludeFromCodeCoverage]
	public class DbRepository<TEntity, TDbContext> : DbRepository<TEntity>
		where TDbContext : DbContext
		where TEntity : class
	{
		/// <summary>
		/// constructor
		/// </summary>
		/// <param name="context"></param>
		public DbRepository(TDbContext context)
			: base(context)
		{
		}
	}
}
