using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace KamiSama.Extensions.WebModules;
/// <summary>
/// Adds Localization to the module
/// </summary>
public class RequestLocalizationModule(Action<RequestLocalizationOptions> configure) : WebModule
{
	/// <inheritdoc />
	public override void ConfigureServices(IServiceCollection services)
	{
		services.AddRequestLocalization(ConfigureRequestLocalization);
		services.AddLocalization();
	}
	/// <inheritdoc />
	public override Task ApplyConfigurationToAsync(WebApplication app)
	{
		app.UseRequestLocalization();

		return Task.CompletedTask;
	}
	/// <summary>
	/// Configures request localization for inheritance
	/// </summary>
	protected virtual void ConfigureRequestLocalization(RequestLocalizationOptions options)
	{
		configure(options);
	}
}
/// <inheritdoc />
public static class RequestLocalizationExtension
{
	/// <summary>
	/// Adds Localization to the module
	/// </summary>
	public static ExtendedWebApplicationBuilder AddRequestLocalization(this ExtendedWebApplicationBuilder builder, Action<RequestLocalizationOptions> configure)
		=> builder.AddModule(new RequestLocalizationModule(configure));
	/// <summary>
	/// Adds Localization to the module
	/// </summary>
	public static ExtendedWebApplicationBuilder AddRequestLocalization(this ExtendedWebApplicationBuilder builder, RequestCulture defaultCulture, params CultureInfo[] supportedCultures)
		=> builder.AddRequestLocalization(opt =>
		{
			opt.DefaultRequestCulture = defaultCulture;
			opt.SupportedCultures = supportedCultures;
			opt.SupportedUICultures = supportedCultures;
		});
}