using KamiSama.Modules.ServicePlans.Repositories.Database;
using Microsoft.EntityFrameworkCore;

namespace KamiSama.Modules.ServicePlans.Repositories.Database.Postgresql;

/// <summary>
/// Provides the concrete Npgsql context registered for the ServicePlans <c>postgresql</c> provider key.
/// This provider package currently contains no ServicePlans migrations.
/// </summary>
/// <param name="options">The Npgsql-configured EF Core options.</param>
public class PostgresqlServicePlansDbContext(DbContextOptions<PostgresqlServicePlansDbContext> options) : ServicePlansDbContext(options)
{
}
