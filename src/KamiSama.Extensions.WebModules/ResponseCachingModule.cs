using Microsoft.AspNetCore.ResponseCaching;

namespace KamiSama.Extensions.WebModules;

/// <summary>
/// Adds response caching module to app
/// </summary>
public class ResponseCachingModule(Action<ResponseCachingOptions>? configure) : WebModule
{
	/// <inheritdoc />
	public override void ConfigureServices(IServiceCollection services)
	{
		services.AddResponseCaching(ConfigureResponseCachingOptions);
	}
	/// <summary>
	/// configures the response caching options, by default it calls configure parameter from the constructor
	/// </summary>
	protected virtual void ConfigureResponseCachingOptions(ResponseCachingOptions options)
		=> configure?.Invoke(options);
	/// <inheritdoc />
	public override Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}
}
/// <inheritdoc />
public static class ResponseCachingExtension
{
	/// <summary>
	/// Adds response compression module to app
	/// </summary>
	public static ExtendedWebApplicationBuilder AddResponseCaching(this ExtendedWebApplicationBuilder builder, Action<ResponseCachingOptions>? configure)
		=> builder.AddModule(new ResponseCachingModule(configure));
}