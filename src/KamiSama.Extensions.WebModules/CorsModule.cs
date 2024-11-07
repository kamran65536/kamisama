
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
	public override void ApplyConfigurationTo(WebApplication app)
	{
		if (configurePolicy != null)
			app.UseCors(configurePolicy);
		else
			app.UseCors();
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
