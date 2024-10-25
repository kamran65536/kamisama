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
	public override void ApplyConfigurationTo(WebApplication app)
		=> app.UseAuthorization();
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
		=> builder.AddAuthorization();
}