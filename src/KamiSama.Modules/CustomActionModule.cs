
namespace KamiSama.Modules;

/// <summary>
/// Runs a caller-provided asynchronous application action during the post-build phase when its captured condition is true.
/// </summary>
/// <param name="action">The application action to await.</param>
/// <param name="condition">Whether the action should run.</param>
public class CustomActionModule(Func<WebApplication, Task> action, bool condition) : WebModule
{
	/// <summary>Performs no service registration.</summary>
	/// <param name="services">The service collection, which this implementation leaves unchanged.</param>
	public override void ConfigureServices(IServiceCollection services)
	{
	}
	/// <summary>Awaits the captured action when the captured condition is true; otherwise completes without invoking it.</summary>
	/// <param name="app">The built application passed to the action.</param>
	/// <param name="cancellationToken">Ignored and not forwarded to the action.</param>
	/// <returns>A task representing action execution.</returns>
	public override async Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken)
	{
		if (condition)
			await action(app);
	}
}
/// <summary>Provides fluent synchronous and asynchronous custom post-build actions.</summary>
public static class CustomActionExtension
{
	/// <summary>
	/// Wraps a synchronous application action in a queued <see cref="CustomActionModule"/>.
	/// </summary>
	/// <param name="builder">The builder that receives the module.</param>
	/// <param name="action">The action to invoke after build.</param>
	/// <param name="condition">Whether the action should run.</param>
	/// <returns>The same builder for fluent composition.</returns>
	public static ExtendedWebApplicationBuilder AddAction(this ExtendedWebApplicationBuilder builder, Action<WebApplication> action, bool condition = true)
		=> builder.AddModule(new CustomActionModule(app => { action(app); return Task.CompletedTask; }, condition));
	/// <summary>
	/// Queues an asynchronous application action in a <see cref="CustomActionModule"/>.
	/// </summary>
	/// <param name="builder">The builder that receives the module.</param>
	/// <param name="action">The asynchronous action to invoke after build.</param>
	/// <param name="condition">Whether the action should run.</param>
	/// <returns>The same builder for fluent composition.</returns>
	public static ExtendedWebApplicationBuilder AddAction(this ExtendedWebApplicationBuilder builder, Func<WebApplication, Task> action, bool condition = true)
		=> builder.AddModule(new CustomActionModule(action, condition));
}
