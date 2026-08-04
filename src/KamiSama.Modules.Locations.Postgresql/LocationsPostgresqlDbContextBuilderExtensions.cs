using KamiSama.Modules.Locations.Repositories.Database;
using KamiSama.Modules.Locations.Repositories.Database.Postgresql;
using KamiSama.Repositories.EntityFrameworkCore;
using KamiSama.Repositories.EntityFrameworkCore.Postgresql;

namespace KamiSama.Modules.Locations;

public static class LocationsPostgresqlDbContextBuilderExtensions
{
	public static IMultiProviderDbContextBuilder<LocationsDbContext> AddPostgresqlLocationsDbContext(
		this IMultiProviderDbContextBuilder<LocationsDbContext> builder)
	{
		builder.AddPostgresql<PostgresqlLocationsDbContext>();
		return builder;
	}
}
