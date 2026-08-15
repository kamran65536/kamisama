using KamiSama.Modules.Identity.Repositories.Database;
using KamiSama.Modules.Identity.Repositories.Database.Sqlite;
using KamiSama.Repositories.EntityFrameworkCore;
using KamiSama.Repositories.EntityFrameworkCore.Sqlite;

namespace KamiSama.Modules.Identity;

/// <summary>Adds the internal SQLite Identity context to a multi-provider Identity context builder.</summary>
public static class IdentitySqliteDbContextBuilderExtensions
{
	/// <summary>Registers the SQLite Identity context under the provider key used by the shared multi-provider infrastructure.</summary>
	/// <param name="builder">The Identity context builder returned by the Core module.</param>
	/// <returns>The same builder for fluent configuration.</returns>
	public static IMultiProviderDbContextBuilder<KamiSamaIdentityDbContext> AddSqliteIdentityDbContext(
		this IMultiProviderDbContextBuilder<KamiSamaIdentityDbContext> builder)
	{
		builder.AddSqlite<SqliteKamiSamaIdentityDbContext>();
		return builder;
	}
}
