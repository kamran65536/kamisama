using KamiSama.Repositories.Initialization;
using Microsoft.EntityFrameworkCore;
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
    protected abstract Task InitializeData(CancellationToken cancellationToken);
    /// <summary>
    /// Initialize test data for the database
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    protected abstract Task InitializeTestData(CancellationToken cancellationToken);
    /// <inheritdoc />
    public async virtual Task InitializeAsync(DataInitializationOptions options, CancellationToken cancellationToken)
    {
        if (options.Migrate)
            await MigrateAsync(cancellationToken);
        if (options.InitializeData)
            await InitializeData(cancellationToken);
        if (options.InitializeTestData)
            await InitializeTestData(cancellationToken);
    }
}
