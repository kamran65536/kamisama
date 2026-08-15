using KamiSama.Modules;
using KamiSama.Extensions.DependencyInjection;
using KamiSama.Modules.ServicePlans.Repositories.Database;
using KamiSama.Repositories;
using KamiSama.Repositories.EntityFrameworkCore;
using KamiSama.Repositories.EntityFrameworkCore.Initialization;
using KamiSama.Repositories.Initialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace KamiSama.Modules.ServicePlans;

/// <summary>
/// Registers ServicePlans options, scoped repositories and features, a keyed EF Core provider, and post-build database initialization.
/// The module does not map controllers, endpoints, middleware, authentication, or authorization.
/// </summary>
/// <param name="moduleSection">The ServicePlans configuration section containing <c>options</c> and <c>initialization</c> children.</param>
/// <param name="databaseSection">The database section containing the provider key and connection string.</param>
/// <param name="configureDbContext">The callback that registers installed concrete provider contexts; it is required in a normal host.</param>
public class ServicePlansWebModule(
	IConfigurationSection moduleSection,
	IConfigurationSection databaseSection,
	Action<IMultiProviderDbContextBuilder<ServicePlansDbContext>>? configureDbContext = null) : WebModule
{
	/// <summary>
	/// Identifies the named database and initialization options used by this module.
	/// </summary>
	public const string ModuleName = "ServicePlans";

	/// <summary>
	/// Binds module and named database options, discovers attributed Core services, and invokes the provider callback.
	/// </summary>
	/// <param name="services">The service collection configured before the application is built.</param>
	public override void ConfigureServices(IServiceCollection services)
	{
		services.Configure<ServicePlansOptions>(moduleSection.GetSection("options"));
		services.Configure<ConnectionStringOption>(ModuleName, databaseSection);
		services.Configure<DataInitializationOptions>(ModuleName, moduleSection.GetSection("initialization"));
		services.AutoAddDependenciesFrom<ServicePlansDbContext>();

		var dbContextBuilder = services
			.AddMultiProviderDbContext<ServicePlansDbContext>(databaseSection)
			.WithMigrationHistoryTable($"{HistoryRepository.DefaultTableName}_{ModuleName}");
		configureDbContext?.Invoke(dbContextBuilder);
	}

	/// <summary>
	/// Resolves a custom or migration-only database initializer and executes the enabled initialization stages after build.
	/// </summary>
	/// <param name="app">The built application whose scoped services are used for initialization.</param>
	/// <param name="cancellationToken">A token that can cancel initialization.</param>
	/// <returns>A task that represents the configured database initialization.</returns>
	public override async Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken)
	{
		using var scope = app.Services.CreateScope();
		var initializer = scope.ServiceProvider.GetService<IDatabaseInitializer<ServicePlansDbContext>>()
			?? new DefaultDatabaseInitializer<ServicePlansDbContext>(scope.ServiceProvider.GetRequiredService<ServicePlansDbContext>());
		var options = scope.ServiceProvider.GetRequiredService<IOptionsSnapshot<DataInitializationOptions>>().Get(ModuleName);

		await initializer.InitializeAsync(options, cancellationToken);
	}
}

/// <summary>
/// Adds the ServicePlans web module to an extended ASP.NET Core builder.
/// </summary>
public static class ExtendedWebApplicationBuilderExtensions
{
	/// <summary>
	/// Queues ServicePlans service registration and post-build initialization on the extended builder.
	/// </summary>
	/// <param name="builder">The extended builder that receives the module.</param>
	/// <param name="moduleSection">The ServicePlans configuration section.</param>
	/// <param name="databaseSection">The database provider and connection-string section.</param>
	/// <param name="configureDbContext">The callback that registers the selected provider context; normal setup requires it.</param>
	/// <returns>The same extended builder for fluent module composition.</returns>
	public static ExtendedWebApplicationBuilder AddServicePlansModule(
		this ExtendedWebApplicationBuilder builder,
		IConfigurationSection moduleSection,
		IConfigurationSection databaseSection,
		Action<IMultiProviderDbContextBuilder<ServicePlansDbContext>>? configureDbContext = null)
		=> builder.AddModule(new ServicePlansWebModule(moduleSection, databaseSection, configureDbContext));
}
