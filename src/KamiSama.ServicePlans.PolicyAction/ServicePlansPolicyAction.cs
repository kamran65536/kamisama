using KamiSama.Modules.PolicyEngine.Contexts;

namespace KamiSama.ServicePlans.PolicyAction;

/// <summary>
/// Defines the handler-name value understood by this package's service-plans action contract.
/// PolicyEngine stores handler names as opaque text and does not resolve this value itself.
/// </summary>
public static class ServicePlansPolicyActionHandlerNames
{
	/// <summary>
	/// Identifies the package's service-plans handler as <c>service-plans</c>.
	/// A host-supplied dispatcher must match this value explicitly when routing resolved actions.
	/// </summary>
	public const string ServicePlans = "service-plans";
}

/// <summary>
/// Carries the intended computation-unit cost expression for a service-plans policy action.
/// The current package does not define an expression language, deserialize this type, or evaluate the value.
/// </summary>
public sealed class ServicePlansPolicyActionConfiguration
{
	/// <summary>
	/// Gets or sets the opaque expression intended to calculate computation-unit cost from policy facts.
	/// No syntax, validation, fact-name convention, or numeric-conversion behavior is currently implemented.
	/// </summary>
	public required string CostExpression { get; set; }
}

/// <summary>
/// Carries a computation-unit amount from a service-plans policy action handler.
/// The package's registered implementation never creates this result because execution is unimplemented.
/// </summary>
public sealed class ServicePlansPolicyActionResult
{
	/// <summary>
	/// Gets or sets the computation-unit amount attributed to the action.
	/// The type does not constrain the value to be positive or finite beyond <see cref="decimal"/> semantics.
	/// </summary>
	public decimal ComputationUnits { get; set; }
}

/// <summary>
/// Defines the package-specific boundary for applying serialized service-plans action configuration to a policy context.
/// PolicyEngine does not define or dispatch this contract; a host must select and invoke a handler itself.
/// </summary>
public interface IServicePlansPolicyActionHandler
{
	/// <summary>
	/// Gets the stable name a host can compare with a resolved policy action's handler name.
	/// The included implementation returns <see cref="ServicePlansPolicyActionHandlerNames.ServicePlans"/>.
	/// </summary>
	string HandlerName { get; }

	/// <summary>
	/// Applies serialized service-plans action configuration to the supplied policy facts and returns a computation-unit amount.
	/// The included implementation currently throws <see cref="NotImplementedException"/> before reading any argument.
	/// </summary>
	/// <param name="context">The PolicyEngine context whose ordinally keyed <c>Facts</c> would supply expression inputs.</param>
	/// <param name="configurationSource">The caller-serialized configuration text; no format is currently implemented or validated.</param>
	/// <param name="cancellationToken">The token intended to cancel execution; the included implementation does not observe it.</param>
	/// <returns>A task whose result would contain the computed units if a working implementation were supplied.</returns>
	/// <exception cref="NotImplementedException">The handler registered by this package always throws this exception.</exception>
	Task<ServicePlansPolicyActionResult> ExecuteAsync(
		PolicyContext context,
		string configurationSource,
		CancellationToken cancellationToken = default);
}
