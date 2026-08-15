using Microsoft.AspNetCore.ResponseCompression;

namespace KamiSama.Modules;
/// <summary>
/// Registers response-compression services with optional configuration and adds compression middleware after build.
/// </summary>
/// <param name="configure">An optional callback for response-compression options.</param>
public class ResponseCompressionModule(Action<ResponseCompressionOptions>? configure) : WebModule
{
	/// <summary>Registers response-compression services and invokes <see cref="ConfigureCompressionOptions"/> for options.</summary>
	/// <param name="services">The service collection configured before build.</param>
	public override void ConfigureServices(IServiceCollection services)
	{
		services.AddResponseCompression(ConfigureCompressionOptions);
	}
	/// <summary>
	/// Invokes the constructor callback for response-compression options; derived modules can override this hook.
	/// </summary>
	/// <param name="options">The response-compression options configured before build.</param>
	protected virtual void ConfigureCompressionOptions(ResponseCompressionOptions options)
	{
		configure?.Invoke(options);
	}
	/// <summary>Adds response-compression middleware at this module's position in the ordered pipeline.</summary>
	/// <param name="app">The built application.</param>
	/// <param name="cancellationToken">Ignored by this implementation.</param>
	/// <returns>An already completed task.</returns>
	public override Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken)
	{
		app.UseResponseCompression();

		return Task.CompletedTask;
	}
}
/// <summary>Provides fluent registration of <see cref="ResponseCompressionModule"/>.</summary>
public static class ResponseCompressionExtension
{
	/// <summary>
	/// Queues response-compression services and middleware.
	/// </summary>
	/// <param name="builder">The builder that receives the module.</param>
	/// <param name="configure">An optional response-compression options callback.</param>
	/// <returns>The same builder for fluent composition.</returns>
	public static ExtendedWebApplicationBuilder AddResponseCompression(this ExtendedWebApplicationBuilder builder, Action<ResponseCompressionOptions>? configure)
		=> builder.AddModule(new ResponseCompressionModule(configure));
}
