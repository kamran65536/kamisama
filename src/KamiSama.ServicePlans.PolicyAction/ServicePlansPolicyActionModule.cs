using KamiSama.Extensions.DependencyInjection;
using KamiSama.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace KamiSama.ServicePlans.PolicyAction;

/// <summary>
/// Registers the package's attributed scoped service-plans action handler before application build.
/// It does not register PolicyEngine or ServicePlans modules and performs no post-build configuration.
/// </summary>
public class ServicePlansPolicyActionModule : WebModule
{
	/// <summary>
	/// Scans this package assembly and registers the internal handler as a scoped <see cref="IServicePlansPolicyActionHandler"/>.
	/// </summary>
	/// <param name="services">The application service collection configured before build.</param>
	public override void ConfigureServices(IServiceCollection services)
		=> services.AutoAddDependenciesFrom<ServicePlansPolicyActionModule>();

	/// <summary>
	/// Completes without adding middleware, endpoints, dispatch, or other application configuration.
	/// </summary>
	/// <param name="app">The built application; this implementation does not use it.</param>
	/// <param name="cancellationToken">The build token; this implementation does not observe it.</param>
	/// <returns>An already-completed task.</returns>
	public override Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken)
		=> Task.CompletedTask;
}

/// <summary>
/// Adds service-plans policy-action registration to an extended ASP.NET Core builder.
/// Building the application registers the package-specific handler but does not add either owning domain module.
/// </summary>
public static class ServicePlansPolicyActionWebApplicationBuilderExtensions
{
	/// <summary>
	/// Queues <see cref="ServicePlansPolicyActionModule"/> so its attributed scoped handler is discovered during build.
	/// Callers must add PolicyEngine, ServicePlans, and host-supplied action dispatch separately when those capabilities are required.
	/// </summary>
	/// <param name="builder">The extended builder that receives the module.</param>
	/// <returns>The same extended builder for fluent module composition.</returns>
	public static ExtendedWebApplicationBuilder AddServicePlansPolicyActionModule(this ExtendedWebApplicationBuilder builder)
		=> builder.AddModule(new ServicePlansPolicyActionModule());
}
