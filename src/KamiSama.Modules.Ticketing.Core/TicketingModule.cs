using KamiSama.Modules;
using KamiSama.Repositories;
using KamiSama.Repositories.EntityFrameworkCore;
using KamiSama.Repositories.EntityFrameworkCore.Initialization;
using KamiSama.Repositories.Initialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace KamiSama.Modules.Ticketing;

/// <summary>
/// Implements Ticketing's two-phase module lifecycle: service and provider registration before build, followed by configured database initialization.
/// This internal module does not map controllers, endpoints, or middleware.
/// </summary>
/// <param name="moduleSection">The Ticketing configuration section containing initialization settings.</param>
/// <param name="databaseSection">The database section containing provider and connection-string settings.</param>
/// <param name="configureDbContext">An optional concrete-provider registration callback.</param>
internal class TicketingModule(
	IConfigurationSection moduleSection,
	IConfigurationSection databaseSection,
	Action<IMultiProviderDbContextBuilder<TicketingDbContext>>? configureDbContext = null) : WebModule
{
    /// <summary>Identifies the named Ticketing options used for database connection and initialization settings.</summary>
    public const string ModuleName = "Ticketing";
    /// <summary>
    /// Binds named database and initialization options, scans the Core assembly for attributed services, and creates the multi-provider context builder.
    /// The optional callback must normally register a provider whose exact key matches the configured provider after lowercasing.
    /// </summary>
    /// <param name="services">The application service collection configured before the host is built.</param>
    public override void ConfigureServices(IServiceCollection services)
	{
        services.Configure<ConnectionStringOption>(ModuleName, databaseSection);
        services.Configure<DataInitializationOptions>(ModuleName, moduleSection.GetSection("initialization"));

        services.AutoAddDependenciesFrom<TicketingDbContext>();
        var dbContextBuilder = services
            .AddMultiProviderDbContext<TicketingDbContext>(databaseSection)
			.WithMigrationHistoryTable($"{HistoryRepository.DefaultTableName}_{ModuleName}");
		configureDbContext?.Invoke(dbContextBuilder);
    }

	/// <summary>
	/// Resolves a custom or default Ticketing database initializer in a scope and runs the migration and seed stages selected by named options.
	/// The module maps no controllers, endpoints, or middleware during this phase.
	/// </summary>
	/// <param name="app">The built application whose service provider supplies the context and initializer.</param>
	/// <param name="cancellationToken">The token forwarded to database initialization.</param>
	/// <returns>A task that completes when configured initialization has finished.</returns>
	public override async Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken)
	{
        using var scope = app.Services.CreateScope();

        var initializer =
            scope.ServiceProvider.GetService<IDatabaseInitializer<TicketingDbContext>>()
			?? new DefaultDatabaseInitializer<TicketingDbContext>(scope.ServiceProvider.GetRequiredService<TicketingDbContext>());

        var options = scope.ServiceProvider.GetRequiredService<IOptionsSnapshot<DataInitializationOptions>>().Get(ModuleName);

        await initializer.InitializeAsync(options, cancellationToken);
    }
}
/// <summary>
/// Adds Ticketing Core registration and database initialization to the KamiSama extended application builder.
/// Call <see cref="AddTicketingModule"/> before the extended builder is built.
/// </summary>
public static class ExtendedWebApplicationBuilderExtensions
{
    /// <summary>
    /// Queues Ticketing service registration and post-build database initialization.
    /// The provider callback is nullable in the API but is required in practice unless the host separately registers the configured keyed <see cref="TicketingDbContext"/>.
    /// </summary>
    /// <param name="builder">The extended application builder that receives the Ticketing module.</param>
    /// <param name="moduleSection">The Ticketing section whose <c>initialization</c> child controls migration and seed stages.</param>
    /// <param name="databaseSection">The section containing the required <c>provider</c> and <c>connection-string</c> values.</param>
    /// <param name="configureDbContext">An optional callback that registers installed concrete Ticketing providers.</param>
    /// <returns>The same extended builder for fluent composition.</returns>
    public static ExtendedWebApplicationBuilder AddTicketingModule(
		this ExtendedWebApplicationBuilder builder,
		IConfigurationSection moduleSection,
		IConfigurationSection databaseSection,
		Action<IMultiProviderDbContextBuilder<TicketingDbContext>>? configureDbContext = null)
        => builder.AddModule(new TicketingModule(moduleSection, databaseSection, configureDbContext));
}
