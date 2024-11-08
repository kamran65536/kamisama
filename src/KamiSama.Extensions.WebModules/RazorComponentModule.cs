
namespace KamiSama.Extensions.WebModules;
/// <summary>
/// Adds Razor component
/// </summary>
public class RazorComponentModule<TRootComponent>(Action<RazorComponentsEndpointConventionBuilder>? configure) : WebModule
{
	/// <inheritdoc />
	public override void ConfigureServices(IServiceCollection services)
	{
		services.AddRazorComponents();
	}
	/// <inheritdoc />
	public override void ApplyConfigurationTo(WebApplication app)
	{
		var builder = app.MapRazorComponents<TRootComponent>();

		ConfigureRazorComponents(builder);
	}
	/// <summary>
	/// Configures the razor builder for inheritance
	/// </summary>
	protected virtual void ConfigureRazorComponents(RazorComponentsEndpointConventionBuilder builder)
	{
		configure?.Invoke(builder);
	}
}
/// <inheritdoc />
public static class RazorComponentExtension
{
	/// <summary>
	/// Adds Razor component
	/// </summary>
	public static ExtendedWebApplicationBuilder AddRazorComponents<TRootComponent>(this ExtendedWebApplicationBuilder builder, Action<RazorComponentsEndpointConventionBuilder>? configure = null)
		=> builder.AddModule(new RazorComponentModule<TRootComponent>(configure));
}
