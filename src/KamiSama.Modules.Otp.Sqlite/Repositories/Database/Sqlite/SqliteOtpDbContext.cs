using KamiSama.Modules.Otp.Repositories.Database;
using Microsoft.EntityFrameworkCore;

namespace KamiSama.Modules.Otp.Repositories.Database.Sqlite;

/// <summary>
/// Provides the concrete SQLite EF Core context used by Otp repositories.
/// </summary>
/// <param name="options">The SQLite options configured by <c>AddSqliteOtpDbContext</c>.</param>
/// <remarks>
/// The provider package currently supplies no migrations for this context; applications must provision a compatible
/// schema separately before using the OTP generation and verification features.
/// </remarks>
public class SqliteOtpDbContext(DbContextOptions<SqliteOtpDbContext> options) : OtpDbContext(options)
{
}
