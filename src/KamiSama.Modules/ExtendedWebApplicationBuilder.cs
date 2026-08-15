using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Diagnostics.Metrics;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace KamiSama.Modules;
/// <summary>
/// Wraps a <see cref="WebApplicationBuilder"/>, queues <see cref="WebModule"/> instances, and runs their service and application phases in insertion order.
/// </summary>
/// <param name="internalBuilder">The underlying ASP.NET Core builder that owns configuration, logging, services, and the final application build.</param>
public class ExtendedWebApplicationBuilder(WebApplicationBuilder internalBuilder) : IHostApplicationBuilder
{
	/// <summary>
	/// Delegates service-provider factory and optional container configuration to the underlying host builder.
	/// </summary>
	/// <typeparam name="TContainerBuilder">The container-builder type used by the service-provider factory.</typeparam>
	/// <param name="factory">The factory that creates the service provider.</param>
	/// <param name="configure">An optional callback that configures the container builder.</param>
	public void ConfigureContainer<TContainerBuilder>(IServiceProviderFactory<TContainerBuilder> factory, Action<TContainerBuilder>? configure = null) where TContainerBuilder : notnull
		=> (internalBuilder as IHostApplicationBuilder).ConfigureContainer(factory, configure);
	/// <summary>Gets the shared host-builder property dictionary from the underlying builder.</summary>
	public IDictionary<object, object> Properties => (internalBuilder as IHostApplicationBuilder).Properties;
	/// <summary>Gets the underlying application's mutable configuration manager.</summary>
	public IConfigurationManager Configuration => internalBuilder.Configuration;
	/// <summary>Gets the host environment selected by the underlying builder.</summary>
	public IHostEnvironment Environment => internalBuilder.Environment;
	/// <summary>Gets the underlying logging builder.</summary>
	public ILoggingBuilder Logging => internalBuilder.Logging;

	/// <summary>Gets the underlying metrics builder.</summary>
	public IMetricsBuilder Metrics => internalBuilder.Metrics;
	/// <summary>Gets the service collection that modules configure before application build.</summary>
	public IServiceCollection Services => internalBuilder.Services;

	private readonly List<WebModule> _modules = [];
	/// <summary>
	/// Assigns this builder to the module and appends the same instance to the ordered module queue.
	/// </summary>
	/// <param name="module">The module instance to queue. No duplicate detection is performed.</param>
	/// <returns>This builder for fluent composition.</returns>
	public ExtendedWebApplicationBuilder AddModule(WebModule module)
	{
		module.Builder = this;
		_modules.Add(module);

		return this;
	}
	/// <summary>
	/// Creates a parameterless module, assigns this builder to it, and appends it to the ordered module queue.
	/// </summary>
	/// <typeparam name="TModule">The public parameterless module type to create.</typeparam>
	/// <returns>This builder for fluent composition.</returns>
	public ExtendedWebApplicationBuilder AddModule<TModule>()
		where TModule  :WebModule,new()
		=> AddModule(new  TModule());
	/// <summary>
	/// Queues a synchronous action for the post-build phase by wrapping it in <see cref="CustomActionModule"/>.
	/// </summary>
	/// <param name="action">The action invoked with the built application when <paramref name="condition"/> is true.</param>
	/// <param name="condition">Whether the action should run during the post-build phase.</param>
	/// <returns>This builder for fluent composition.</returns>
	public ExtendedWebApplicationBuilder Add(Action<WebApplication> action, bool condition = true)
		=> this.AddAction(action, condition);
	/// <summary>
	/// Queues an asynchronous action for the post-build phase by wrapping it in <see cref="CustomActionModule"/>.
	/// </summary>
	/// <param name="action">The asynchronous action invoked with the built application when <paramref name="condition"/> is true.</param>
	/// <param name="condition">Whether the action should run during the post-build phase.</param>
	/// <returns>This builder for fluent composition.</returns>
	public ExtendedWebApplicationBuilder Add(Func<WebApplication, Task> action, bool condition = true)
		=> this.AddAction(action, condition);
	/// <summary>
	/// Invokes a service-registration callback immediately rather than queueing it as a module.
	/// </summary>
	/// <param name="configure">The callback that receives the underlying service collection.</param>
	/// <returns>This builder for fluent composition.</returns>
	public ExtendedWebApplicationBuilder ConfigureServices(Action<IServiceCollection> configure)
	{
		configure(Services);

		return this;
	}
	/// <summary>
	/// Runs every module's service phase in insertion order, builds the application once, then awaits every module's application phase in the same order.
	/// </summary>
	/// <param name="cancellationToken">The token passed to each post-build module; the underlying synchronous build does not observe it.</param>
	/// <returns>The built and configured application.</returns>
	/// <remarks>An exception in either phase stops processing; later modules are not invoked. Calling this method more than once attempts to build the same underlying builder again.</remarks>
	public async Task<WebApplication> BuildAsync(CancellationToken cancellationToken)
	{
		foreach (var module in _modules)
			module.ConfigureServices(internalBuilder.Services);

		var app = internalBuilder.Build();

		foreach (var module in _modules)
			await module.ApplyConfigurationToAsync(app, cancellationToken);
		
		return app;
	}
	/// <summary>
	/// Synchronously executes <see cref="BuildAsync"/> with <see cref="CancellationToken.None"/> and returns its result.
	/// </summary>
	/// <returns>The built and configured application.</returns>
	/// <remarks>This method blocks through <see cref="Task{TResult}.Result"/>, so asynchronous failures are surfaced through that blocking call.</remarks>
	public WebApplication Build()
		=> BuildAsync(CancellationToken.None).Result;
}
/// <summary>
/// Provides the entry point that wraps a standard <see cref="WebApplicationBuilder"/> for ordered module composition.
/// </summary>
public static class WebApplicationBuilderExtension
{
	/// <summary>
	/// Creates an extended wrapper around the supplied builder without building it or changing its services.
	/// </summary>
	/// <param name="builder">The standard application builder to wrap.</param>
	/// <returns>A new extended builder backed by <paramref name="builder"/>.</returns>
	public static ExtendedWebApplicationBuilder Extend(this WebApplicationBuilder builder)
		=> new(builder);
}
