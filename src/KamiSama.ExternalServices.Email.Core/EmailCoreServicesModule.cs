using KamiSama.Extensions.DependencyInjection;
using KamiSama.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KamiSama.ExternalServices.Email;

/// <summary>
/// Registers provider-selecting email services and binds the default provider configuration.
/// Add this module when the application should resolve <c>ISendEmail</c> through a configured keyed provider.
/// </summary>
/// <param name="defaultsSection">The configuration section containing the <c>email</c> provider key.</param>
public class EmailCoreServicesModule(IConfigurationSection defaultsSection) : WebModule
{
    /// <summary>
    /// Binds <see cref="EmailDefaultsOptions"/> and scans this package for its email service registrations.
    /// </summary>
    /// <param name="services">The application service collection.</param>
    public override void ConfigureServices(IServiceCollection services)
    {
        services.Configure<EmailDefaultsOptions>(defaultsSection);
        services.AutoAddDependenciesFrom<EmailCoreServicesModule>();
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
/// Adds the core email-service module to an extended ASP.NET Core application builder.
/// </summary>
public static class ExtendedWebApplicationBuilderExtensions
{
    /// <summary>
    /// Registers default-provider selection and the core email service implementations.
    /// </summary>
    /// <param name="builder">The extended application builder receiving the module.</param>
    /// <param name="defaultsSection">The configuration section containing the <c>email</c> provider key.</param>
    /// <returns>The same builder so additional modules can be chained.</returns>
    public static ExtendedWebApplicationBuilder AddCoreEmailServices(this ExtendedWebApplicationBuilder builder, IConfigurationSection defaultsSection)
        => builder.AddModule(new EmailCoreServicesModule(defaultsSection));
}
