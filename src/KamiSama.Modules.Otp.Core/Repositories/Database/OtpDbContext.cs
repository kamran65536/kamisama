using Microsoft.EntityFrameworkCore;

namespace KamiSama.Modules.Otp.Repositories.Database;

/// <summary>
/// Defines the provider-neutral EF Core model and entity sets used by Otp repositories.
/// </summary>
/// <remarks>Install and register a concrete Otp provider context; application services consume this abstract context through keyed multi-provider resolution.</remarks>
public abstract class OtpDbContext : DbContext
{
	/// <summary>Gets or sets the one-time-password records in the Otp database.</summary>
	/// <value>The tracked OTP record entity set.</value>
	public virtual DbSet<OtpRecord> OtpRecords { get; set; }

	/// <summary>
	/// Initializes the base Otp context with options typed for direct base-context construction.
	/// </summary>
	/// <param name="options">The EF Core options for this base context.</param>
	public OtpDbContext(DbContextOptions<OtpDbContext> options) : base(options)
	{
	}

	/// <summary>
	/// Initializes a provider-specific derived context with non-generic EF Core options.
	/// </summary>
	/// <param name="options">The options configured by the concrete provider registration.</param>
	protected OtpDbContext(DbContextOptions options) : base(options)
	{
	}
}
