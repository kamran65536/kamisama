using KamiSama.Modules.Locations.Repositories.Database;
using Microsoft.EntityFrameworkCore;

namespace KamiSama.Modules.Locations.Repositories.Database.Postgresql;

/// <summary>
/// Provides the PostgreSQL EF Core context targeted by the Locations PostgreSQL migrations.
/// </summary>
/// <param name="options">The PostgreSQL options configured by <c>AddPostgresqlLocationsDbContext</c>.</param>
public class PostgresqlLocationsDbContext(DbContextOptions<PostgresqlLocationsDbContext> options) : LocationsDbContext(options)
{
}
