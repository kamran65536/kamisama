using KamiSama.Modules.PolicyEngine.Repositories.Database;
using KamiSama.Modules.PolicyEngine.Repositories.Database.Sqlite;
using KamiSama.Repositories.EntityFrameworkCore;
using KamiSama.Repositories.EntityFrameworkCore.Sqlite;

namespace KamiSama.Modules.PolicyEngine;

/// <summary>
/// Registers the SQLite PolicyEngine context with the multi-provider EF Core builder.
/// </summary>
public static class PolicyEngineSqliteDbContextBuilderExtensions
{
	/// <summary>
	/// Adds <see cref="SqlitePolicyEngineDbContext"/> and exposes it as the scoped
	/// <see cref="PolicyEngineDbContext"/> service under the exact <c>sqlite</c> key.
	/// </summary>
	/// <param name="builder">The PolicyEngine multi-provider builder carrying services, connection settings, and migration-history table.</param>
	/// <returns>The same builder so provider setup can be chained.</returns>
	/// <remarks>
	/// Registration enables lazy-loading proxies. This provider package currently contains no PolicyEngine migrations,
	/// so <c>MigrateAsync</c> cannot create the PolicyEngine schema.
	/// </remarks>
	public static IMultiProviderDbContextBuilder<PolicyEngineDbContext> AddSqlite(
		this IMultiProviderDbContextBuilder<PolicyEngineDbContext> builder)
	{
		builder.AddSqlite<PolicyEngineDbContext, SqlitePolicyEngineDbContext>();
		return builder;
	}
}
