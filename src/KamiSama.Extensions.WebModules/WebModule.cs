using Microsoft.Extensions.Hosting;

namespace KamiSama.Extensions.WebModules;
/// <summary>
/// Web Module to be applied
/// </summary>
public abstract class WebModule
{
	/// <summary>
	/// Parent builder
	/// </summary>
	protected internal IHostApplicationBuilder Builder { get; internal set; } = default!;
	/// <summary>
	/// Configure Services before build
	/// </summary>
	/// <param name="services"></param>
	public abstract void ConfigureServices(IServiceCollection services);
	/// <summary>
	/// Configures the application it self.
	/// </summary>
	/// <param name="app"></param>
	public abstract Task ApplyConfigurationToAsync(WebApplication app);
}
