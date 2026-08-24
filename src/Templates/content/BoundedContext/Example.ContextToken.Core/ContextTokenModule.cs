using KamiSama.Extensions.DependencyInjection;
using KamiSama.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Example.ContextToken;

public sealed class ContextTokenModule : WebModule
{
    public override void ConfigureServices(IServiceCollection services)
        => services.AutoAddDependenciesFrom<ContextTokenModule>();

    public override Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken)
        => Task.CompletedTask;
}
