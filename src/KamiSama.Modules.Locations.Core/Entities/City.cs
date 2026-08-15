using System.ComponentModel.DataAnnotations;

namespace KamiSama.Modules.Locations.Entities;

/// <summary>
/// Represents a persisted city belonging to one required province.
/// </summary>
/// <remarks>The model uses the required <see cref="Province"/> navigation as its parent relationship and does not expose a separate public province-id property.</remarks>
public class City
{
	/// <summary>Gets or sets the city identifier.</summary>
	/// <value>The EF Core primary key.</value>
	public Guid Id { get; set; }

	/// <summary>Gets or sets the required parent province.</summary>
	/// <value>The parent navigation used for filtering and DTO projection; provider registrations enable lazy loading for this virtual member.</value>
	public required virtual Province Province { get; set; }

	/// <summary>Gets or sets the required city name.</summary>
	/// <value>A name with a maximum persisted length of 100 characters.</value>
	[MaxLength(100)]
	public required string Name { get; set; }
}
