using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace KamiSama.Modules;
/// <summary>
/// Registers localization and configured request-localization options before build, then adds request-localization middleware afterward.
/// </summary>
/// <param name="configure">The required callback used to configure request localization.</param>
public class RequestLocalizationModule(Action<RequestLocalizationOptions> configure) : WebModule
{
	/// <summary>Registers request-localization options through <see cref="ConfigureRequestLocalization"/> and adds localization services.</summary>
	/// <param name="services">The service collection configured before build.</param>
	public override void ConfigureServices(IServiceCollection services)
	{
		services.AddRequestLocalization(ConfigureRequestLocalization);
		services.AddLocalization();
	}
	/// <summary>Adds request-localization middleware using the options registered during the service phase.</summary>
	/// <param name="app">The built application.</param>
	/// <param name="cancellationToken">Ignored by this implementation.</param>
	/// <returns>An already completed task.</returns>
	public override Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken)
	{
		app.UseRequestLocalization();

		return Task.CompletedTask;
	}
	/// <summary>
	/// Invokes the required constructor callback for request-localization options; derived modules can override this hook.
	/// </summary>
	/// <param name="options">The request-localization options configured before build.</param>
	protected virtual void ConfigureRequestLocalization(RequestLocalizationOptions options)
	{
		configure(options);
	}
}
/// <summary>Provides fluent request-localization module registration.</summary>
public static class RequestLocalizationExtension
{
	/// <summary>
	/// Queues request-localization services and middleware using an options callback.
	/// </summary>
	/// <param name="builder">The builder that receives the module.</param>
	/// <param name="configure">The required request-localization options callback.</param>
	/// <returns>The same builder for fluent composition.</returns>
	public static ExtendedWebApplicationBuilder AddRequestLocalization(this ExtendedWebApplicationBuilder builder, Action<RequestLocalizationOptions> configure)
		=> builder.AddModule(new RequestLocalizationModule(configure));
	/// <summary>
	/// Queues request localization with one default request culture and the same supported culture array for formatting and UI resources.
	/// </summary>
	/// <param name="builder">The builder that receives the module.</param>
	/// <param name="defaultCulture">The default formatting and UI culture.</param>
	/// <param name="supportedCultures">The supported formatting and UI cultures; the array is assigned directly to both options.</param>
	/// <returns>The same builder for fluent composition.</returns>
	public static ExtendedWebApplicationBuilder AddRequestLocalization(this ExtendedWebApplicationBuilder builder, RequestCulture defaultCulture, params CultureInfo[] supportedCultures)
		=> builder.AddRequestLocalization(opt =>
		{
			opt.DefaultRequestCulture = defaultCulture;
			opt.SupportedCultures = supportedCultures;
			opt.SupportedUICultures = supportedCultures;
		});
}
