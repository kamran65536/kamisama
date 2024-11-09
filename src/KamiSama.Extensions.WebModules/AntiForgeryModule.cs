
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
	public override Task ApplyConfigurationToAsync(WebApplication app)
	{
		app.UseAntiforgery();
	
		return Task.CompletedTask;
	}
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