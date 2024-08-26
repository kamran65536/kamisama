using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using System.Linq;

namespace KamiSama.Testing.NSubstitute;

/// <summary>
/// Dependency Injection based tester class
/// </summary>
public class TesterBuilderBase
{
    /// <summary>
    /// internal service collection to use
    /// </summary>
    public IServiceCollection Services { get; } = new ServiceCollection();
    /// <summary>
    /// service scope in which services are added
    /// </summary>
    public IServiceScope ServiceScope { get; private set; } = default!;
    /// <inheritdoc />
    protected TesterBuilderBase()
    {
    }
    /// <summary>
    /// Adds a scoped service with parameters
    /// </summary>
    /// <typeparam name="TService"></typeparam>
    /// <param name="param"></param>
    /// <returns></returns>
    public TService AddScoped<TService>(params object[] param) where TService : class
    {
        var service = Substitute.For<TService>(param);

        Services.AddScoped(sp => service);

        return service;
    }
    /// <summary>
    /// Adds singleton service
    /// </summary>
    /// <typeparam name="TService"></typeparam>
    /// <returns></returns>
    public TService AddSingleton<TService>() where TService : class
    {
        var service = Substitute.For<TService>();

        Services.AddSingleton(sp => service);

        return service;
    }
    /// <summary>
    /// Adds Transient service
    /// </summary>
    /// <typeparam name="TService"></typeparam>
    /// <returns></returns>
    public TService AddTransient<TService>() where TService : class
    {
        var service = Substitute.For<TService>();

        Services.AddTransient(sp => service);

        return service;
    }
    /// <summary>
    /// returns a dependency based object
    /// <remarks>call this method after <see cref="BuildService{TService}"/> method</remarks>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T For<T>() where T : class
        => ServiceScope!.ServiceProvider.GetRequiredService<T>();
    /// <summary>
    /// Builds the dependency for service, if a dependency is not present, it will be mocked automatically
    /// </summary>
    /// <typeparam name="TService"></typeparam>
    /// <returns></returns>
    public TService BuildService<TService>() where TService : class
    {
        var tempProvider = Services.BuildServiceProvider();
        var tempScope = tempProvider.CreateScope();

        var defaultConstructor = typeof(TService).GetConstructors().First();

        foreach (var parameter in defaultConstructor.GetParameters())
        {
            var type = tempScope.ServiceProvider.GetService(parameter.ParameterType);

            if (type == null)
                Services.AddScoped(parameter.ParameterType, sp => Substitute.For([parameter.ParameterType], []));
        }

        Services.AddScoped<TService>();

        var provider = Services.BuildServiceProvider();
        ServiceScope = provider.CreateScope();

        return ServiceScope.ServiceProvider.GetRequiredService<TService>();
    }
}
