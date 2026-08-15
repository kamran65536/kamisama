
namespace KamiSama.Modules;

/// <summary>
/// Registers MVC controllers, optionally customizes the resulting MVC builder, and maps controller endpoints after build.
/// </summary>
/// <param name="configure">An optional callback invoked after <c>AddControllers</c> returns its MVC builder.</param>
public class ControllersModule(Action<IMvcBuilder>? configure) : WebModule
{
	/// <summary>Calls <c>AddControllers</c> and passes the resulting builder to <see cref="ConfigureMvcBuilder"/>.</summary>
	/// <param name="services">The service collection configured before build.</param>
	public override void ConfigureServices(IServiceCollection services)
	{
		var mvcBuilder = services.AddControllers();

		ConfigureMvcBuilder(mvcBuilder);
	}
	/// <summary>Maps attribute-routed controller endpoints at this module's position in post-build order.</summary>
	/// <param name="app">The built application.</param>
	/// <param name="cancellationToken">Ignored by this implementation.</param>
	/// <returns>An already completed task.</returns>
	public override Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken)
	{
		app.MapControllers();

		return Task.CompletedTask;
	}
	/// <summary>
	/// Invokes the constructor callback for the MVC builder; derived modules can override this hook to add controller conventions or features.
	/// </summary>
	/// <param name="builder">The MVC builder returned by service registration.</param>
	protected virtual void ConfigureMvcBuilder(IMvcBuilder builder)
	{
		configure?.Invoke(builder);
	}
}
/// <summary>Provides fluent registration of <see cref="ControllersModule"/>.</summary>
public static class ControllersModuleExtension
{
	/// <summary>
	/// Queues controller service registration and endpoint mapping.
	/// </summary>
	/// <param name="builder">The builder that receives the module.</param>
	/// <param name="configure">An optional callback for the MVC builder.</param>
	/// <returns>The same builder for fluent composition.</returns>
	public static ExtendedWebApplicationBuilder AddControllers(this ExtendedWebApplicationBuilder builder, Action<IMvcBuilder>? configure = null)
		=> builder.AddModule(new ControllersModule(configure));
}
