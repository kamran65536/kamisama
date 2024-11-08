namespace KamiSama.Extensions.WebModules;

/// <summary>
/// Adds Forwarded headers
/// </summary>
public class ForwardedHeadersModule(Action<ForwardedHeadersOptions>? configure) : WebModule
{
	/// <inheritdoc />
	public override void ConfigureServices(IServiceCollection services)
	{
	}
	/// <inheritdoc />
	public override void ApplyConfigurationTo(WebApplication app)
	{
		var options = new ForwardedHeadersOptions();

		ConfigureForwaredHeadersOptions(options);

		app.UseForwardedHeaders(options);
	}
	/// <summary>
	/// Configures the forwarded headers options for inheritance
	/// </summary>
	protected virtual void ConfigureForwaredHeadersOptions(ForwardedHeadersOptions options)
	{
		configure?.Invoke(options);
	}
}
/// <inheritdoc />
public static class ForwardedHeadersExtension
{
	/// <summary>
	/// Adds Forwarded headers
	/// </summary>
	public static ExtendedWebApplicationBuilder AddForwardedHeaders(this ExtendedWebApplicationBuilder builder, Action<ForwardedHeadersOptions>? configure = null)
		=> builder.AddModule(new ForwardedHeadersModule(configure));
}