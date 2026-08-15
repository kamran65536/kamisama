using KamiSama.Modules.Ticketing.Repositories.Database;
using Microsoft.EntityFrameworkCore;

namespace KamiSama.Modules.Ticketing.Repositories.Database.Postgresql;

/// <summary>
/// Provides the concrete PostgreSQL EF Core context targeted by the Ticketing PostgreSQL migrations.
/// Normal hosts register it through <c>AddPostgresqlTicketingDbContext</c> rather than constructing it directly.
/// </summary>
/// <param name="options">The PostgreSQL EF Core options configured from Ticketing database settings.</param>
public class PostgresqlTicketingDbContext(DbContextOptions<PostgresqlTicketingDbContext> options) : TicketingDbContext(options)
{
}
