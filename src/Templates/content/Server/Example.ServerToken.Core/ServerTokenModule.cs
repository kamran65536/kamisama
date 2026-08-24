using KamiSama.Extensions.DependencyInjection;
using KamiSama.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Example.ServerToken;

public sealed class ServerTokenModule : WebModule
{
    public override void ConfigureServices(IServiceCollection services)
        => services.AutoAddDependenciesFrom<ServerTokenModule>();

    public override Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken)
        => Task.CompletedTask;
}
