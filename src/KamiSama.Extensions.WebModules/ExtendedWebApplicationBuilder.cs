using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Diagnostics.Metrics;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace KamiSama.Extensions.WebModules;
/// <summary>
/// Extended Host Application concept to add ApplyModule to it.
/// </summary>
/// <param name="internalBuilder"></param>
public class ExtendedWebApplicationBuilder(WebApplicationBuilder internalBuilder) : IHostApplicationBuilder
{
	/// <inheritdoc />
	public void ConfigureContainer<TContainerBuilder>(IServiceProviderFactory<TContainerBuilder> factory, Action<TContainerBuilder>? configure = null) where TContainerBuilder : notnull
		=> (internalBuilder as IHostApplicationBuilder).ConfigureContainer(factory, configure);
	/// <inheritdoc />
	public IDictionary<object, object> Properties => (internalBuilder as IHostApplicationBuilder).Properties;
	/// <inheritdoc />
	public IConfigurationManager Configuration => internalBuilder.Configuration;
	/// <inheritdoc />
	public IHostEnvironment Environment => internalBuilder.Environment;
	/// <inheritdoc />
	public ILoggingBuilder Logging => internalBuilder.Logging;

	/// <inheritdoc />
	public IMetricsBuilder Metrics => internalBuilder.Metrics;
	/// <inheritdoc />
	public IServiceCollection Services => internalBuilder.Services;

	private readonly List<WebModule> _modules = [];
	/// <summary>
	/// Adds a new web module to be applied
	/// </summary>
	public ExtendedWebApplicationBuilder AddModule(WebModule module)
	{
		module.Builder = this;
		_modules.Add(module);

		return this;
	}
	/// <summary>
	/// Adds a new web module to be applied
	/// </summary>
	public ExtendedWebApplicationBuilder AddModule<TModule>()
		where TModule  :WebModule,new()
		=> AddModule(new  TModule());
	/// <summary>
	/// adds a custom action to run
	/// </summary>
	public ExtendedWebApplicationBuilder Add(Action<WebApplication> action, bool condition = true)
		=> this.AddAction(action, condition);
	/// <summary>
	/// adds a custom action to run
	/// </summary>
	public ExtendedWebApplicationBuilder Add(Func<WebApplication, Task> action, bool condition = true)
		=> this.AddAction(action, condition);
	/// <summary>
	/// Configures services
	/// </summary>
	public ExtendedWebApplicationBuilder ConfigureServices(Action<IServiceCollection> configure)
	{
		configure(Services);

		return this;
	}
	/// <summary>
	/// Builds the application
	/// </summary>
	public async Task<WebApplication> BuildAsync()
	{
		foreach (var module in _modules)
			module.ConfigureServices(internalBuilder.Services);

		var app = internalBuilder.Build();

		foreach (var module in _modules)
			await module.ApplyConfigurationToAsync(app);
		
		return app;
	}
	/// <summary>
	/// Synchronous 
	/// </summary>
	/// <returns></returns>
	public WebApplication Build()
		=> BuildAsync().Result;
}
/// <inheritdoc />
public static class WebApplicationBuilderExtension
{
	/// <summary>
	/// Extends Web Application builder functionalities
	/// </summary>
	/// <param name="builder"></param>
	/// <returns></returns>
	public static ExtendedWebApplicationBuilder Extend(this WebApplicationBuilder builder)
		=> new(builder);
}