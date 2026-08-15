namespace KamiSama.Modules.PolicyEngine.Contexts;

/// <summary>
/// Represents diagnostic information produced during policy evaluation.
/// </summary>
public class PolicyEvaluationDiagnostic
{
	/// <summary>
	/// Gets or sets the machine-readable diagnostic code.
	/// </summary>
	public required string Code { get; set; }

	/// <summary>
	/// Gets or sets the human-readable diagnostic message.
	/// </summary>
	public required string Message { get; set; }

	/// <summary>
	/// Gets or sets the severity of the diagnostic.
	/// </summary>
	public required PolicyEvaluationDiagnosticSeverity Severity { get; set; }
}

/// <summary>
/// Specifies the severity of a policy evaluation diagnostic.
/// </summary>
public enum PolicyEvaluationDiagnosticSeverity
{
	/// <summary>
	/// Indicates diagnostic information that does not represent a problem.
	/// </summary>
	Information = 0,

	/// <summary>
	/// Indicates a recoverable or potentially unintended evaluation condition.
	/// </summary>
	Warning = 1,

	/// <summary>
	/// Indicates an evaluation condition that prevented an intended result.
	/// </summary>
	Error = 2,
}
