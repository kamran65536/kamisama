using Microsoft.AspNetCore.Routing;

namespace KamiSama.Modules;

/// <summary>
/// Registers route options before build and explicitly adds routing middleware afterward.
/// </summary>
/// <param name="configure">An optional callback for route options.</param>
public class RoutingModule(Action<RouteOptions>? configure) : WebModule
{
	/// <summary>Registers route-options configuration through <see cref="ConfigureRouting"/>.</summary>
	/// <param name="services">The service collection configured before build.</param>
	public override void ConfigureServices(IServiceCollection services)
	{
		services.Configure<RouteOptions>(ConfigureRouting);
	}
	/// <summary>Adds routing middleware at this module's position in the ordered pipeline.</summary>
	/// <param name="app">The built application.</param>
	/// <param name="cancellationToken">Ignored by this implementation.</param>
	/// <returns>An already completed task.</returns>
	public override Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken)
	{
		app.UseRouting();

		return Task.CompletedTask;
	}
	/// <summary>
	/// Invokes the constructor callback for route options; derived modules can override this hook.
	/// </summary>
	/// <param name="routeOptions">The route options configured before build.</param>
	protected virtual void ConfigureRouting(RouteOptions routeOptions)
	{
		configure?.Invoke(routeOptions);
	}
}
/// <summary>Provides fluent registration of <see cref="RoutingModule"/>.</summary>
public static class RoutingExtension
{
	/// <summary>
	/// Queues route-options registration and routing middleware.
	/// </summary>
	/// <param name="builder">The builder that receives the module.</param>
	/// <param name="configure">An optional route-options callback.</param>
	/// <returns>The same builder for fluent composition.</returns>
	public static ExtendedWebApplicationBuilder AddRouting(this ExtendedWebApplicationBuilder builder, Action<RouteOptions>? configure)
		=> builder.AddModule(new RoutingModule(configure));
}
