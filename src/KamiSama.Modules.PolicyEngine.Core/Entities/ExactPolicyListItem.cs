namespace KamiSama.Modules.PolicyEngine.Entities;

/// <summary>
/// Represents an exact serialized value contained by a policy list.
/// </summary>
public class ExactPolicyListItem : PolicyListItem
{
	/// <summary>
	/// Gets or sets the opaque serialized value matched exactly by a separately implemented evaluator.
	/// </summary>
	public required string Value { get; set; }
}
