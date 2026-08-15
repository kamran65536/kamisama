using Microsoft.AspNetCore.Cors.Infrastructure;

namespace KamiSama.Modules;

/// <summary>
/// Registers CORS options before build and adds policy middleware configured by a callback afterward.
/// </summary>
/// <param name="configOptions">An optional callback used while CORS services configure named policies and options.</param>
/// <param name="configurePolicy">An optional callback used to build the inline middleware policy.</param>
public class CorsModule(Action<CorsOptions>? configOptions, Action<CorsPolicyBuilder>? configurePolicy) : WebModule
{
	/// <summary>Registers CORS services and routes options configuration through <see cref="ConfigureCorsOptions"/>.</summary>
	/// <param name="services">The service collection configured before build.</param>
	public override void ConfigureServices(IServiceCollection services)
	{
		services.AddCors(ConfigureCorsOptions);
	}
	/// <summary>Adds CORS middleware with the inline policy produced by <see cref="ConfigureCorsPolicy"/>.</summary>
	/// <param name="app">The built application.</param>
	/// <param name="cancellationToken">Ignored by this implementation.</param>
	/// <returns>An already completed task.</returns>
	public override Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken)
	{
		app.UseCors(ConfigureCorsPolicy);

		return Task.CompletedTask;
	}
	/// <summary>
	/// Invokes the constructor callback for service-level CORS options; derived modules can override the hook.
	/// </summary>
	/// <param name="options">The CORS options being registered.</param>
	protected virtual void ConfigureCorsOptions(CorsOptions options)
	{
		configOptions?.Invoke(options);
	}
	/// <summary>
	/// Invokes the constructor callback for the inline CORS policy; derived modules can override the hook.
	/// </summary>
	/// <param name="builder">The policy builder supplied by CORS middleware registration.</param>
	protected virtual void ConfigureCorsPolicy(CorsPolicyBuilder builder)
	{
		configurePolicy?.Invoke(builder);
	}
}
/// <summary>Provides fluent registration of <see cref="CorsModule"/>.</summary>
public static class CorsExtension
{
	/// <summary>
	/// Queues CORS services and inline policy middleware.
	/// </summary>
	/// <param name="builder">The builder that receives the module.</param>
	/// <param name="configOptions">An optional service-level CORS options callback.</param>
	/// <param name="configurePolicy">An optional inline middleware policy callback.</param>
	/// <returns>The same builder for fluent composition.</returns>
	public static ExtendedWebApplicationBuilder AddCors(this ExtendedWebApplicationBuilder builder, Action<CorsOptions>? configOptions = null, Action<CorsPolicyBuilder>? configurePolicy = null)
		=> builder.AddModule(new CorsModule(configOptions, configurePolicy));
}
