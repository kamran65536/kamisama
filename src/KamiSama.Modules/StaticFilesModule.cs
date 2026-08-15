
namespace KamiSama.Modules;

/// <summary>
/// Maps ASP.NET Core static assets during the post-build phase without adding conventional static-file middleware.
/// </summary>
public class StaticFilesModule : WebModule
{
	/// <summary>Performs no service registration.</summary>
	/// <param name="services">The service collection, which this implementation leaves unchanged.</param>
	public override void ConfigureServices(IServiceCollection services)
	{
	}
	/// <summary>Maps static assets by calling <c>MapStaticAssets</c> at this module's position in post-build order.</summary>
	/// <param name="app">The built application.</param>
	/// <param name="cancellationToken">Ignored by this implementation.</param>
	/// <returns>An already completed task.</returns>
	public override Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken)
	{
		app.MapStaticAssets();

		return Task.CompletedTask;
	}
}
/// <summary>Provides fluent registration of <see cref="StaticFilesModule"/>.</summary>
public static class StaticFileExtension
{
	/// <summary>
	/// Queues static-asset endpoint mapping.
	/// </summary>
	/// <param name="builder">The builder that receives the module.</param>
	/// <returns>The same builder for fluent composition.</returns>
	public static ExtendedWebApplicationBuilder AddStaticFiles(this ExtendedWebApplicationBuilder builder)
		=> builder.AddModule(new StaticFilesModule());
}
