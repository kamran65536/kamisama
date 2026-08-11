using KamiSama.Extensions.WebModules;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Suma.AdminPanel;

public class AdminPanelPlatformModule : WebModule
{
	public override void ConfigureServices(IServiceCollection services)
	{
		services.AutoAddDependenciesFrom<AdminPanelPlatformModule>();
	}

	public override Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken)
	{
		return Task.CompletedTask;
	}
}
public static class ExtendedWebApplicationBuilderExtensions
{
	public static ExtendedWebApplicationBuilder AddAdminPanelPlatform(this ExtendedWebApplicationBuilder builder)
		=> builder.AddModule(new AdminPanelPlatformModule());
}
