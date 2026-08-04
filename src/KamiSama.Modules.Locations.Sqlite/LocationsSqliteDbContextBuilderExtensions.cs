using KamiSama.Modules.Locations.Repositories.Database;
using KamiSama.Modules.Locations.Repositories.Database.Sqlite;
using KamiSama.Repositories.EntityFrameworkCore;
using KamiSama.Repositories.EntityFrameworkCore.Sqlite;

namespace KamiSama.Modules.Locations;

public static class LocationsSqliteDbContextBuilderExtensions
{
	public static IMultiProviderDbContextBuilder<LocationsDbContext> AddSqliteLocationsDbContext(
		this IMultiProviderDbContextBuilder<LocationsDbContext> builder)
	{
		builder.AddSqlite<SqliteLocationsDbContext>();
		return builder;
	}
}
