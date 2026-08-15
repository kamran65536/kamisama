
namespace KamiSama.Modules;

/// <summary>
/// Registers Blazor cascading authentication-state services and performs no post-build application configuration.
/// </summary>
public class CascadingAuthenticationModule : WebModule
{
	/// <summary>Registers cascading authentication-state services for Razor components.</summary>
	/// <param name="services">The service collection configured before build.</param>
	public override void ConfigureServices(IServiceCollection services)
	{
		services.AddCascadingAuthenticationState();
	}
	/// <summary>Performs no post-build work.</summary>
	/// <param name="app">The built application, which this implementation leaves unchanged.</param>
	/// <param name="cancellationToken">Ignored by this implementation.</param>
	/// <returns>An already completed task.</returns>
	public override Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken)
	{
		return Task.CompletedTask;
	}
}
/// <summary>Provides fluent registration of <see cref="CascadingAuthenticationModule"/>.</summary>
public static class CascadingAuthenticationExtension
{
	/// <summary>
	/// Queues cascading authentication-state service registration.
	/// </summary>
	/// <param name="builder">The builder that receives the module.</param>
	/// <returns>The same builder for fluent composition.</returns>
	public static ExtendedWebApplicationBuilder AddCascadingAuthentication(this ExtendedWebApplicationBuilder builder)
		=> builder.AddModule(new CascadingAuthenticationModule());
}
