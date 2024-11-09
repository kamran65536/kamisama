using Microsoft.AspNetCore.Routing;

namespace KamiSama.Extensions.WebModules;

/// <summary>
/// Adds Routing module
/// </summary>
public class RoutingModule(Action<RouteOptions>? configure) : WebModule
{
	/// <inheritdoc />
	public override void ConfigureServices(IServiceCollection services)
	{
		services.Configure<RouteOptions>(ConfigureRouting);
	}
	/// <inheritdoc />
	public override Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken)
	{
		app.UseRouting();

		return Task.CompletedTask;
	}
	/// <summary>
	/// Configures route options for inheritance
	/// </summary>
	protected virtual void ConfigureRouting(RouteOptions routeOptions)
	{
		configure?.Invoke(routeOptions);
	}
}
/// <inheritdoc />
public static class RoutingExtension
{
	/// <summary>
	/// Adds Routing module
	/// </summary>
	public static ExtendedWebApplicationBuilder AddRouting(this ExtendedWebApplicationBuilder builder, Action<RouteOptions>? configure)
		=> builder.AddModule(new RoutingModule(configure));
}