
namespace KamiSama.Modules;

/// <summary>
/// Registers authorization services before build and adds authorization middleware afterward.
/// </summary>
public class AuthorizationModule : WebModule
{
	/// <summary>Registers ASP.NET Core authorization services with default options.</summary>
	/// <param name="services">The service collection configured before build.</param>
	public override void ConfigureServices(IServiceCollection services)
		=> services.AddAuthorization();
	/// <summary>Adds authorization middleware at this module's position in the ordered post-build pipeline.</summary>
	/// <param name="app">The built application.</param>
	/// <param name="cancellationToken">Ignored by this implementation.</param>
	/// <returns>An already completed task.</returns>
	public override Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken)
	{
		app.UseAuthorization();

		return Task.CompletedTask;
	}
}
/// <summary>Provides fluent registration of <see cref="AuthorizationModule"/>.</summary>
public static class AuthorizationExtension
{
	/// <summary>
	/// Queues authorization service and middleware configuration.
	/// </summary>
	/// <param name="builder">The builder that receives the module.</param>
	/// <returns>The same builder for fluent composition.</returns>
	public static ExtendedWebApplicationBuilder AddAuthorization(this ExtendedWebApplicationBuilder builder)
		=> builder.AddModule(new AuthorizationModule());
}
