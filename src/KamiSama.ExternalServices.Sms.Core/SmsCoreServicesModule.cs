using KamiSama.Extensions.DependencyInjection;
using KamiSama.Extensions.WebModules;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KamiSama.ExternalServices.Sms;

public class SmsCoreServicesModule(IConfigurationSection defaultsSection) : WebModule
{
    public override void ConfigureServices(IServiceCollection services)
    {
        services.Configure<SmsDefaultsOptions>(defaultsSection);
        services.AutoAddDependenciesFrom<SmsCoreServicesModule>();
    }

    public override Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
public static class ExtendedWebApplicationBuilderExtensions
{
    public static ExtendedWebApplicationBuilder AddSmsCoreServicesModule(this ExtendedWebApplicationBuilder builder, IConfigurationSection defaultsSection)
        => builder.AddModule(new SmsCoreServicesModule(defaultsSection));
}