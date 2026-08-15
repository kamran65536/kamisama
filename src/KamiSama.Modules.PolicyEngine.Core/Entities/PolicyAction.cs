using System.ComponentModel.DataAnnotations;

namespace KamiSama.Modules.PolicyEngine.Entities;

/// <summary>
/// Represents a reusable policy action resolved through a registered action handler.
/// </summary>
public class PolicyAction
{
	/// <summary>
	/// Gets or sets the persisted action identifier.
	/// </summary>
	public Guid Id { get; set; }

	/// <summary>
	/// Gets or sets the required action name, limited to 200 characters by the EF model.
	/// </summary>
	[MaxLength(200)]
	public required string Name { get; set; }

	/// <summary>
	/// Gets or sets the required application-defined handler name, limited to 200 characters.
	/// </summary>
	[MaxLength(200)]
	public required string HandlerName { get; set; }

	/// <summary>
	/// Gets or sets opaque configuration text for a separately implemented action handler.
	/// </summary>
	public required string ConfigurationSource { get; set; }

	/// <summary>
	/// Gets or sets whether a separately implemented evaluator may retain multiple resolutions of this action.
	/// </summary>
	public required bool AllowsMultiple { get; set; }

	/// <summary>
	/// Gets or sets whether the action definition is enabled for separately implemented evaluation.
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
	/// Gets or sets the rule assignments that reference this action.
	/// </summary>
	public virtual ICollection<PolicyRuleAction> PolicyRuleActions { get; set; } = [];
}
