using KamiSama.Modules.Ticketing.Repositories.Database;
using Microsoft.EntityFrameworkCore;

namespace KamiSama.Modules.Ticketing.Repositories.Database.Sqlite;

/// <summary>
/// Provides the concrete SQLite EF Core context targeted by the Ticketing SQLite migrations.
/// Normal hosts register it through <c>AddSqliteTicketingDbContext</c> rather than constructing it directly.
/// </summary>
/// <param name="options">The SQLite EF Core options configured from Ticketing database settings.</param>
public class SqliteTicketingDbContext(DbContextOptions<SqliteTicketingDbContext> options) : TicketingDbContext(options)
{
}
