using KamiSama.Extensions.DependencyInjection;
using KamiSama.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KamiSama.ExternalServices.Sms;

/// <summary>
/// Registers the scoped, unkeyed SMS dispatcher, the scoped keyed <c>mock</c> provider, and default-provider options.
/// Add this module when application code should resolve <c>ISendSms</c> without a key and dispatch through the configured provider key.
/// </summary>
/// <param name="defaultsSection">The configuration section containing the <c>sms</c> provider key.</param>
public class SmsCoreServicesModule(IConfigurationSection defaultsSection) : WebModule
{
	/// <summary>
	/// Binds <see cref="SmsDefaultsOptions"/> and scans this package for its scoped keyed and unkeyed SMS registrations.
	/// </summary>
	/// <param name="services">The application service collection.</param>
    public override void ConfigureServices(IServiceCollection services)
    {
        services.Configure<SmsDefaultsOptions>(defaultsSection);
        services.AutoAddDependenciesFrom<SmsCoreServicesModule>();
    }

	/// <summary>
	/// Completes the module lifecycle without applying middleware or endpoints.
	/// </summary>
	/// <param name="app">The built web application.</param>
	/// <param name="cancellationToken">The token used to cancel post-build configuration.</param>
	/// <returns>A completed task because this module has no post-build work.</returns>
    public override Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}

/// <summary>
/// Adds core SMS provider selection and service registrations to an extended ASP.NET Core application builder.
/// </summary>
public static class ExtendedWebApplicationBuilderExtensions
{
	/// <summary>
	/// Adds the core SMS module; its services are registered when <c>Build</c> or <c>BuildAsync</c> is called on the extended builder.
	/// </summary>
	/// <param name="builder">The extended application builder receiving the module.</param>
	/// <param name="defaultsSection">The configuration section containing the <c>sms</c> provider key.</param>
	/// <returns>The same builder so provider and application modules can be chained.</returns>
    public static ExtendedWebApplicationBuilder AddSmsCoreServicesModule(this ExtendedWebApplicationBuilder builder, IConfigurationSection defaultsSection)
        => builder.AddModule(new SmsCoreServicesModule(defaultsSection));
}
