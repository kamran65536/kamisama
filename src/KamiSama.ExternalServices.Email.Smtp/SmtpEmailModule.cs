using KamiSama.Extensions.DependencyInjection;
using KamiSama.Modules;
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

/// <summary>
/// Adds the SMTP email provider module to an extended ASP.NET Core application builder.
/// </summary>
public static class ExtendedWebApplicationBuilderExtensions
{
	/// <summary>
	/// Binds SMTP settings and registers the keyed <c>smtp</c> email provider.
	/// </summary>
	/// <param name="builder">The extended application builder receiving the module.</param>
	/// <param name="smtpServiceSection">The configuration section containing SMTP connection and sender settings.</param>
	/// <returns>The same builder so additional modules can be chained.</returns>
	public static ExtendedWebApplicationBuilder AddSmtpEmailServiceModule(this ExtendedWebApplicationBuilder builder, IConfigurationSection smtpServiceSection)
		=> builder.AddModule(new SmtpEmailModule(smtpServiceSection));
}
