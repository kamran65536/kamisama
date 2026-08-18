using KamiSama.Modules.Otp.Repositories.Database;
using KamiSama.Modules.Otp.Repositories.Database.Sqlite;
using KamiSama.Repositories.EntityFrameworkCore;
using KamiSama.Repositories.EntityFrameworkCore.Sqlite;

namespace KamiSama.Modules.Otp;

/// <summary>
/// Adds the concrete SQLite Otp context to the multi-provider registration built by the Core module.
/// </summary>
public static class OtpSqliteDbContextBuilderExtensions
{
	/// <summary>
	/// Registers <see cref="SqliteOtpDbContext"/> and exposes it under the exact <c>sqlite</c> keyed <see cref="OtpDbContext"/> service.
	/// </summary>
	/// <param name="builder">The Otp context builder created during <c>AddOtpModule</c> service configuration.</param>
	/// <returns>The same builder for fluent registration.</returns>
	/// <remarks>The underlying provider enables lazy-loading proxies, applies the Otp migration-history table, and uses the configured connection string.</remarks>
	public static IMultiProviderDbContextBuilder<OtpDbContext> AddSqlite(
		this IMultiProviderDbContextBuilder<OtpDbContext> builder)
	{
		builder.AddSqlite<OtpDbContext, SqliteOtpDbContext>();
		return builder;
	}
}
