namespace KamiSama.Modules.PolicyEngine.Entities;

/// <summary>
/// Represents an inclusive serialized value range contained by a policy list.
/// </summary>
public class RangePolicyListItem : PolicyListItem
{
	/// <summary>
	/// Gets or sets the opaque serialized inclusive lower bound.
	/// </summary>
	public required string From { get; set; }

	/// <summary>
	/// Gets or sets the opaque serialized inclusive upper bound.
	/// </summary>
	public required string To { get; set; }
}
