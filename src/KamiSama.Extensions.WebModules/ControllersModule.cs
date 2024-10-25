namespace KamiSama.Extensions.WebModules;

/// <summary>
/// Api Controllers Module
/// </summary>
public class ControllersModule(Action<IMvcBuilder>? configure) : WebModule
{
	/// <inheritdoc />
	public override void ConfigureServices(IServiceCollection services)
	{
		var mvcBuilder = services.AddControllers();

		configure?.Invoke(mvcBuilder);
	}
	/// <inheritdoc />
	public override void ApplyConfigurationTo(WebApplication app)
		=> app.MapControllers();
}
/// <inheritdoc />
public static class ControllersModuleExtension
{
	/// <summary>
	/// Adds Api controller configuration
	/// </summary>
	public static ExtendedWebApplicationBuilder AddControllers(this ExtendedWebApplicationBuilder builder, Action<IMvcBuilder>? configure = null)
		=> builder.AddModule(new ControllersModule(configure));
}
