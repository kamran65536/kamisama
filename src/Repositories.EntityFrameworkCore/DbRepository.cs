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
	/// <remarks>
	/// initiates an db repository
	/// </remarks>
	/// <param name="context"></param>
	public class DbRepository<TEntity>(DbContext context) : IQueryableRepository<TEntity>, IAsyncQueryableRepository<TEntity>
		where TEntity : class

	{
		/// <summary>
		/// context class
		/// </summary>
		protected DbContext Context { get; } = context;
		private readonly DbSet<TEntity> dbSet = context.Set<TEntity>();

		/// <inheritdoc />
		public virtual Task AddAsync(TEntity item, CancellationToken cancellationToken)
		{
			dbSet.Add(item);
			return Context.SaveChangesAsync(cancellationToken);
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
		public virtual Task UpdateAsync(TEntity item, CancellationToken cancellationToken)
		{
			var entry = Context.Entry(item);

			if (entry.State != EntityState.Modified)
				entry.State = EntityState.Modified;

			return Context.SaveChangesAsync(cancellationToken);
		}
		/// <inheritdoc />
		public virtual void Delete(TEntity item)
		{
			dbSet.Remove(item);
			Context.SaveChanges();
		}
		/// <inheritdoc />
		public virtual Task DeleteAsync(TEntity item, CancellationToken cancellationToken)
		{
			dbSet.Remove(item);
			return Context.SaveChangesAsync(cancellationToken);
		}
		/// <inheritdoc />
		public virtual IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
			=> dbSet.Where(predicate);
		/// <summary>
		/// Checks if any entity exists in the repository
		/// </summary>
		/// <returns></returns>
		public virtual Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
			=> dbSet.AnyAsync(predicate, cancellationToken);
		/// <inheritdoc />
		public virtual TEntity? Find(Expression<Func<TEntity, bool>> predicate)
			=> dbSet.FirstOrDefault(predicate);
		/// <inheritdoc />
		public virtual Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
			=> dbSet.FirstOrDefaultAsync(predicate, cancellationToken)!;
		/// <summary>
		/// Dispose method, does nothing
		/// </summary>
		[ExcludeFromCodeCoverage]
		public virtual void Dispose()
		{
			GC.SuppressFinalize(this);
		}
	}
	/// <summary>
	/// Database Repository with context type
	/// </summary>
	/// <typeparam name="TEntity"></typeparam>
	/// <typeparam name="TDbContext"></typeparam>
	/// <remarks>
	/// constructor
	/// </remarks>
	/// <param name="context"></param>
	[ExcludeFromCodeCoverage]
	public class DbRepository<TEntity, TDbContext>(TDbContext context) : DbRepository<TEntity>(context)
		where TDbContext : DbContext
		where TEntity : class
	{
        /// <summary>
        /// Inner Context
        /// </summary>
        protected new TDbContext Context => (TDbContext)base.Context;
	}
}
