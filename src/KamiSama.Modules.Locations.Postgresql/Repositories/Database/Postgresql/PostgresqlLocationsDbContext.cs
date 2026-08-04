using KamiSama.Modules.Locations.Repositories.Database;
using Microsoft.EntityFrameworkCore;

namespace KamiSama.Modules.Locations.Repositories.Database.Postgresql;

public class PostgresqlLocationsDbContext(DbContextOptions<PostgresqlLocationsDbContext> options) : LocationsDbContext(options)
{
}
