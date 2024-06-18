using System.Threading;
using System.Threading.Tasks;

namespace KamiSama.Repositories.Initialization;

/// <summary>
/// Generic Data Initialization interface
/// </summary>
/// <typeparam name="TDbContext"></typeparam>
public interface IDatabaseInitializer<TDbContext>
{
    /// <summary>
    /// Initialize and migrates the database if necessary
    /// </summary>
    /// <param name="options"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task InitializeAsync(DataInitializationOptions options, CancellationToken cancellationToken);
}
