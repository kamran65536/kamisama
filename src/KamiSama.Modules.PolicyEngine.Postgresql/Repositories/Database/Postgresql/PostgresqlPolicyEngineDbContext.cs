using Microsoft.EntityFrameworkCore;

namespace KamiSama.Modules.PolicyEngine.Repositories.Database.Postgresql;

/// <summary>
/// Provides the concrete PostgreSQL EF Core context used by PolicyEngine repositories.
/// </summary>
/// <param name="options">The PostgreSQL options configured by <c>AddPostgresqlPolicyEngineDbContext</c>.</param>
/// <remarks>
/// The provider package currently supplies no migrations for this context; applications must provision a compatible
/// schema separately before using the CRUD features.
/// </remarks>
public class PostgresqlPolicyEngineDbContext(DbContextOptions<PostgresqlPolicyEngineDbContext> options) : PolicyEngineDbContext(options)
{
}
