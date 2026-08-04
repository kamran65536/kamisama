using KamiSama.Modules.Ticketing.Repositories.Database;
using Microsoft.EntityFrameworkCore;

namespace KamiSama.Modules.Ticketing.Repositories.Database.Postgresql;

public class PostgresqlTicketingDbContext(DbContextOptions<PostgresqlTicketingDbContext> options) : TicketingDbContext(options)
{
}
