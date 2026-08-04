using KamiSama.Modules.Locations.Repositories.Database;
using Microsoft.EntityFrameworkCore;

namespace KamiSama.Modules.Locations.Repositories.Database.Sqlite;

public class SqliteLocationsDbContext(DbContextOptions<SqliteLocationsDbContext> options) : LocationsDbContext(options)
{
}
