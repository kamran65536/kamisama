
namespace KamiSama.Extensions.WebModules;

/// <summary>
/// Adds custom action module
/// </summary>
public class CustomActionModule(Func<WebApplication, Task> action, bool condition) : WebModule
{
	///<inheritdoc />
	public override void ConfigureServices(IServiceCollection services)
	{
	}
	///<inheritdoc />
	public override async Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken)
	{
		if (condition)
			await action(app);
	}
}
/// <inheritdoc />
public static class CustomActionExtension
{
	/// <summary>
	/// Adds custom action module
	/// </summary>
	public static ExtendedWebApplicationBuilder AddAction(this ExtendedWebApplicationBuilder builder, Action<WebApplication> action, bool condition = true)
		=> builder.AddModule(new CustomActionModule(app => { action(app); return Task.CompletedTask; }, condition));
	/// <summary>
	/// Adds custom action module
	/// </summary>
	public static ExtendedWebApplicationBuilder AddAction(this ExtendedWebApplicationBuilder builder, Func<WebApplication, Task> action, bool condition = true)
		=> builder.AddModule(new CustomActionModule(action, condition));
}