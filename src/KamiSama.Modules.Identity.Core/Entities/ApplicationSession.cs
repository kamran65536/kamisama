using System.ComponentModel.DataAnnotations;

namespace KamiSama.Modules.Identity.Entities;

public class ApplicationSession
{
	public Guid Id { get; set; }

	public Guid UserId { get; set; }

	public virtual ApplicationUser User { get; set; } = default!;

	[MaxLength(64)]
	public required string SessionKey { get; set; }

	[MaxLength(256)]
	public required string DeviceModel { get; set; }

	[MaxLength(64)]
	public required string IpAddress { get; set; }

	public required bool IsRevoked { get; set; }

	public required DateTime CreatedAt { get; set; }

	public required DateTime LastConnection { get; set; }

	public DateTime? RevokedAt { get; set; }
}
