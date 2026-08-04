using KamiSama.Extensions.DependencyInjection;
using KamiSama.Extensions.WebModules;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KamiSama.ExternalServices.Sms.Kavenegar;

internal class KavenegarModule(IConfigurationSection kavenegarSection) : WebModule
{
	public override void ConfigureServices(IServiceCollection services)
	{
		services.Configure<KavenegarSmsOptions>(kavenegarSection);

		services.AutoAddDependenciesFrom<KavenegarModule>();
	}
	public override Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken)
	{
		return Task.CompletedTask;
	}
}
public static class ExtendedWebApplicationBuilderExtensions
{
	public static ExtendedWebApplicationBuilder AddKavenegarSmsServiceModule(this ExtendedWebApplicationBuilder builder, IConfigurationSection kavenegarSection)
		=> builder.AddModule(new KavenegarModule(kavenegarSection));
}