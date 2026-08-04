using KamiSama.Extensions.WebModules;
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

public static class ExtendedWebApplicationBuilderExtensions
{
	public static ExtendedWebApplicationBuilder AddLocationsModule(
		this ExtendedWebApplicationBuilder builder,
		IConfigurationSection moduleSection,
		IConfigurationSection databaseSection,
		Action<IMultiProviderDbContextBuilder<LocationsDbContext>>? configureDbContext = null)
		=> builder.AddModule(new LocationsModule(moduleSection, databaseSection, configureDbContext));
}
