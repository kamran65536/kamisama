namespace KamiSama.Extensions.WebModules;
/// <summary>
/// Adds Https Redirection
/// </summary>
public class HttpsRedirectionModule : WebModule
{
	/// <inheritdoc />
	public override void ConfigureServices(IServiceCollection services)
	{
	}
	/// <inheritdoc />
	public override void ApplyConfigurationTo(WebApplication app)
		=> app.UseHttpsRedirection();
}
/// <inheritdoc />
public static class HttpsRedirectionExtension
{
	/// <summary>
	/// Adds Https Redirection
	/// </summary>
	/// <param name="builder"></param>
	/// <returns></returns>
	public static ExtendedWebApplicationBuilder AddHttpsRedirection(this ExtendedWebApplicationBuilder builder)
		=> builder.AddModule(new HttpsRedirectionModule());

