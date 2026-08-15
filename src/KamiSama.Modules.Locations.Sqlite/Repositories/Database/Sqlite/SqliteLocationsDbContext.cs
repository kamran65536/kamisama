using KamiSama.Modules.Locations.Repositories.Database;
using Microsoft.EntityFrameworkCore;

namespace KamiSama.Modules.Locations.Repositories.Database.Sqlite;

/// <summary>
/// Provides the SQLite EF Core context targeted by the Locations SQLite migrations.
/// </summary>
/// <param name="options">The SQLite options configured by <c>AddSqliteLocationsDbContext</c>.</param>
public class SqliteLocationsDbContext(DbContextOptions<SqliteLocationsDbContext> options) : LocationsDbContext(options)
{
}
