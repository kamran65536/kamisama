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

		ConfigureMvcBuilder(mvcBuilder);
	}
	/// <inheritdoc />
	public override void ApplyConfigurationTo(WebApplication app)
		=> app.MapControllers();
	/// <summary>
	/// Configures the mvc builder for inheritance
	/// </summary>
	protected virtual void ConfigureMvcBuilder(IMvcBuilder builder)
	{
		configure?.Invoke(builder);
	}
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
