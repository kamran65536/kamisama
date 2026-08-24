using Example.Bootstrap.Initializers;
using KamiSama.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Example.Bootstrap;

public sealed class BootstrapModule : WebModule
{
    private static readonly IReadOnlyList<IBootstrapInitializer> DeclaredInitializers = [];
    private readonly IReadOnlyList<IBootstrapInitializer> initializers;

    public BootstrapModule() : this(DeclaredInitializers)
    {
    }

    public BootstrapModule(IReadOnlyList<IBootstrapInitializer> initializers)
        => this.initializers = initializers;

    public override void ConfigureServices(IServiceCollection services)
    {
        foreach (var initializer in initializers)
        {
            initializer.ConfigureServices(services);
        }
    }

    public override async Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken)
    {
        foreach (var initializer in initializers)
        {
            await initializer.ApplyConfigurationToAsync(app, cancellationToken);
        }
    }
}

public static class BootstrapModuleExtensions
{
    public static ExtendedWebApplicationBuilder AddBootstrap(this ExtendedWebApplicationBuilder builder)
        => builder.AddModule(new BootstrapModule());
}
