namespace KamiSama.Modules.Ticketing.Entities;

/// <summary>
/// Represents a persisted category used to classify tickets.
/// Core enforces duplicate names in feature code rather than through a unique database index.
/// </summary>
public class TicketCategory
{
	/// <summary>Gets or sets the category identifier.</summary>
	public Guid Id { get; set; }
	/// <summary>Gets or sets the required category name, limited to 50 characters by the EF Core model.</summary>
	[MaxLength(50)]
	public required string Name { get; set; }
	/// <summary>Gets or sets the category creation timestamp.</summary>
	public required DateTime CreatedAt { get; set; }
	/// <summary>Gets or sets the latest category update timestamp.</summary>
	public required DateTime UpdatedAt { get; set; }
}
