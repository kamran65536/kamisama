using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Example.Bootstrap.Initializers;

public interface IBootstrapInitializer
{
    void ConfigureServices(IServiceCollection services);

    Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken)
        => Task.CompletedTask;
}
