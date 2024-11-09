
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace KamiSama.Extensions.WebModules;

/// <summary>
/// Adds CORS module
/// </summary>
public class CorsModule(Action<CorsPolicyBuilder>? configurePolicy) : WebModule
{
	/// <inheritdoc />
	public override void ConfigureServices(IServiceCollection services)
	{
	}
	/// <inheritdoc />
	public override Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken)
	{
		app.UseCors(ConfigureCorsPolicy);

		return Task.CompletedTask;
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
	public static ExtendedWebApplicationBuilder AddCors(this ExtendedWebApplicationBuilder builder, Action<CorsPolicyBuilder>? configurePolicy)
		=> builder.AddModule(new CorsModule(configurePolicy));
}
