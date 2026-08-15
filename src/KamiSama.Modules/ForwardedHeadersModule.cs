
namespace KamiSama.Modules;

/// <summary>
/// Creates forwarded-header options after build and adds forwarded-header middleware with caller or derived-type customization.
/// </summary>
/// <param name="configure">An optional callback that configures the newly created middleware options.</param>
public class ForwardedHeadersModule(Action<ForwardedHeadersOptions>? configure) : WebModule
{
	/// <summary>Performs no service registration because the middleware options are constructed during the post-build phase.</summary>
	/// <param name="services">The service collection, which this implementation leaves unchanged.</param>
	public override void ConfigureServices(IServiceCollection services)
	{
	}
	/// <summary>Creates options, invokes <see cref="ConfigureForwaredHeadersOptions"/>, and adds forwarded-header middleware at this module's ordered position.</summary>
	/// <param name="app">The built application.</param>
	/// <param name="cancellationToken">Ignored by this implementation.</param>
	/// <returns>An already completed task.</returns>
	public override Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken)
	{
		var options = new ForwardedHeadersOptions();

		ConfigureForwaredHeadersOptions(options);

		app.UseForwardedHeaders(options);

		return Task.CompletedTask;
	}
	/// <summary>
	/// Invokes the constructor callback for forwarded-header options; derived modules can override this hook.
	/// </summary>
	/// <param name="options">The newly created options passed to middleware registration.</param>
	protected virtual void ConfigureForwaredHeadersOptions(ForwardedHeadersOptions options)
	{
		configure?.Invoke(options);
	}
}
/// <summary>Provides fluent registration of <see cref="ForwardedHeadersModule"/>.</summary>
public static class ForwardedHeadersExtension
{
	/// <summary>
	/// Queues forwarded-header middleware with optional options customization.
	/// </summary>
	/// <param name="builder">The builder that receives the module.</param>
	/// <param name="configure">An optional forwarded-header options callback.</param>
	/// <returns>The same builder for fluent composition.</returns>
	public static ExtendedWebApplicationBuilder AddForwardedHeaders(this ExtendedWebApplicationBuilder builder, Action<ForwardedHeadersOptions>? configure = null)
		=> builder.AddModule(new ForwardedHeadersModule(configure));
}
