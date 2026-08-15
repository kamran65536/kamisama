using System.ComponentModel.DataAnnotations;

namespace KamiSama.Modules.Locations.Entities;

/// <summary>
/// Represents a persisted province that can contain multiple cities.
/// </summary>
/// <remarks>The Core model configures city deletion as restricted; a province with related cities cannot be deleted by database cascade.</remarks>
public class Province
{
	/// <summary>Gets or sets the province identifier.</summary>
	/// <value>The EF Core primary key.</value>
	public Guid Id { get; set; }

	/// <summary>Gets or sets the required province name.</summary>
	/// <value>A name with a maximum persisted length of 100 characters.</value>
	[MaxLength(100)]
	public required string Name { get; set; }

	/// <summary>Gets or sets the cities related to this province.</summary>
	/// <value>The mutable navigation collection; provider registrations enable lazy-loading proxies for virtual navigations.</value>
	public virtual ICollection<City> Cities { get; set; } = [];
}
