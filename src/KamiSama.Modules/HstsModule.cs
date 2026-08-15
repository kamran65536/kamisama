
namespace KamiSama.Modules;

/// <summary>
/// Adds HTTP Strict Transport Security middleware during the post-build phase without registering or configuring HSTS options.
/// </summary>
public class HstsModule : WebModule
{
	/// <summary>Performs no service registration.</summary>
	/// <param name="services">The service collection, which this implementation leaves unchanged.</param>
	public override void ConfigureServices(IServiceCollection services)
	{
	}
	/// <summary>Adds HSTS middleware at this module's position in the ordered pipeline.</summary>
	/// <param name="app">The built application.</param>
	/// <param name="cancellationToken">Ignored by this implementation.</param>
	/// <returns>An already completed task.</returns>
	public override Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken)
	{
		app.UseHsts();

		return Task.CompletedTask;
	}
}
/// <summary>Provides fluent registration of <see cref="HstsModule"/>.</summary>
public static class HstsExtension
{
	/// <summary>
	/// Queues HSTS middleware.
	/// </summary>
	/// <param name="builder">The builder that receives the module.</param>
	/// <returns>The same builder for fluent composition.</returns>
	public static ExtendedWebApplicationBuilder AddHsts(this ExtendedWebApplicationBuilder builder)
		=> builder.AddModule(new HstsModule());
}
