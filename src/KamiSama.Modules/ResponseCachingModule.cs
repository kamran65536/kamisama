using Microsoft.AspNetCore.ResponseCaching;

namespace KamiSama.Modules;

/// <summary>
/// Registers response-caching services but cannot complete the post-build phase because application configuration throws <see cref="NotImplementedException"/>.
/// </summary>
/// <param name="configure">An optional callback for response-caching options.</param>
public class ResponseCachingModule(Action<ResponseCachingOptions>? configure) : WebModule
{
	/// <summary>Registers response-caching services and invokes <see cref="ConfigureResponseCachingOptions"/> for options.</summary>
	/// <param name="services">The service collection configured before build.</param>
	public override void ConfigureServices(IServiceCollection services)
	{
		services.AddResponseCaching(ConfigureResponseCachingOptions);
	}
	/// <summary>
	/// Invokes the constructor callback for response-caching options; derived modules can override this hook.
	/// </summary>
	/// <param name="options">The response-caching options configured before build.</param>
	protected virtual void ConfigureResponseCachingOptions(ResponseCachingOptions options)
		=> configure?.Invoke(options);
	/// <summary>Always throws <see cref="NotImplementedException"/> and never adds response-caching middleware.</summary>
	/// <param name="app">The built application, which is not modified.</param>
	/// <param name="cancellationToken">Ignored because the method throws immediately.</param>
	/// <returns>This method does not return a task.</returns>
	/// <exception cref="NotImplementedException">Always thrown. Consequently, adding this module makes <see cref="ExtendedWebApplicationBuilder.BuildAsync"/> and <see cref="ExtendedWebApplicationBuilder.Build"/> fail during post-build configuration.</exception>
	public override Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}
}
/// <summary>Provides fluent registration of the currently incomplete <see cref="ResponseCachingModule"/>.</summary>
public static class ResponseCachingExtension
{
	/// <summary>
	/// Queues response-caching service registration; the subsequent application build fails when the module's post-build method throws.
	/// </summary>
	/// <param name="builder">The builder that receives the module.</param>
	/// <param name="configure">An optional response-caching options callback.</param>
	/// <returns>The same builder for fluent composition.</returns>
	public static ExtendedWebApplicationBuilder AddResponseCaching(this ExtendedWebApplicationBuilder builder, Action<ResponseCachingOptions>? configure)
		=> builder.AddModule(new ResponseCachingModule(configure));
}
