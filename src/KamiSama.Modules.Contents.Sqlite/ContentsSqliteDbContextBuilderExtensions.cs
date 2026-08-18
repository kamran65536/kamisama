using KamiSama.Modules.Contents.Repositories.Database;
using KamiSama.Modules.Contents.Repositories.Database.Sqlite;
using KamiSama.Repositories.EntityFrameworkCore;
using KamiSama.Repositories.EntityFrameworkCore.Sqlite;

namespace KamiSama.Modules.Contents;

/// <summary>
/// Adds the concrete SQLite Contents context to the multi-provider registration built by the Core module.
/// </summary>
public static class ContentsSqliteDbContextBuilderExtensions
{
	/// <summary>
	/// Registers <see cref="SqliteContentsDbContext"/> and exposes it under the exact <c>sqlite</c> keyed <see cref="ContentsDbContext"/> service.
	/// </summary>
	/// <param name="builder">The Contents context builder created during <c>AddContentsModule</c> service configuration.</param>
	/// <returns>The same builder for fluent registration.</returns>
	/// <remarks>The underlying provider enables lazy-loading proxies, applies the Contents migration-history table and migrations, and uses the configured connection string.</remarks>
	public static IMultiProviderDbContextBuilder<ContentsDbContext> AddSqlite(
		this IMultiProviderDbContextBuilder<ContentsDbContext> builder)
	{
		builder.AddSqlite<ContentsDbContext, SqliteContentsDbContext>();
		return builder;
	}
}
