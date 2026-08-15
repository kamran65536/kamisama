namespace KamiSama.Modules.PolicyEngine.Entities;

/// <summary>
/// Represents the ordered assignment of a reusable policy action to a policy rule.
/// </summary>
public class PolicyRuleAction
{
	/// <summary>
	/// Gets or sets the persisted assignment identifier.
	/// </summary>
	public Guid Id { get; set; }

	/// <summary>
	/// Gets or sets the required rule that owns this assignment.
	/// </summary>
	public required virtual PolicyRule PolicyRule { get; set; }

	/// <summary>
	/// Gets or sets the required reusable action referenced by this assignment.
	/// </summary>
	public required virtual PolicyAction PolicyAction { get; set; }

	/// <summary>
	/// Gets or sets the action's application order within the rule.
	/// </summary>
	public required int Order { get; set; }

	/// <summary>
	/// Gets or sets the UTC creation timestamp.
	/// </summary>
	public required DateTime CreatedAt { get; set; }

	/// <summary>
	/// Gets or sets the UTC last-update timestamp.
	/// </summary>
	public required DateTime UpdatedAt { get; set; }
}
