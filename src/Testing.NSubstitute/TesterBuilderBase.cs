using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using NSubstitute.Extensions;

namespace KamiSama.Testing.NSubstitute;

/// <summary>
/// Builds a service under test in a dependency injection scope and creates NSubstitute doubles for constructor dependencies that are not registered.
/// Registrations accumulate across builds, and the builder does not dispose the temporary or final service providers and scopes it creates.
/// </summary>
public class TesterBuilderBase
{
    /// <summary>
    /// Gets the mutable service collection used for explicit registrations, generated substitutes, and target services.
    /// </summary>
    public IServiceCollection Services { get; } = new ServiceCollection();
    /// <summary>
    /// Gets the most recently created final scope. The property is uninitialized until <see cref="BuildService{TService}"/> succeeds and an earlier scope is not disposed when replaced.
    /// </summary>
    public IServiceScope ServiceScope { get; private set; } = default!;
    /// <summary>
    /// Initializes an empty test builder.
    /// </summary>
    protected TesterBuilderBase()
    {
    }
    /// <summary>
    /// Adds an options configuration delegate to the service collection. The delegate runs when <typeparamref name="TOption"/> is resolved through the options infrastructure.
    /// </summary>
    /// <typeparam name="TOption">The options class to configure.</typeparam>
    /// <param name="configure">The delegate that mutates each created options instance.</param>
    public void AddOption<TOption>(Action<TOption> configure)
        where TOption : class
    {
        Services.Configure<TOption>(configure);
    }
    /// <summary>
    /// Creates one NSubstitute instance using the supplied constructor arguments and registers that same instance through a scoped factory.
    /// </summary>
    /// <typeparam name="TService">The substitutable class or interface to register.</typeparam>
    /// <param name="param">Constructor arguments passed to NSubstitute when substituting for a class.</param>
    /// <returns>The substitute captured by the scoped registration.</returns>
    public TService AddScoped<TService>(params object[] param) where TService : class
    {
        var service = Substitute.For<TService>(param);

        Services.AddScoped(sp => service);

        return service;
    }
    /// <summary>
    /// Creates and registers one singleton NSubstitute instance.
    /// </summary>
    /// <typeparam name="TService">The substitutable class or interface to register.</typeparam>
    /// <returns>The registered singleton substitute.</returns>
    public TService AddSingleton<TService>() where TService : class
    {
        var service = Substitute.For<TService>();

        Services.AddSingleton(sp => service);

        return service;
    }
    /// <summary>
    /// Creates one NSubstitute instance and registers a transient factory that returns that same captured instance on every resolution.
    /// </summary>
    /// <typeparam name="TService">The substitutable class or interface to register.</typeparam>
    /// <returns>The substitute captured by the transient registration.</returns>
    public TService AddTransient<TService>() where TService : class
    {
        var service = Substitute.For<TService>();

        Services.AddTransient(sp => service);

        return service;
    }
    /// <summary>
    /// Resolves a required service from the most recently built final scope.
    /// </summary>
    /// <remarks>Call this method only after <see cref="BuildService{TService}"/> succeeds; otherwise no usable scope exists.</remarks>
    /// <typeparam name="T">The registered reference type to resolve.</typeparam>
    /// <returns>The service resolved from <see cref="ServiceScope"/>.</returns>
    public T For<T>() where T : class
        => ServiceScope!.ServiceProvider.GetRequiredService<T>();
    /// <summary>
    /// Selects the first public constructor reported by reflection, probes its parameters through a temporary provider, and registers scoped substitutes for unresolved parameter types before building the target in a new scope.
    /// </summary>
    /// <remarks>Only the selected constructor's unresolved dependencies are substituted, and NSubstitute can only proxy supported interfaces or classes with overridable members. Temporary providers and scopes, the final provider, and any previously assigned <see cref="ServiceScope"/> are not disposed by this type.</remarks>
    /// <typeparam name="TService">The concrete service type to register and resolve.</typeparam>
    /// <returns>The scoped target service resolved from the newly created final scope.</returns>
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
