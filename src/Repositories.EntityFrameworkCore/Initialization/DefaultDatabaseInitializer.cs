using Microsoft.EntityFrameworkCore;

namespace KamiSama.Repositories.EntityFrameworkCore.Initialization;

/// <summary>
/// Provides migration-only initialization while treating both seed-data stages as completed no-ops.
/// </summary>
/// <typeparam name="TDbContext">The EF Core context type to migrate.</typeparam>
/// <param name="context">The scoped context used for migration.</param>
/// <remarks>Set <c>Migrate</c> to run migrations; the application-data and test-data options perform no work.</remarks>
public class DefaultDatabaseInitializer<TDbContext>(TDbContext context) : DatabaseInitializerBase<TDbContext>(context)
    where TDbContext : DbContext
{
	/// <summary>Completes without creating application data.</summary>
	/// <param name="cancellationToken">Unused because this implementation performs no work.</param>
	/// <returns>A completed task.</returns>
	protected override Task InitializeDataAsync(CancellationToken cancellationToken)
	{
		return Task.CompletedTask;
	}
	/// <summary>Completes without creating test data.</summary>
	/// <param name="cancellationToken">Unused because this implementation performs no work.</param>
	/// <returns>A completed task.</returns>
	protected override Task InitializeTestDataAsync(CancellationToken cancellationToken)
	{
		return Task.CompletedTask;
	}
}
