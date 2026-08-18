using KamiSama.Modules.Identity.Repositories.Database;
using KamiSama.Modules.Identity.Repositories.Database.Postgresql;
using KamiSama.Repositories.EntityFrameworkCore;
using KamiSama.Repositories.EntityFrameworkCore.Postgresql;

namespace KamiSama.Modules.Identity;

/// <summary>Adds the internal PostgreSQL Identity context to a multi-provider Identity context builder.</summary>
public static class IdentityPostgresqlDbContextBuilderExtensions
{
	/// <summary>Registers the PostgreSQL Identity context under the provider key used by the shared multi-provider infrastructure.</summary>
	/// <param name="builder">The Identity context builder returned by the Core module.</param>
	/// <returns>The same builder for fluent configuration.</returns>
	public static IMultiProviderDbContextBuilder<KamiSamaIdentityDbContext> AddPostgresql(
		this IMultiProviderDbContextBuilder<KamiSamaIdentityDbContext> builder)
	{
		builder.AddPostgresql<KamiSamaIdentityDbContext, PostgresqlKamiSamaIdentityDbContext>();
		return builder;
	}
}
