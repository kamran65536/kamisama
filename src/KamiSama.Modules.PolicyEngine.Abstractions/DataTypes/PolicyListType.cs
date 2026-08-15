namespace KamiSama.Modules.PolicyEngine.DataTypes;

/// <summary>
/// Specifies the value type accepted by a policy list.
/// </summary>
public enum PolicyListType
{
	/// <summary>
	/// Represents Internet Protocol addresses and ranges.
	/// </summary>
	IpAddress = 0,

	/// <summary>
	/// Represents wallet addresses and ranges.
	/// </summary>
	WalletAddress = 1,

	/// <summary>
	/// Represents token addresses and ranges.
	/// </summary>
	TokenAddress = 2,
}
