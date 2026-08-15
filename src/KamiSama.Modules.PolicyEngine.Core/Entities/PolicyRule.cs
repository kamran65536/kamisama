using System.ComponentModel.DataAnnotations;

namespace KamiSama.Modules.PolicyEngine.Entities;

/// <summary>
/// Represents an ordered policy rule with a persisted condition expression.
/// </summary>
public class PolicyRule
{
	/// <summary>
	/// Gets or sets the persisted rule identifier.
	/// </summary>
	public Guid Id { get; set; }

	/// <summary>
	/// Gets or sets the required rule name, limited to 200 characters by the EF model.
	/// </summary>
	[MaxLength(200)]
	public required string Name { get; set; }

	/// <summary>
	/// Gets or sets the application-defined order in which a future evaluator should process the rule.
	/// </summary>
	public required int ProcessOrder { get; set; }

	/// <summary>
	/// Gets or sets opaque condition-language source for a separately implemented evaluator.
	/// </summary>
	public required string ConditionSource { get; set; }

	/// <summary>
	/// Gets or sets whether the rule definition is enabled for separately implemented evaluation.
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
	/// Gets or sets the ordered action assignments belonging to this rule.
	/// </summary>
	public virtual ICollection<PolicyRuleAction> PolicyRuleActions { get; set; } = [];
}
