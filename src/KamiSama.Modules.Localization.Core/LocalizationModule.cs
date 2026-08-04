using KamiSama.Extensions.WebModules;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using KamiSama.Modules.Localization.Features;
using System.Globalization;

namespace KamiSama.Modules.Localization;

public class LocalizationModule(IConfigurationSection moduleSection, string resourcePath) : WebModule
{
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

	public override Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken)
	{
		return Task.CompletedTask;
	}
}
public static class ExtendedWebApplicationBuilderExtensions
{
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