using KamiSama.Repositories.Initialization;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace KamiSama.Repositories.EntityFrameworkCore.Initialization;

/// <summary>
/// Coordinates optional EF Core migration, application-data seeding, and test-data seeding for one context.
/// </summary>
/// <typeparam name="TDbContext">The EF Core context type to migrate and seed.</typeparam>
/// <param name="context">The scoped context used by migration and seed operations.</param>
/// <remarks>Selected stages run sequentially in migration, application-data, then test-data order.</remarks>
[ExcludeFromCodeCoverage]
public abstract class DatabaseInitializerBase<TDbContext>(TDbContext context) : IDatabaseInitializer<TDbContext>
    where TDbContext : DbContext
{
    /// <summary>
    /// Applies all pending EF Core migrations.
    /// </summary>
    /// <param name="cancellationToken">A token that can cancel migration.</param>
    /// <returns>A task that represents migration.</returns>
    /// <remarks>This method is supported only by relational providers.</remarks>
    protected virtual Task MigrateAsync(CancellationToken cancellationToken)
        => context.Database.MigrateAsync(cancellationToken);
    /// <summary>
    /// Creates required application data when selected by the initialization options.
    /// </summary>
    /// <param name="cancellationToken">A token that can cancel application-data initialization.</param>
    /// <returns>A task that represents application-data initialization.</returns>
    protected abstract Task InitializeDataAsync(CancellationToken cancellationToken);
    /// <summary>
    /// Creates test data when selected by the initialization options.
    /// </summary>
    /// <param name="cancellationToken">A token that can cancel test-data initialization.</param>
    /// <returns>A task that represents test-data initialization.</returns>
    protected abstract Task InitializeTestDataAsync(CancellationToken cancellationToken);
    /// <summary>Runs each migration or seed stage enabled by the supplied options.</summary>
    /// <param name="options">The stages to run.</param>
    /// <param name="cancellationToken">A token passed to every selected stage.</param>
    /// <returns>A task that completes after all selected stages finish.</returns>
    /// <remarks>Stages are not wrapped in a transaction by this base class and stop at the first failure.</remarks>
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
    /// Returns an existing matching entity or adds and immediately saves a new entity.
    /// </summary>
	/// <typeparam name="TEntity">The entity type to query and seed.</typeparam>
	/// <param name="predicate">The expression used to identify an existing row.</param>
	/// <param name="entity">The entity to add when no row matches.</param>
	/// <param name="cancellationToken">A token that can cancel lookup or saving.</param>
	/// <returns>The existing tracked entity when found; otherwise, the newly saved entity.</returns>
	/// <remarks>The lookup and insert are separate operations and do not prevent concurrent duplicate inserts.</remarks>
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
