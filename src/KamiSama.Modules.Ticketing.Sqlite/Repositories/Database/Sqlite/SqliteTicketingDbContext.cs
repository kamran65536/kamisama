using KamiSama.Modules.Ticketing.Repositories.Database;
using Microsoft.EntityFrameworkCore;

namespace KamiSama.Modules.Ticketing.Repositories.Database.Sqlite;

public class SqliteTicketingDbContext(DbContextOptions<SqliteTicketingDbContext> options) : TicketingDbContext(options)
{
}
