using KamiSama.Extensions.WebModules;
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

internal class TicketingModule(
	IConfigurationSection moduleSection,
	IConfigurationSection databaseSection,
	Action<IMultiProviderDbContextBuilder<TicketingDbContext>>? configureDbContext = null) : WebModule
{
    public const string ModuleName = "Ticketing";
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
public static class ExtendedWebApplicationBuilderExtensions
{
    public static ExtendedWebApplicationBuilder AddTicketingModule(
		this ExtendedWebApplicationBuilder builder,
		IConfigurationSection moduleSection,
		IConfigurationSection databaseSection,
		Action<IMultiProviderDbContextBuilder<TicketingDbContext>>? configureDbContext = null)
        => builder.AddModule(new TicketingModule(moduleSection, databaseSection, configureDbContext));
}
