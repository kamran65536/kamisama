using KamiSama.Extensions.DependencyInjection;
using KamiSama.Modules.PolicyEngine.Contexts;

namespace KamiSama.ServicePlans.PolicyAction;

/// <summary>
/// Supplies the package's scoped <see cref="IServicePlansPolicyActionHandler"/> registration.
/// Handler identity is available, but action execution is not implemented.
/// </summary>
[AutoInjectScoped<IServicePlansPolicyActionHandler>]
internal sealed class ServicePlansPolicyActionHandler : IServicePlansPolicyActionHandler
{
	/// <summary>
	/// Gets the exact <c>service-plans</c> name exposed by this handler.
	/// </summary>
	public string HandlerName => ServicePlansPolicyActionHandlerNames.ServicePlans;

	/// <summary>
	/// Rejects every execution because expression deserialization and evaluation are not implemented.
	/// </summary>
	/// <param name="context">The unused PolicyEngine context.</param>
	/// <param name="configurationSource">The unused serialized configuration.</param>
	/// <param name="cancellationToken">The unused cancellation token.</param>
	/// <returns>This method does not return a task because it throws synchronously.</returns>
	/// <exception cref="NotImplementedException">Always thrown.</exception>
	public Task<ServicePlansPolicyActionResult> ExecuteAsync(
		PolicyContext context,
		string configurationSource,
		CancellationToken cancellationToken = default)
		=> throw new NotImplementedException();
}
