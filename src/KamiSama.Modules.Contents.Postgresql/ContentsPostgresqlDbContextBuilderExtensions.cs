using KamiSama.Modules.Contents.Repositories.Database;
using KamiSama.Modules.Contents.Repositories.Database.Postgresql;
using KamiSama.Repositories.EntityFrameworkCore;
using KamiSama.Repositories.EntityFrameworkCore.Postgresql;

namespace KamiSama.Modules.Contents;

/// <summary>
/// Adds the concrete PostgreSQL Contents context to the multi-provider registration built by the Core module.
/// </summary>
public static class ContentsPostgresqlDbContextBuilderExtensions
{
	/// <summary>
	/// Registers <see cref="PostgresqlContentsDbContext"/> and exposes it under the exact <c>postgresql</c> keyed <see cref="ContentsDbContext"/> service.
	/// </summary>
	/// <param name="builder">The Contents context builder created during <c>AddContentsModule</c> service configuration.</param>
	/// <returns>The same builder for fluent registration.</returns>
	/// <remarks>The underlying provider enables lazy-loading proxies, applies the Contents migration-history table and migrations, and uses the configured connection string.</remarks>
	public static IMultiProviderDbContextBuilder<ContentsDbContext> AddPostgresql(
		this IMultiProviderDbContextBuilder<ContentsDbContext> builder)
	{
		builder.AddPostgresql<ContentsDbContext, PostgresqlContentsDbContext>();
		return builder;
	}
}
