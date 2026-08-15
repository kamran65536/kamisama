namespace KamiSama.Modules.PolicyEngine.Contexts;

/// <summary>
/// Represents an action selected by policy evaluation for later application.
/// </summary>
public class ResolvedPolicyAction
{
	/// <summary>
	/// Gets or sets the identifier of the selected policy action.
	/// </summary>
	public required Guid ActionId { get; set; }

	/// <summary>
	/// Gets or sets the stable name of the handler that applies the action.
	/// </summary>
	public required string HandlerName { get; set; }

	/// <summary>
	/// Gets or sets the configuration source interpreted by the action handler.
	/// </summary>
	public required string ConfigurationSource { get; set; }

	/// <summary>
	/// Gets or sets the action order resolved from the matching policy rules.
	/// </summary>
	public required int Order { get; set; }
}
