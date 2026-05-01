using Microsoft.EntityFrameworkCore;

namespace KamiSama.Repositories.EntityFrameworkCore.Initialization;

/// <summary>
/// Default Initializer, applies migration based on options
/// </summary>
public class DefaultDatabaseInitializer<TDbContext>(TDbContext context) : DatabaseInitializerBase<TDbContext>(context)
    where TDbContext : DbContext
{
	/// <inheritdoc />
	protected override Task InitializeDataAsync(CancellationToken cancellationToken)
	{
		return Task.CompletedTask;
	}
	/// <inheritdoc />
	protected override Task InitializeTestDataAsync(CancellationToken cancellationToken)
	{
		return Task.CompletedTask;
	}
}
