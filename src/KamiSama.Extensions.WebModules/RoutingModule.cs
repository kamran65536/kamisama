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
		if (configure != null)
			services.Configure<RouteOptions>(configure);
	}
	/// <inheritdoc />
	public override void ApplyConfigurationTo(WebApplication app)
		=> app.UseRouting();	
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