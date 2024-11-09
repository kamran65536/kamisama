namespace KamiSama.Extensions.WebModules;

/// <summary>
/// Adds Authorization functionality
/// </summary>
public class AuthorizationModule : WebModule
{
	/// <inheritdoc />
	public override void ConfigureServices(IServiceCollection services)
		=> services.AddAuthorization();
	/// <inheritdoc />
	public override Task ApplyConfigurationToAsync(WebApplication app)
	{
		app.UseAuthorization();

		return Task.CompletedTask;
	}
}
/// <inheritdoc />
public static class AuthorizationExtension
{
	/// <summary>
	/// Adds Authorization functionality
	/// </summary>
	/// <param name="builder"></param>
	/// <returns></returns>
	public static ExtendedWebApplicationBuilder AddAuthorization(this ExtendedWebApplicationBuilder builder)
		=> builder.AddModule(new AuthorizationModule());
}