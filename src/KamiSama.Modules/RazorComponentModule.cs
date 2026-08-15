

namespace KamiSama.Modules;
/// <summary>
/// Registers Razor components and maps one root component with optional endpoint customization.
/// </summary>
/// <typeparam name="TRootComponent">The root component type mapped after build.</typeparam>
/// <param name="configure">An optional callback for the mapped component endpoint builder.</param>
public class RazorComponentModule<TRootComponent>(Action<RazorComponentsEndpointConventionBuilder>? configure) : WebModule
{
	/// <summary>Registers Razor component services with default options.</summary>
	/// <param name="services">The service collection configured before build.</param>
	public override void ConfigureServices(IServiceCollection services)
	{
		services.AddRazorComponents();
	}
	/// <summary>Maps <typeparamref name="TRootComponent"/> and invokes <see cref="ConfigureRazorComponents"/> on the endpoint builder.</summary>
	/// <param name="app">The built application.</param>
	/// <param name="cancellationToken">Ignored by this implementation.</param>
	/// <returns>An already completed task.</returns>
	public override Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken)
	{
		var builder = app.MapRazorComponents<TRootComponent>();

		ConfigureRazorComponents(builder);

		return Task.CompletedTask;
	}
	/// <summary>
	/// Invokes the constructor callback for the mapped Razor component endpoint; derived modules can override this hook.
	/// </summary>
	/// <param name="builder">The endpoint convention builder returned when the root component is mapped.</param>
	protected virtual void ConfigureRazorComponents(RazorComponentsEndpointConventionBuilder builder)
	{
		configure?.Invoke(builder);
	}
}
/// <summary>Provides fluent registration and mapping of a root Razor component.</summary>
public static class RazorComponentExtension
{
	/// <summary>
	/// Queues Razor component services and root-component endpoint mapping.
	/// </summary>
	/// <typeparam name="TRootComponent">The root component type to map.</typeparam>
	/// <param name="builder">The builder that receives the module.</param>
	/// <param name="configure">An optional endpoint convention callback.</param>
	/// <returns>The same builder for fluent composition.</returns>
	public static ExtendedWebApplicationBuilder AddRazorComponents<TRootComponent>(this ExtendedWebApplicationBuilder builder, Action<RazorComponentsEndpointConventionBuilder>? configure = null)
		=> builder.AddModule(new RazorComponentModule<TRootComponent>(configure));
}
