namespace KamiSama.Extensions.WebModules;

/// <summary>
/// Api Controllers Module
/// </summary>
public class ControllersModule : WebModule
{
	/// <inheritdoc />
	public override void ConfigureServices(IServiceCollection services)
		=> services.AddControllers();
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
	/// <param name="builder"></param>
	/// <returns></returns>
	public static ExtendedWebApplicationBuilder AddControllers(this ExtendedWebApplicationBuilder builder)
		=> builder.AddModule<ControllersModule>();
}
