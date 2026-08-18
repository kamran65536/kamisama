using KamiSama.Modules.Otp.Repositories.Database;
using KamiSama.Modules.Otp.Repositories.Database.Postgresql;
using KamiSama.Repositories.EntityFrameworkCore;
using KamiSama.Repositories.EntityFrameworkCore.Postgresql;

namespace KamiSama.Modules.Otp;

/// <summary>
/// Adds the concrete PostgreSQL Otp context to the multi-provider registration built by the Core module.
/// </summary>
public static class OtpPostgresqlDbContextBuilderExtensions
{
	/// <summary>
	/// Registers <see cref="PostgresqlOtpDbContext"/> and exposes it under the exact <c>postgresql</c> keyed <see cref="OtpDbContext"/> service.
	/// </summary>
	/// <param name="builder">The Otp context builder created during <c>AddOtpModule</c> service configuration.</param>
	/// <returns>The same builder for fluent registration.</returns>
	/// <remarks>The underlying provider enables lazy-loading proxies, applies the Otp migration-history table, and uses the configured connection string.</remarks>
	public static IMultiProviderDbContextBuilder<OtpDbContext> AddPostgresqlOtpDbContext(
		this IMultiProviderDbContextBuilder<OtpDbContext> builder)
	{
		builder.AddPostgresql<PostgresqlOtpDbContext>();
		return builder;
	}
}
