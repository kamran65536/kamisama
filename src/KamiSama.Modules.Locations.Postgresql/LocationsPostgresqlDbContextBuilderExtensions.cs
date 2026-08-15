using KamiSama.Modules.Locations.Repositories.Database;
using KamiSama.Modules.Locations.Repositories.Database.Postgresql;
using KamiSama.Repositories.EntityFrameworkCore;
using KamiSama.Repositories.EntityFrameworkCore.Postgresql;

namespace KamiSama.Modules.Locations;

/// <summary>
/// Adds the concrete PostgreSQL Locations context to the multi-provider registration built by the Core module.
/// </summary>
public static class LocationsPostgresqlDbContextBuilderExtensions
{
	/// <summary>
	/// Registers <see cref="PostgresqlLocationsDbContext"/> and exposes it under the exact <c>postgresql</c> keyed <see cref="LocationsDbContext"/> service.
	/// </summary>
	/// <param name="builder">The Locations context builder created during <c>AddLocationsModule</c> service configuration.</param>
	/// <returns>The same builder for fluent registration.</returns>
	/// <remarks>The underlying provider enables lazy-loading proxies, applies the Locations migration-history table, and uses the configured connection string.</remarks>
	public static IMultiProviderDbContextBuilder<LocationsDbContext> AddPostgresqlLocationsDbContext(
		this IMultiProviderDbContextBuilder<LocationsDbContext> builder)
	{
		builder.AddPostgresql<PostgresqlLocationsDbContext>();
		return builder;
	}
}
