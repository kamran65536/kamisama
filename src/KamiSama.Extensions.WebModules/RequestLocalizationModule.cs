using Microsoft.AspNetCore.Localization;
using System.ComponentModel;
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
		services.AddRequestLocalization(configure);
		services.AddLocalization();
	}
	/// <inheritdoc />
	public override void ApplyConfigurationTo(WebApplication app)
	{
		app.UseRequestLocalization();
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