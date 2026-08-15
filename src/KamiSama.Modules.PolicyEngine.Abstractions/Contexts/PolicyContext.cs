namespace KamiSama.Modules.PolicyEngine.Contexts;

/// <summary>
/// Represents the runtime state used to evaluate policies independently of any host or transport.
/// </summary>
public class PolicyContext
{
	/// <summary>
	/// Gets the flat collection of typed facts available to policy evaluation.
	/// </summary>
	/// <remarks>
	/// Fact keys are opaque strings, so dots have no path or nesting semantics.
	/// An absent key represents a fact that policy evaluation may treat as undefined.
	/// </remarks>
	public IDictionary<string, object> Facts { get; } = new Dictionary<string, object>(StringComparer.Ordinal);

	/// <summary>
	/// Gets the actions resolved by policy evaluation in application order.
	/// </summary>
	public IList<ResolvedPolicyAction> Actions { get; } = [];

	/// <summary>
	/// Gets the diagnostics produced while evaluating policies.
	/// </summary>
	public IList<PolicyEvaluationDiagnostic> EvaluationDiagnostics { get; } = [];
}
