using KamiSama.Extensions.DependencyInjection;
using KamiSama.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KamiSama.ExternalServices.Sms.NeoZarin;

internal class NeoZarinSmsModule(IConfigurationSection neoZarinSection) : WebModule
{
	/// <summary> Binds NeoZarin options and scans this package for its scoped keyed provider registration. </summary>
	/// <param name="services">The application service collection.</param>
    public override void ConfigureServices(IServiceCollection services)
	{
		services.Configure<NeoZarinSmsOptions>(neoZarinSection);

		services.AutoAddDependenciesFrom<NeoZarinSmsModule>();
	}

	/// <summary> Completes without applying middleware or endpoints. </summary>
	/// <param name="app">The built web application.</param>
	/// <param name="cancellationToken">The token used to cancel post-build configuration.</param>
	/// <returns>A completed task.</returns>
	public override Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken)
	{
		return Task.CompletedTask;
	}
}

/// <summary>
/// Adds NeoZarin options binding and the scoped keyed <c>neo-zarin</c> SMS provider to an extended ASP.NET Core application builder.
/// </summary>
public static class ExtendedWebApplicationBuilderExtensions
{
	/// <summary>
	/// Adds the NeoZarin SMS module; register <c>HttpClient</c> and KamiSama RestSharp first, then call <c>Build</c> or <c>BuildAsync</c> so this module registers its services.
	/// </summary>
	/// <param name="builder">The extended application builder receiving the module.</param>
	/// <param name="neoZarinSection">The configuration section containing NeoZarin endpoint, credential, sender, and API settings.</param>
	/// <returns>The same builder so core SMS and application modules can be chained.</returns>
	public static ExtendedWebApplicationBuilder AddNeoZarinSmsModule(this ExtendedWebApplicationBuilder builder, IConfigurationSection neoZarinSection)
		=> builder.AddModule(new NeoZarinSmsModule(neoZarinSection));
}
