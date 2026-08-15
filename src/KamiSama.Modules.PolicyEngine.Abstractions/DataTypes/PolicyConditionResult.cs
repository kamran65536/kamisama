namespace KamiSama.Modules.PolicyEngine.DataTypes;

/// <summary>
/// Specifies the three-valued result of a policy condition evaluation.
/// </summary>
public enum PolicyConditionResult
{
	/// <summary>
	/// Indicates that the condition did not match.
	/// </summary>
	False = 0,

	/// <summary>
	/// Indicates that the condition matched.
	/// </summary>
	True = 1,

	/// <summary>
	/// Indicates that the condition could not be resolved because required facts were unavailable.
	/// </summary>
	Undefined = 2,
}
