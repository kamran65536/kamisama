namespace Example.Repositories;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddRepositoriesForExample(this IServiceCollection services, string connectionString, string provider)
	{
		services.AutoAddDependencies(typeof(ServiceCollectionExtensions).Assembly);

		var assemblyName = typeof(ServiceCollectionExtensions).Assembly.GetName().Name;

		services.AddDbContext<ExampleDbContext>(opt =>
		{
			opt.UseLazyLoadingProxies();

			switch (provider?.ToLower())
			{
				default:
///#if (UseSqlite)
				case "sqlite":
					opt.UseSqlite(connectionString, x => x.MigrationsAssembly($"{assemblyName}.Sqlite"));
					break;
///#endif
///#if (UsePostgresql)
				case "postgresql":
					opt.UseNpgsql(connectionString, x => x.MigrationsAssembly($"{assemblyName}.Postgresql"));
					break;
///#endif
///#if (UseSqlServer)
				case "sqlserver":
					opt.UseSqlServer(connectionString, x => x.MigrationsAssembly($"{assemblyName}.SqlServer"));
					break;
///#endif
			}
		});

		return services;
	}
}
