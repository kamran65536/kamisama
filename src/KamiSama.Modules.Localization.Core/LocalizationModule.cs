using KamiSama.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using KamiSama.Modules.Localization.Features;
using System.Globalization;

namespace KamiSama.Modules.Localization;

/// <summary>
/// Registers localization options, resources, and the scoped localization feature implementations discovered in this assembly.
/// Request-culture middleware is added separately by <see cref="ExtendedWebApplicationBuilderExtensions.AddLocalizationModule"/> before this module.
/// </summary>
/// <param name="moduleSection">The configuration section containing <c>available-cultures</c> and <c>default-culture</c>.</param>
/// <param name="resourcePath">The relative resource path passed to ASP.NET Core localization registration.</param>
public class LocalizationModule(IConfigurationSection moduleSection, string resourcePath) : WebModule
{
	/// <summary>
	/// Scans this assembly for attributed feature services, binds <see cref="LocalizationOptions"/>, supplies a fallback array only when configuration produces <see langword="null"/>, and registers localization resources.
	/// </summary>
	/// <param name="services">The service collection configured before the application is built.</param>
	public override void ConfigureServices(IServiceCollection services)
	{
		services.AutoAddDependenciesFrom<LocalizationModule>();
		services.Configure<LocalizationOptions>(moduleSection).PostConfigure<LocalizationOptions>(opt =>
		{
			opt.AvailableCultures ??=
			[
				new CultureInfoDto("English (United States)", "us", "en-US")
			];
		});

		services.AddLocalization(opt => opt.ResourcesPath = resourcePath);
	}

	/// <summary>
	/// Performs no post-build work because the preceding request-localization module applies the middleware.
	/// </summary>
	/// <param name="app">The built application; this implementation does not modify it.</param>
	/// <param name="cancellationToken">The token supplied by the builder; this implementation ignores it.</param>
	/// <returns>An already completed task.</returns>
	public override Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken)
	{
		return Task.CompletedTask;
	}
}
/// <summary>
/// Adds configured localization services, features, and request-culture middleware to an extended application builder.
/// </summary>
public static class ExtendedWebApplicationBuilderExtensions
{
	/// <summary>
	/// Reads localization settings immediately, configures supported cultures, and queues request localization before <see cref="LocalizationModule"/>. Provider insertion yields effective precedence of Accept-Language header, query string, then cookie.
	/// </summary>
	/// <param name="builder">The extended builder that receives both localization modules.</param>
	/// <param name="moduleSection">The configuration section containing localization settings.</param>
	/// <returns>The same builder for fluent composition.</returns>
	public static ExtendedWebApplicationBuilder AddLocalizationModule(this ExtendedWebApplicationBuilder builder, IConfigurationSection moduleSection)
	{
		var options = moduleSection.Get<LocalizationOptions>() ?? new ();

		return builder
			.AddRequestLocalization(opt =>
			{
				var defaultCulture = new CultureInfo(options.DefaultCulture);

				var availableCultures = options.AvailableCultures ?? [];

				var allCultures = availableCultures.Select(x => new CultureInfo(x.Culture)).ToArray();

				opt.DefaultRequestCulture = new RequestCulture(defaultCulture, defaultCulture);
				opt.SupportedCultures = allCultures;
				opt.SupportedUICultures = allCultures;
				opt.ApplyCurrentCultureToResponseHeaders = true;
				opt.RequestCultureProviders.Clear();
				opt.AddInitialRequestCultureProvider(new CookieRequestCultureProvider());
				opt.AddInitialRequestCultureProvider(new QueryStringRequestCultureProvider());
				opt.AddInitialRequestCultureProvider(new AcceptLanguageHeaderRequestCultureProvider());
			})
			.AddModule(new LocalizationModule(moduleSection, ""));
	}
}
