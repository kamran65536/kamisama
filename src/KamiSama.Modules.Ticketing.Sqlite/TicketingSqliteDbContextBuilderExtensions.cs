using KamiSama.Modules.Ticketing.Repositories.Database;
using KamiSama.Modules.Ticketing.Repositories.Database.Sqlite;
using KamiSama.Repositories.EntityFrameworkCore;
using KamiSama.Repositories.EntityFrameworkCore.Sqlite;

namespace KamiSama.Modules.Ticketing;

/// <summary>
/// Registers the SQLite Ticketing context with the shared multi-provider context builder.
/// Use this extension from the callback passed to Ticketing Core setup.
/// </summary>
public static class TicketingSqliteDbContextBuilderExtensions
{
	/// <summary>
	/// Registers <see cref="SqliteTicketingDbContext"/> and exposes it as the exact <c>sqlite</c> keyed <see cref="TicketingDbContext"/> service.
	/// Registration enables lazy-loading proxies and uses the Ticketing migration-history table selected by Core.
	/// </summary>
	/// <param name="builder">The provider-neutral Ticketing context builder created by Core.</param>
	/// <returns>The same builder for additional provider registrations.</returns>
	public static IMultiProviderDbContextBuilder<TicketingDbContext> AddSqliteTicketingDbContext(
		this IMultiProviderDbContextBuilder<TicketingDbContext> builder)
	{
		builder.AddSqlite<SqliteTicketingDbContext>();
		return builder;
	}
}
