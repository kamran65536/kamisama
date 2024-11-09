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
		services.AddRazorPages(ConfigureRazorPages);
	}
	/// <inheritdoc />
	public override Task ApplyConfigurationToAsync(WebApplication app)
	{
		app.MapRazorPages();

		return Task.CompletedTask;
	}
	/// <summary>
	/// Configures the razor pages for inheritance
	/// </summary>
	protected virtual void ConfigureRazorPages(RazorPagesOptions options)
	{
		configure?.Invoke(options);
	}
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
