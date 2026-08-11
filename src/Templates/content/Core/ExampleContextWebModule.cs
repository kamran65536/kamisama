//#if (IncludeDatabase)
//#if (IncludeOracle)
using ExampleNamespace.Repositories.Database.Oracle;
//#endif
//#if (IncludePostgresql)
using ExampleNamespace.Repositories.Database.Postgresql;
//#endif
//#if (IncludeSqlite)
using ExampleNamespace.Repositories.Database.Sqlite;
//#endif
//#if (IncludeSqlServer)
using ExampleNamespace.Repositories.Database.SqlServer;
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

namespace ExampleNamespace;

internal class ExampleContextWebModule(IConfigurationSection moduleSection, IConfigurationSection databaseSection) : WebModule
{
	public const string ModuleName = "ExampleContext";

	public override void ConfigureServices(IServiceCollection services)
	{
		_ = moduleSection;
		_ = databaseSection;

		services.AddMemoryCache();
		//#if (IncludeOptions)
		services.Configure<ExampleContextOptions>(moduleSection);
		//#endif

		//#if (IncludeDatabase)
		services.Configure<ConnectionStringOption>(ModuleName, databaseSection);
		services.Configure<DataInitializationOptions>(ModuleName, moduleSection.GetSection("initialization"));
		services.AutoAddDependenciesFrom<ExampleContextDbContext>();
		services.AddDbContext<ExampleContextDbContext>((_, options) =>
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
			scope.ServiceProvider.GetService<IDatabaseInitializer<ExampleContextDbContext>>() ??
			new DefaultDatabaseInitializer<ExampleContextDbContext>(scope.ServiceProvider.GetRequiredService<ExampleContextDbContext>());

		var options = scope.ServiceProvider.GetRequiredService<IOptionsSnapshot<DataInitializationOptions>>().Get(ModuleName);

		await initializer.InitializeAsync(options, cancellationToken);
		//#else
		await Task.CompletedTask;
		//#endif
	}
}

public static class ExtendedWebApplicationBuilderExtensions
{
	public static ExtendedWebApplicationBuilder AddExampleContextModule(this ExtendedWebApplicationBuilder builder, IConfigurationSection moduleSection, IConfigurationSection databaseSection)
		=> builder.AddModule(new ExampleContextWebModule(moduleSection, databaseSection));
}
