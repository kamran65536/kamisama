
namespace KamiSama.Extensions.WebModules;

/// <summary>
/// Adds Anti-forgery module
/// </summary>
public class AntiForgeryModule : WebModule
{
	/// <inheritdoc />
	public override void ConfigureServices(IServiceCollection services)
	{
	}
	/// <inheritdoc />
	public override void ApplyConfigurationTo(WebApplication app)
		=> app.UseAntiforgery();
}
/// <inheritdoc />
public static class AntiForgeryExtension
{
	/// <summary>
	/// Adds Anti-forgery module
	/// </summary>
	public static ExtendedWebApplicationBuilder AddAntiForgery(this ExtendedWebApplicationBuilder builder)
		=> builder.AddModule(new AntiForgeryModule());
}