using Microsoft.AspNetCore.Cors.Infrastructure;

namespace KamiSama.Extensions.WebModules;

/// <summary>
/// Adds CORS module
/// </summary>
public class CorsModule(Action<CorsOptions>? configOptions, Action<CorsPolicyBuilder>? configurePolicy) : WebModule
{
	/// <inheritdoc />
	public override void ConfigureServices(IServiceCollection services)
	{
		services.AddCors(ConfigureCorsOptions);
	}
	/// <inheritdoc />
	public override Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken)
	{
		app.UseCors(ConfigureCorsPolicy);

		return Task.CompletedTask;
	}
	/// <summary>
	/// Configures the cors options for inheritance
	/// </summary>
	/// <param name="options"></param>
	protected virtual void ConfigureCorsOptions(CorsOptions options)
	{
		configOptions?.Invoke(options);
	}
	/// <summary>
	/// Configures the cors builder for inheritance
	/// </summary>
	/// <param name="builder"></param>
	protected virtual void ConfigureCorsPolicy(CorsPolicyBuilder builder)
	{
		configurePolicy?.Invoke(builder);
	}
}
/// <inheritdoc />
public static class CorsExtension
{
	/// <summary>
	/// Adds CORS module
	/// </summary>
	public static ExtendedWebApplicationBuilder AddCors(this ExtendedWebApplicationBuilder builder, Action<CorsOptions>? configOptions = null, Action<CorsPolicyBuilder>? configurePolicy = null)
		=> builder.AddModule(new CorsModule(configOptions, configurePolicy));
}
