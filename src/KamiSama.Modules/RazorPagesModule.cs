using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KamiSama.Modules;

/// <summary>
/// Registers Razor Pages with optional options customization and maps Razor Page endpoints after build.
/// </summary>
/// <param name="configure">An optional callback for Razor Pages options.</param>
public class RazorPagesModule(Action<RazorPagesOptions>? configure) : WebModule
{
	/// <summary>Registers Razor Pages and invokes <see cref="ConfigureRazorPages"/> for options.</summary>
	/// <param name="services">The service collection configured before build.</param>
	public override void ConfigureServices(IServiceCollection services)
	{
		services.AddRazorPages(ConfigureRazorPages);
	}
	/// <summary>Maps Razor Page endpoints at this module's position in post-build order.</summary>
	/// <param name="app">The built application.</param>
	/// <param name="cancellationToken">Ignored by this implementation.</param>
	/// <returns>An already completed task.</returns>
	public override Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken)
	{
		app.MapRazorPages();

		return Task.CompletedTask;
	}
	/// <summary>
	/// Invokes the constructor callback for Razor Pages options; derived modules can override this hook.
	/// </summary>
	/// <param name="options">The options configured during service registration.</param>
	protected virtual void ConfigureRazorPages(RazorPagesOptions options)
	{
		configure?.Invoke(options);
	}
}
/// <summary>Provides fluent registration of <see cref="RazorPagesModule"/>.</summary>
public static class RazorPagesModuleExtension
{
	/// <summary>
	/// Queues Razor Pages service registration and endpoint mapping.
	/// </summary>
	/// <param name="builder">The builder that receives the module.</param>
	/// <param name="configure">The optional Razor Pages options callback.</param>
	/// <returns>The same builder for fluent composition.</returns>
	public static ExtendedWebApplicationBuilder AddRazorPages(this ExtendedWebApplicationBuilder builder, Action<RazorPagesOptions>? configure)
		=> builder.AddModule(new RazorPagesModule(configure));
}
