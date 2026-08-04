using KamiSama.Modules.Ticketing.Repositories.Database;
using KamiSama.Modules.Ticketing.Repositories.Database.Postgresql;
using KamiSama.Repositories.EntityFrameworkCore;
using KamiSama.Repositories.EntityFrameworkCore.Postgresql;

namespace KamiSama.Modules.Ticketing;

public static class TicketingPostgresqlDbContextBuilderExtensions
{
	public static IMultiProviderDbContextBuilder<TicketingDbContext> AddPostgresqlTicketingDbContext(
		this IMultiProviderDbContextBuilder<TicketingDbContext> builder)
	{
		builder.AddPostgresql<PostgresqlTicketingDbContext>();
		return builder;
	}
}
