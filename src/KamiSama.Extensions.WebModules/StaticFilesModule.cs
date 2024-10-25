namespace KamiSama.Extensions.WebModules;

/// <summary>
/// Adds Static files
/// </summary>
public class StaticFilesModule : WebModule
{
	/// <inheritdoc />
	public override void ConfigureServices(IServiceCollection services)
	{
	}
	/// <inheritdoc />
	public override void ApplyConfigurationTo(WebApplication app)
		=> app.UseStaticFiles();
}
/// <inheritdoc />
public static class StaticFileExtension
{
	/// <summary>
	/// Adds Static files
	/// </summary>
	public static ExtendedWebApplicationBuilder AddStaticFiles(this ExtendedWebApplicationBuilder builder)
		=> builder.AddModule(new StaticFilesModule());
}
