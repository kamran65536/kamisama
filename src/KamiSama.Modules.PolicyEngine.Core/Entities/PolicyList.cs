using KamiSama.Modules.PolicyEngine.DataTypes;
using System.ComponentModel.DataAnnotations;

namespace KamiSama.Modules.PolicyEngine.Entities;

/// <summary>
/// Represents a typed named list referenced by policy conditions.
/// </summary>
public class PolicyList
{
	/// <summary>
	/// Gets or sets the persisted list identifier.
	/// </summary>
	public Guid Id { get; set; }

	/// <summary>
	/// Gets or sets the required list name, limited to 200 characters by the EF model.
	/// </summary>
	[MaxLength(200)]
	public required string Name { get; set; }

	/// <summary>
	/// Gets or sets the declared value type interpreted by a separately implemented evaluator.
	/// </summary>
	public required PolicyListType Type { get; set; }

	/// <summary>
	/// Gets or sets whether the list definition is enabled for separately implemented evaluation.
	/// </summary>
	public required bool IsEnabled { get; set; }

	/// <summary>
	/// Gets or sets the UTC creation timestamp.
	/// </summary>
	public required DateTime CreatedAt { get; set; }

	/// <summary>
	/// Gets or sets the UTC last-update timestamp.
	/// </summary>
	public required DateTime UpdatedAt { get; set; }

	/// <summary>
	/// Gets or sets the polymorphic exact and range values contained by the list.
	/// </summary>
	public virtual ICollection<PolicyListItem> Items { get; set; } = [];
}
