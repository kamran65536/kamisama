namespace KamiSama.Modules.PolicyEngine.Entities;

/// <summary>
/// Represents a polymorphic value entry contained by a policy list.
/// </summary>
public abstract class PolicyListItem
{
	/// <summary>
	/// Gets or sets the persisted item identifier.
	/// </summary>
	public Guid Id { get; set; }

	/// <summary>
	/// Gets or sets the required parent policy list.
	/// </summary>
	public required virtual PolicyList PolicyList { get; set; }

	/// <summary>
	/// Gets or sets the item's UTC creation timestamp.
	/// </summary>
	public required DateTime CreatedAt { get; set; }

	/// <summary>
	/// Gets or sets the item's UTC last-update timestamp.
	/// </summary>
	public required DateTime UpdatedAt { get; set; }
}
