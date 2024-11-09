
namespace KamiSama.Extensions.WebModules;

/// <summary>
/// Adds HSTS (HTTP Strict Transport Security)
/// </summary>
public class HstsModule : WebModule
{
	/// <inheritdoc />
	public override void ConfigureServices(IServiceCollection services)
	{
	}
	/// <inheritdoc />
	public override Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken)
	{
		app.UseHsts();

		return Task.CompletedTask;
	}
}
/// <inheritdoc />
public static class HstsExtension
{
	/// <summary>
	/// Adds HSTS (HTTP Strict Transport Security)
	/// </summary>
	public static ExtendedWebApplicationBuilder AddHsts(this ExtendedWebApplicationBuilder builder)
		=> builder.AddModule(new HstsModule());
}