
namespace KamiSama.Modules;
/// <summary>
/// Adds HTTPS redirection middleware during the post-build phase without registering or configuring redirection options.
/// </summary>
public class HttpsRedirectionModule : WebModule
{
	/// <summary>Performs no service registration.</summary>
	/// <param name="services">The service collection, which this implementation leaves unchanged.</param>
	public override void ConfigureServices(IServiceCollection services)
	{
	}
	/// <summary>Adds HTTPS redirection middleware at this module's position in the ordered pipeline.</summary>
	/// <param name="app">The built application.</param>
	/// <param name="cancellationToken">Ignored by this implementation.</param>
	/// <returns>An already completed task.</returns>
	public override Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken)
	{
		app.UseHttpsRedirection();

		return Task.CompletedTask;
	}
}
/// <summary>Provides fluent registration of <see cref="HttpsRedirectionModule"/>.</summary>
public static class HttpsRedirectionExtension
{
	/// <summary>
	/// Queues HTTPS redirection middleware.
	/// </summary>
	/// <param name="builder">The builder that receives the module.</param>
	/// <returns>The same builder for fluent composition.</returns>
	public static ExtendedWebApplicationBuilder AddHttpsRedirection(this ExtendedWebApplicationBuilder builder)
		=> builder.AddModule(new HttpsRedirectionModule());
}

