using KamiSama.Modules.PolicyEngine.Repositories.Database;
using KamiSama.Modules.PolicyEngine.Repositories.Database.Postgresql;
using KamiSama.Repositories.EntityFrameworkCore;
using KamiSama.Repositories.EntityFrameworkCore.Postgresql;

namespace KamiSama.Modules.PolicyEngine;

/// <summary>
/// Registers the PostgreSQL PolicyEngine context with the multi-provider EF Core builder.
/// </summary>
public static class PolicyEnginePostgresqlDbContextBuilderExtensions
{
	/// <summary>
	/// Adds <see cref="PostgresqlPolicyEngineDbContext"/> and exposes it as the scoped
	/// <see cref="PolicyEngineDbContext"/> service under the exact <c>postgresql</c> key.
	/// </summary>
	/// <param name="builder">The PolicyEngine multi-provider builder carrying services, connection settings, and migration-history table.</param>
	/// <returns>The same builder so provider setup can be chained.</returns>
	/// <remarks>
	/// Registration enables lazy-loading proxies and the shared PostgreSQL compatibility switches. This provider package
	/// currently contains no PolicyEngine migrations, so <c>MigrateAsync</c> cannot create the PolicyEngine schema.
	/// </remarks>
	public static IMultiProviderDbContextBuilder<PolicyEngineDbContext> AddPostgresqlPolicyEngineDbContext(
		this IMultiProviderDbContextBuilder<PolicyEngineDbContext> builder)
	{
		builder.AddPostgresql<PostgresqlPolicyEngineDbContext>();
		return builder;
	}
}
