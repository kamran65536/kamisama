namespace KamiSama.Extensions.WebModules;

/// <summary>
/// Adds Routing module
/// </summary>
public class RoutingModule : WebModule
{
	/// <inheritdoc />
	public override void ConfigureServices(IServiceCollection services)
	{
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
	public static ExtendedWebApplicationBuilder AddRouting(this ExtendedWebApplicationBuilder builder)
		=> builder.AddModule(new RoutingModule());
}