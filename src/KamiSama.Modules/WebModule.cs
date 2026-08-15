using Microsoft.Extensions.Hosting;

namespace KamiSama.Modules;
/// <summary>
/// Defines one two-phase ASP.NET Core startup module: service registration before build and application configuration after build.
/// </summary>
public abstract class WebModule
{
	/// <summary>
	/// Gets the host builder that owns this module. <see cref="ExtendedWebApplicationBuilder.AddModule(WebModule)"/> assigns it when the module is queued.
	/// </summary>
	protected internal IHostApplicationBuilder Builder { get; internal set; } = default!;
	/// <summary>
	/// Registers services during the first build phase, in module insertion order and before the underlying application is built.
	/// </summary>
	/// <param name="services">The underlying application's mutable service collection.</param>
	public abstract void ConfigureServices(IServiceCollection services);
	/// <summary>
	/// Applies middleware, endpoints, or other application configuration during the second build phase, in module insertion order after the application is built.
	/// </summary>
	/// <param name="app">The built application to configure.</param>
	/// <param name="cancellationToken">The token supplied to <see cref="ExtendedWebApplicationBuilder.BuildAsync"/>.</param>
	/// <returns>A task that completes when this module's post-build configuration is finished.</returns>
	public abstract Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken);
}
