using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Example.ProviderToken;

public static class ProviderTokenDatabaseExtensions
{
    public static IServiceCollection AddProviderTokenDatabase(
        this IServiceCollection services,
        string connectionString)
        => services.AddDbContext<ProviderTokenDatabaseContext>(options =>
            //#if (Provider == "Postgresql")
            options.UseNpgsql(connectionString, database => database.MigrationsAssembly(typeof(ProviderTokenDatabaseContext).Assembly.FullName)));
            //#elseif (Provider == "Sqlite")
            options.UseSqlite(connectionString, database => database.MigrationsAssembly(typeof(ProviderTokenDatabaseContext).Assembly.FullName)));
            //#elseif (Provider == "SqlServer")
            options.UseSqlServer(connectionString, database => database.MigrationsAssembly(typeof(ProviderTokenDatabaseContext).Assembly.FullName)));
            //#elseif (Provider == "Oracle")
            options.UseOracle(connectionString, database => database.MigrationsAssembly(typeof(ProviderTokenDatabaseContext).Assembly.FullName)));
            //#endif
}
