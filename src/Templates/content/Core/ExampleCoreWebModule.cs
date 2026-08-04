//#if (IncludeDatabase)
//#if (IncludeOracle)
using ExampleCore.Repositories.Database.Oracle;
//#endif
//#if (IncludePostgresql)
using ExampleCore.Repositories.Database.Postgresql;
//#endif
//#if (IncludeSqlite)
using ExampleCore.Repositories.Database.Sqlite;
//#endif
//#if (IncludeSqlServer)
using ExampleCore.Repositories.Database.SqlServer;
//#endif
using KamiSama.Repositories;
using KamiSama.Repositories.EntityFrameworkCore.Initialization;
using KamiSama.Repositories.Initialization;
//#endif
using KamiSama.Extensions.WebModules;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
//#if (IncludeDatabase)
using Microsoft.Extensions.Options;
//#endif

namespace ExampleCore;

internal class ExampleCoreWebModule(IConfigurationSection moduleSection, IConfigurationSection databaseSection) : WebModule
{
	public const string ModuleName = "ExampleCore";

	public override void ConfigureServices(IServiceCollection services)
	{
		_ = moduleSection;
		_ = databaseSection;

		services.AddMemoryCache();
		//#if (IncludeOptions)
		services.Configure<ExampleCoreOptions>(moduleSection);
		//#endif

		//#if (IncludeDatabase)
		services.Configure<ConnectionStringOption>(ModuleName, databaseSection);
		services.Configure<DataInitializationOptions>(ModuleName, moduleSection.GetSection("initialization"));
		services.AutoAddDependenciesFrom<ExampleCoreDbContext>();
		services.AddDbContext<ExampleCoreDbContext>((_, options) =>
		{
			var connectionString = databaseSection.GetConnectionString("Default")
				?? databaseSection["connectionString"]
				?? throw new InvalidOperationException("Database connection string is not configured.");

			switch ((databaseSection["provider"] ?? string.Empty).ToLowerInvariant())
			{
				//#if (IncludePostgresql)
				case "postgresql":
				case "postgres":
					options.UseNpgsql(connectionString);
					break;
				//#endif
				//#if (IncludeSqlite)
				case "sqlite":
					options.UseSqlite(connectionString);
					break;
				//#endif
				//#if (IncludeSqlServer)
				case "sqlserver":
				case "mssql":
					options.UseSqlServer(connectionString);
					break;
				//#endif
				//#if (IncludeOracle)
				case "oracle":
					options.UseOracle(connectionString);
					break;
				//#endif
				default:
					throw new InvalidOperationException("Database provider is not configured or is not included in this project.");
			}
		});
		//#endif
	}

	public override async Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken)
	{
		//#if (IncludeDatabase)
		using var scope = app.Services.CreateScope();

		var initializer =
			scope.ServiceProvider.GetService<IDatabaseInitializer<ExampleCoreDbContext>>() ??
			new DefaultDatabaseInitializer<ExampleCoreDbContext>(scope.ServiceProvider.GetRequiredService<ExampleCoreDbContext>());

		var options = scope.ServiceProvider.GetRequiredService<IOptionsSnapshot<DataInitializationOptions>>().Get(ModuleName);

		await initializer.InitializeAsync(options, cancellationToken);
		//#else
		await Task.CompletedTask;
		//#endif
	}
}

public static class ExtendedWebApplicationBuilderExtensions
{
	public static ExtendedWebApplicationBuilder AddExampleCoreModule(this ExtendedWebApplicationBuilder builder, IConfigurationSection moduleSection, IConfigurationSection databaseSection)
		=> builder.AddModule(new ExampleCoreWebModule(moduleSection, databaseSection));
}
