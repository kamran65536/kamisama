using KamiSama.Extensions.DependencyInjection;
using KamiSama.Extensions.WebModules;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KamiSama.ExternalServices.Email;

public class EmailCoreServicesModule(IConfigurationSection defaultsSection) : WebModule
{
    public override void ConfigureServices(IServiceCollection services)
    {
        services.Configure<EmailDefaultsOptions>(defaultsSection);
        services.AutoAddDependenciesFrom<EmailCoreServicesModule>();
    }

    public override Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
public static class ExtendedWebApplicationBuilderExtensions
{
    public static ExtendedWebApplicationBuilder AddCoreEmailServices(this ExtendedWebApplicationBuilder builder, IConfigurationSection defaultsSection)
        => builder.AddModule(new EmailCoreServicesModule(defaultsSection));
}