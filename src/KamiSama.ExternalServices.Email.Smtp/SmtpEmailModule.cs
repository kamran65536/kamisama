using KamiSama.Extensions.DependencyInjection;
using KamiSama.Extensions.WebModules;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KamiSama.ExternalServices.Email.Smtp;
internal class SmtpEmailModule(IConfigurationSection smtpServiceSection) : WebModule
{
	public override void ConfigureServices(IServiceCollection services)
	{
		services.Configure<SmtpOptions>(smtpServiceSection);

		services.AutoAddDependenciesFrom<SmtpEmailModule>();
	}

	public override Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken)
	{
		return Task.CompletedTask;
	}
}
public static class ExtendedWebApplicationBuilderExtensions
{
	public static ExtendedWebApplicationBuilder AddSmtpEmailServiceModule(this ExtendedWebApplicationBuilder builder, IConfigurationSection smtpServiceSection)
		=> builder.AddModule(new SmtpEmailModule(smtpServiceSection));
}