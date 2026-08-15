using Microsoft.EntityFrameworkCore;

namespace KamiSama.Modules.PolicyEngine.Repositories.Database.Sqlite;

/// <summary>
/// Provides the concrete SQLite EF Core context used by PolicyEngine repositories.
/// </summary>
/// <param name="options">The SQLite options configured by <c>AddSqlitePolicyEngineDbContext</c>.</param>
/// <remarks>
/// The provider package currently supplies no migrations for this context; applications must provision a compatible
/// schema separately before using the CRUD features.
/// </remarks>
public class SqlitePolicyEngineDbContext(DbContextOptions<SqlitePolicyEngineDbContext> options) : PolicyEngineDbContext(options)
{
}
