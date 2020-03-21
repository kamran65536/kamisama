using System;
using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KamiSama.Repositories.EntityFramework
{
	/// <summary>
	/// Database Repository for entity framework
	/// </summary>
	/// <typeparam name="TEntity"></typeparam>
	public class DbRepository<TEntity> : IQueryableRepository<TEntity>, IAsyncQueryableRepository<TEntity>
		where TEntity : class

	{
		/// <summary>
		/// internal context class
		/// </summary>
		private readonly DbContext context;
		private readonly DbSet<TEntity> dbSet;
		/// <summary>
		/// initiates an db repository
		/// </summary>
		/// <param name="context"></param>
		public DbRepository(DbContext context)
		{
			this.context = context;
			this.dbSet = context.Set<TEntity>();
		}
		/// <summary>
		/// Adds an item into the repository
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public Task AddAsync(TEntity item)
		{
			dbSet.Add(item);
			return context.SaveChangesAsync();
		}
		/// <summary>
		/// Adds an item into the repository
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public virtual void Add(TEntity item)
		{
			dbSet.Add(item);
			context.SaveChanges();
		}
		/// <summary>
		/// Updates an item in the repositry
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public virtual void Update(TEntity item)
		{
			var entry = context.Entry(item);

			if (entry.State != EntityState.Modified)
				entry.State = EntityState.Modified;

			context.SaveChanges();
		}
		/// <summary>
		/// Updates an item in the repositry
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public Task UpdateAsync(TEntity item)
		{
			var entry = context.Entry(item);

			if (entry.State != EntityState.Modified)
				entry.State = EntityState.Modified;

			return context.SaveChangesAsync();
		}
		/// <summary>
		/// Deletes an item from repository
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public virtual void Delete(TEntity item)
		{
			dbSet.Remove(item);
			context.SaveChanges();
		}
		/// <summary>
		/// Deletes an item from repository
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public virtual Task DeleteAsync(TEntity item)
		{
			dbSet.Remove(item);
			return context.SaveChangesAsync();
		}
		/// <summary>
		/// Queries items in repository for the predicate specified
		/// </summary>
		/// <param name="predicate">the predicate to search, if null it returns all items</param>
		/// <returns></returns>
		public virtual IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
			=> dbSet.Where(predicate);
		/// <summary>
		/// Finds an item in the repository
		/// </summary>
		/// <param name="predicate"></param>
		/// <returns></returns>
		public virtual TEntity Find(Expression<Func<TEntity, bool>> predicate)
			=> dbSet.FirstOrDefault(predicate);
		/// <summary>
		/// Finds an item in the repository
		/// </summary>
		/// <param name="predicate"></param>
		/// <returns></returns>
		public virtual Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate)
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
		where TEntity: class
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
