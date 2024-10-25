namespace KamiSama.Extensions.WebModules;

/// <summary>
/// Adds custom action module
/// </summary>
public class CustomActionModule(Action<WebApplication> action, bool condition) : WebModule
{
	///<inheritdoc />
	public override void ConfigureServices(IServiceCollection services)
	{
	}
	///<inheritdoc />
	public override void ApplyConfigurationTo(WebApplication app)
	{
		if (condition)
			action(app);
	}
}
/// <inheritdoc />
public static class CustomActionExtension
{
	/// <summary>
	/// Adds custom action module
	/// </summary>
	public static ExtendedWebApplicationBuilder AddAction(this ExtendedWebApplicationBuilder builder, Action<WebApplication> action, bool condition = true)
		=> builder.AddModule(new CustomActionModule(action, condition));
}