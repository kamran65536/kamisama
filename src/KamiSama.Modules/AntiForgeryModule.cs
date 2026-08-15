

namespace KamiSama.Modules;

/// <summary>
/// Adds antiforgery middleware during the post-build phase but does not register antiforgery services.
/// </summary>
public class AntiForgeryModule : WebModule
{
	/// <summary>Performs no service registration; callers must register antiforgery services separately before build.</summary>
	/// <param name="services">The service collection, which this implementation leaves unchanged.</param>
	public override void ConfigureServices(IServiceCollection services)
	{
	}
	/// <summary>Adds ASP.NET Core antiforgery middleware by calling <see cref="AntiforgeryApplicationBuilderExtensions.UseAntiforgery"/>.</summary>
	/// <param name="app">The built application.</param>
	/// <param name="cancellationToken">Ignored by this implementation.</param>
	/// <returns>An already completed task.</returns>
	public override Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken)
	{
		app.UseAntiforgery();
	
		return Task.CompletedTask;
	}
}
/// <summary>Provides fluent registration of <see cref="AntiForgeryModule"/>.</summary>
public static class AntiForgeryExtension
{
	/// <summary>
	/// Queues antiforgery middleware without adding the required antiforgery services.
	/// </summary>
	/// <param name="builder">The builder that receives the module.</param>
	/// <returns>The same builder for fluent composition.</returns>
	public static ExtendedWebApplicationBuilder AddAntiForgery(this ExtendedWebApplicationBuilder builder)
		=> builder.AddModule(new AntiForgeryModule());
}
