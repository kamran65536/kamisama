
namespace KamiSama.Extensions.WebModules;

/// <summary>
/// Adds Cascading Authentication State
/// </summary>
public class CascadingAuthenticationModule : WebModule
{
	/// <inheritdoc />
	public override void ConfigureServices(IServiceCollection services)
	{
		services.AddCascadingAuthenticationState();
	}
	/// <inheritdoc />
	public override Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken)
	{
		return Task.CompletedTask;
	}
}
/// <inheritdoc />
public static class CascadingAuthenticationExtension
{
	/// <summary>
	/// Adds Cascading Authentication State
	/// </summary>
	public static ExtendedWebApplicationBuilder AddCascadingAuthentication(this ExtendedWebApplicationBuilder builder)
		=> builder.AddModule(new CascadingAuthenticationModule());
}