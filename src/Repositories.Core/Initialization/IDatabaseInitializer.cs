using System.Threading;
using System.Threading.Tasks;

namespace KamiSama.Repositories.Initialization;

/// <summary>
/// Defines database migration and seed-data initialization for a specific context type.
/// </summary>
/// <typeparam name="TDbContext">The database context type initialized by the implementation.</typeparam>
public interface IDatabaseInitializer<TDbContext>
{
    /// <summary>
    /// Runs the migration and seed stages selected by the supplied options.
    /// </summary>
    /// <param name="options">The stages the initializer should run.</param>
    /// <param name="cancellationToken">A token that can cancel initialization.</param>
    /// <returns>A task that represents database initialization.</returns>
    Task InitializeAsync(DataInitializationOptions options, CancellationToken cancellationToken);
}
