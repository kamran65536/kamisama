using KamiSama.Modules;
using KamiSama.Repositories.EntityFrameworkCore;
using KamiSama.Repositories.EntityFrameworkCore.Initialization;
using KamiSama.Repositories.Initialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace KamiSama.Modules.Locations;

internal class LocationsModule(
	IConfigurationSection moduleSection,
	IConfigurationSection databaseSection,
	Action<IMultiProviderDbContextBuilder<LocationsDbContext>>? configureDbContext = null) : WebModule
{
	public const string ModuleName = "Locations";

	public override void ConfigureServices(IServiceCollection services)
	{
		services.AddMemoryCache();
		services.Configure<DataInitializationOptions>(ModuleName, moduleSection.GetSection("initialization"));

		services.AutoAddDependenciesFrom<LocationsDbContext>();
		var dbContextBuilder = services
			.AddMultiProviderDbContext<LocationsDbContext>(databaseSection)
			.WithMigrationHistoryTable($"__EFMigrationsHistory_{ModuleName}");
		configureDbContext?.Invoke(dbContextBuilder);
	}

	public override async Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken)
	{
		using var scope = app.Services.CreateScope();

		var initializer =
			scope.ServiceProvider.GetService<IDatabaseInitializer<LocationsDbContext>>()
			?? new DefaultDatabaseInitializer<LocationsDbContext>(scope.ServiceProvider.GetRequiredService<LocationsDbContext>());

		var options = scope.ServiceProvider.GetRequiredService<IOptionsSnapshot<DataInitializationOptions>>().Get(ModuleName);

		await initializer.InitializeAsync(options, cancellationToken);
	}
}

/// <summary>
/// Provides modular ASP.NET Core registration for the province and city implementation.
/// </summary>
public static class ExtendedWebApplicationBuilderExtensions
{
	/// <summary>
	/// Adds Locations memory caching, scoped feature and repository discovery, provider-neutral DbContext registration, and post-build database initialization.
	/// </summary>
	/// <param name="builder">The extended application builder that queues the Locations module.</param>
	/// <param name="moduleSection">The Locations module section; its <c>initialization</c> child binds the named migration and seed options.</param>
	/// <param name="databaseSection">The section containing required <c>provider</c> and <c>connection-string</c> values.</param>
	/// <param name="configureDbContext">The provider-registration callback. Although nullable for API compatibility, it is required in a normal host so the configured keyed <see cref="LocationsDbContext"/> can be resolved.</param>
	/// <returns>The same extended builder for fluent module composition.</returns>
	/// <remarks>
	/// Register the PostgreSQL or SQLite provider matching the configured provider key, then call <c>BuildAsync</c> before resolving Locations features.
	/// During the post-build phase the module resolves a custom named <c>IDatabaseInitializer&lt;LocationsDbContext&gt;</c>, or falls back to migration-only initialization.
	/// This module registers services only; it does not add controllers, endpoints, or authorization.
	/// </remarks>
	public static ExtendedWebApplicationBuilder AddLocationsModule(
		this ExtendedWebApplicationBuilder builder,
		IConfigurationSection moduleSection,
		IConfigurationSection databaseSection,
		Action<IMultiProviderDbContextBuilder<LocationsDbContext>>? configureDbContext = null)
		=> builder.AddModule(new LocationsModule(moduleSection, databaseSection, configureDbContext));
}
