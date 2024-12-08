using Microsoft.AspNetCore.ResponseCompression;

namespace KamiSama.Extensions.WebModules;
/// <summary>
/// Adds response compression module to app
/// </summary>
public class ResponseCompressionModule(Action<ResponseCompressionOptions>? configure) : WebModule
{
	/// <inheritdoc />
	public override void ConfigureServices(IServiceCollection services)
	{
		services.AddResponseCompression(ConfigureCompressionOptions);
	}
	/// <summary>
	/// configures the compression options, by default it calls configure parameter from the constructor
	/// </summary>
	protected virtual void ConfigureCompressionOptions(ResponseCompressionOptions options)
	{
		configure?.Invoke(options);
	}
	/// <inheritdoc />
	public override Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken)
	{
		app.UseResponseCompression();

		return Task.CompletedTask;
	}
}
/// <inheritdoc />
public static class ResponseCompressionExtension
{
	/// <summary>
	/// Adds response compression module to app
	/// </summary>
	public static ExtendedWebApplicationBuilder AddResponseCompression(this ExtendedWebApplicationBuilder builder, Action<ResponseCompressionOptions>? configure)
		=> builder.AddModule(new ResponseCompressionModule(configure));
}
