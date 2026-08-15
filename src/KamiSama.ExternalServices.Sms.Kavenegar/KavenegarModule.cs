using KamiSama.Extensions.DependencyInjection;
using KamiSama.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KamiSama.ExternalServices.Sms.Kavenegar;

internal class KavenegarModule(IConfigurationSection kavenegarSection) : WebModule
{
	/// <summary> Binds Kavenegar options and scans this package for its scoped keyed provider registration. </summary>
	/// <param name="services">The application service collection.</param>
	public override void ConfigureServices(IServiceCollection services)
	{
		services.Configure<KavenegarSmsOptions>(kavenegarSection);

		services.AutoAddDependenciesFrom<KavenegarModule>();
	}
	/// <summary> Completes without applying middleware or endpoints. </summary>
	/// <param name="app">The built web application.</param>
	/// <param name="cancellationToken">The token used to cancel post-build configuration.</param>
	/// <returns>A completed task.</returns>
	public override Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken)
	{
		return Task.CompletedTask;
	}
}

/// <summary>
/// Adds Kavenegar options binding and the scoped keyed <c>kavenegar</c> SMS provider to an extended ASP.NET Core application builder.
/// </summary>
public static class ExtendedWebApplicationBuilderExtensions
{
	/// <summary>
	/// Adds the Kavenegar SMS module; its services are registered when <c>Build</c> or <c>BuildAsync</c> is called on the extended builder.
	/// </summary>
	/// <param name="builder">The extended application builder receiving the module.</param>
	/// <param name="kavenegarSection">The configuration section containing <c>sender-phone-number</c> and the secret <c>api-key</c>.</param>
	/// <returns>The same builder so core SMS and application modules can be chained.</returns>
	public static ExtendedWebApplicationBuilder AddKavenegarSmsServiceModule(this ExtendedWebApplicationBuilder builder, IConfigurationSection kavenegarSection)
		=> builder.AddModule(new KavenegarModule(kavenegarSection));
}
