using KamiSama.Extensions.DependencyInjection;
using KamiSama.Extensions.WebModules;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KamiSama.ExternalServices.Sms.NeoZarin;

internal class NeoZarinSmsModule(IConfigurationSection neoZarinSection) : WebModule
{
    public override void ConfigureServices(IServiceCollection services)
	{
		services.Configure<NeoZarinSmsOptions>(neoZarinSection);

		services.AutoAddDependenciesFrom<NeoZarinSmsModule>();
	}

	public override Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken)
	{
		return Task.CompletedTask;
	}
}
public static class ExtendedWebApplicationBuilderExtensions
{
	public static ExtendedWebApplicationBuilder AddNeoZarinSmsModule(this ExtendedWebApplicationBuilder builder, IConfigurationSection neoZarinSection)
		=> builder.AddModule(new NeoZarinSmsModule(neoZarinSection));
}
