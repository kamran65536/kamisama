using KamiSama.Modules.Ticketing.Repositories.Database;
using KamiSama.Modules.Ticketing.Repositories.Database.Sqlite;
using KamiSama.Repositories.EntityFrameworkCore;
using KamiSama.Repositories.EntityFrameworkCore.Sqlite;

namespace KamiSama.Modules.Ticketing;

public static class TicketingSqliteDbContextBuilderExtensions
{
	public static IMultiProviderDbContextBuilder<TicketingDbContext> AddSqliteTicketingDbContext(
		this IMultiProviderDbContextBuilder<TicketingDbContext> builder)
	{
		builder.AddSqlite<SqliteTicketingDbContext>();
		return builder;
	}
}
