using KamiSama.Extensions.DependencyInjection;
using KamiSama.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Example.Core;

public sealed class PlatformModule : WebModule
{
    public override void ConfigureServices(IServiceCollection services)
        => services.AutoAddDependenciesFrom<PlatformModule>();

    public override Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken)
        => Task.CompletedTask;
}
