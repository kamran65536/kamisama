using KamiSama.Repositories.Initialization;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace KamiSama.Repositories.EntityFrameworkCore.Initialization;

/// <summary>
/// Data initializer for Entity Framework Core
/// </summary>
public abstract class DatabaseInitializerBase<TDbContext>(TDbContext context) : IDatabaseInitializer<TDbContext>
    where TDbContext : DbContext
{
    /// <summary>
    /// Migrates database to the latest version
    /// </summary>
    /// <remarks>This method is ONLY supported for relational database.</remarks>
    /// <returns></returns>
    protected virtual Task MigrateAsync(CancellationToken cancellationToken)
        => context.Database.MigrateAsync(cancellationToken);
    /// <summary>
    /// Initialize necessary data for the database
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    protected abstract Task InitializeDataAsync(CancellationToken cancellationToken);
    /// <summary>
    /// Initialize test data for the database
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    protected abstract Task InitializeTestDataAsync(CancellationToken cancellationToken);
    /// <inheritdoc />
    public async virtual Task InitializeAsync(DataInitializationOptions options, CancellationToken cancellationToken)
    {
        if (options.Migrate)
            await MigrateAsync(cancellationToken);
        if (options.InitializeData)
            await InitializeDataAsync(cancellationToken);
        if (options.InitializeTestData)
            await InitializeTestDataAsync(cancellationToken);
    }
    /// <summary>
    /// Safely adds an entity if it is not already exist
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <param name="predicate"></param>
    /// <param name="entity"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
	protected async Task<TEntity> TryAdd<TEntity>(Expression<Func<TEntity, bool>> predicate, TEntity entity, CancellationToken cancellationToken)
		where TEntity : class
	{
		var set = context.Set<TEntity>();
		var item = await set.FirstOrDefaultAsync(predicate, cancellationToken);

		if (item != null)
			return item;

		set.Add(entity);
		await context.SaveChangesAsync(cancellationToken);

		return entity;
	}
}
