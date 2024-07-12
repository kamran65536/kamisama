namespace Example.BoundedContext;

public static class ServiceCollectionExtensions
{
	public const string MigrationHistoryTable = "BoundedContext_History";
	private static IServiceCollection AddBoundedContextDbContext(
		this IServiceCollection services,
		string connectionString,
		string connectionProvider)
	{
		switch (connectionProvider?.ToLower())
		{
			default:
///#if (UseSqlite)
			case "sqlite":
				services.AddDbContext<Repositories.Database.Sqlite.SqliteBoundedContextDbContext>(opt =>
				{
					opt.UseLazyLoadingProxies();
					opt.UseSqlite(connectionString, x => x.MigrationsHistoryTable(MigrationHistoryTable))
						.ConfigureWarnings(w => w.Ignore(RelationalEventId.MultipleCollectionIncludeWarning));
				});
				services.AddScoped<BoundedContextDbContext>(sp => sp.GetRequiredService<Repositories.Database.Sqlite.SqliteBoundedContextDbContext>());
				break;
///#endif
///#if (UsePostgresql)
			case "postgresql":
				services.AddDbContext<Repositories.Database.Postgresql.PostgresqlBoundedContextDbContext>(opt =>
				{
					opt.UseLazyLoadingProxies();
					opt.UseNpgsql(connectionString, x => x.MigrationsHistoryTable(MigrationHistoryTable))
						.ConfigureWarnings(w => w.Ignore(RelationalEventId.MultipleCollectionIncludeWarning));
				});
				services.AddScoped<BoundedContextDbContext>(sp => sp.GetRequiredService<Repositories.Database.Postgresql.PostgresqlBoundedContextDbContext>());
				AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
				AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
				break;
///#endif
///#if (UseSqlServer)
			case "sqlserver":
				services.AddDbContext<Repositories.Database.SqlServer.SqlServerBoundedContextDbContext>(opt =>
				{
					opt.UseLazyLoadingProxies();
					opt.UseSqlServer(connectionString, x => x.MigrationsHistoryTable(MigrationHistoryTable))
						.ConfigureWarnings(w => w.Ignore(RelationalEventId.MultipleCollectionIncludeWarning));
				});
				services.AddScoped<BoundedContextDbContext>(sp => sp.GetRequiredService<Repositories.Database.SqlServer.SqlServerBoundedContextDbContext>());
				break;
///#endif
		}

		return services;
	}
	public static IServiceCollection AddBoundedContext(this IServiceCollection services, string connectionString, string connectionProvider)
	{
		services.AutoAddDependencies(typeof(ServiceCollectionExtensions).Assembly);
		services.AddAutoMapper(typeof(ServiceCollectionExtensions).Assembly);
		services.AddBoundedContextDbContext(connectionString, connectionProvider);

		return services;
	}
}
