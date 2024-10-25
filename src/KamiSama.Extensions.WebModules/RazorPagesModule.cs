using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KamiSama.Extensions.WebModules;

/// <summary>
/// Adds Razor Pages
/// </summary>
public class RazorPagesModule(Action<RazorPagesOptions>? configure) : WebModule
{
	/// <inheritdoc />
	public override void ConfigureServices(IServiceCollection services)
	{
		if (configure == null)
			services.AddRazorPages();
		else
			services.AddRazorPages(configure);
	}
	/// <inheritdoc />
	public override void ApplyConfigurationTo(WebApplication app)
		=> app.MapRazorPages();
}
/// <inheritdoc />
public static class RazorPagesModuleExtension
{
	/// <summary>
	/// Adds Razor Pages module
	/// </summary>
	public static ExtendedWebApplicationBuilder AddRazorPages(this ExtendedWebApplicationBuilder builder, Action<RazorPagesOptions>? configure)
		=> builder.AddModule(new RazorPagesModule(configure));
}
