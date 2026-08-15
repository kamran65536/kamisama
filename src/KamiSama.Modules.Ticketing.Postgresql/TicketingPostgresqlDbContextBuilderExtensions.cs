using KamiSama.Modules.Ticketing.Repositories.Database;
using KamiSama.Modules.Ticketing.Repositories.Database.Postgresql;
using KamiSama.Repositories.EntityFrameworkCore;
using KamiSama.Repositories.EntityFrameworkCore.Postgresql;

namespace KamiSama.Modules.Ticketing;

/// <summary>
/// Registers the PostgreSQL Ticketing context with the shared multi-provider context builder.
/// Use this extension from the callback passed to Ticketing Core setup.
/// </summary>
public static class TicketingPostgresqlDbContextBuilderExtensions
{
	/// <summary>
	/// Registers <see cref="PostgresqlTicketingDbContext"/> and exposes it as the exact <c>postgresql</c> keyed <see cref="TicketingDbContext"/> service.
	/// Registration enables lazy-loading proxies, uses the Ticketing migration-history table selected by Core, and applies the shared PostgreSQL provider's process-wide Npgsql switches.
	/// </summary>
	/// <param name="builder">The provider-neutral Ticketing context builder created by Core.</param>
	/// <returns>The same builder for additional provider registrations.</returns>
	public static IMultiProviderDbContextBuilder<TicketingDbContext> AddPostgresqlTicketingDbContext(
		this IMultiProviderDbContextBuilder<TicketingDbContext> builder)
	{
		builder.AddPostgresql<PostgresqlTicketingDbContext>();
		return builder;
	}
}
