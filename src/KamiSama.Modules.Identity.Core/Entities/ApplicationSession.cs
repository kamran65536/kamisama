using System.ComponentModel.DataAnnotations;

namespace KamiSama.Modules.Identity.Entities;

/// <summary>
/// Persists a revocable application session that can be referenced from cookie or JWT authentication.
/// Session validation updates <see cref="LastConnection"/>, which causes a database write on validated requests.
/// </summary>
public class ApplicationSession
{
	/// <summary>Gets or sets the database identifier.</summary>
	public Guid Id { get; set; }

	/// <summary>Gets or sets the owning user's identifier.</summary>
	public Guid UserId { get; set; }

	/// <summary>Gets or sets the owning user navigation.</summary>
	public virtual ApplicationUser User { get; set; } = default!;

	/// <summary>Gets or sets the unique key embedded in authentication state.</summary>
	[MaxLength(64)]
	public required string SessionKey { get; set; }

	/// <summary>Gets or sets the captured device description.</summary>
	[MaxLength(256)]
	public required string DeviceModel { get; set; }

	/// <summary>Gets or sets the captured IP address.</summary>
	[MaxLength(64)]
	public required string IpAddress { get; set; }

	/// <summary>Gets or sets whether the session has been revoked.</summary>
	public required bool IsRevoked { get; set; }

	/// <summary>Gets or sets the UTC creation time.</summary>
	public required DateTime CreatedAt { get; set; }

	/// <summary>Gets or sets the last recorded UTC connection time.</summary>
	public required DateTime LastConnection { get; set; }

	/// <summary>Gets or sets the UTC revocation time, or <see langword="null"/> while active.</summary>
	public DateTime? RevokedAt { get; set; }
}
