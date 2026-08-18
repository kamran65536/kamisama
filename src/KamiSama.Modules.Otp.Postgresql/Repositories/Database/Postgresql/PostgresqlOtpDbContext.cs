using KamiSama.Modules.Otp.Repositories.Database;
using Microsoft.EntityFrameworkCore;

namespace KamiSama.Modules.Otp.Repositories.Database.Postgresql;

/// <summary>
/// Provides the concrete PostgreSQL EF Core context used by Otp repositories.
/// </summary>
/// <param name="options">The PostgreSQL options configured by <c>AddPostgresqlOtpDbContext</c>.</param>
/// <remarks>
/// The provider package currently supplies no migrations for this context; applications must provision a compatible
/// schema separately before using the OTP generation and verification features.
/// </remarks>
public class PostgresqlOtpDbContext(DbContextOptions<PostgresqlOtpDbContext> options) : OtpDbContext(options)
{
}
