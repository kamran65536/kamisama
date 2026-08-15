using KamiSama.Modules.ServicePlans.Repositories.Database;
using Microsoft.EntityFrameworkCore;

namespace KamiSama.Modules.ServicePlans.Repositories.Database.Sqlite;

/// <summary>
/// Provides the concrete SQLite context registered for the ServicePlans <c>sqlite</c> provider key.
/// This provider package currently contains no ServicePlans migrations.
/// </summary>
/// <param name="options">The SQLite-configured EF Core options.</param>
public class SqliteServicePlansDbContext(DbContextOptions<SqliteServicePlansDbContext> options) : ServicePlansDbContext(options)
{
}
