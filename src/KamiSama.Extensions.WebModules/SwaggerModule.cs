using Microsoft.Extensions.Hosting;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace KamiSama.Extensions.WebModules;

/// <summary>
/// Swagger Documentation and endpoint module
/// </summary>
public class SwaggerModule(bool addEndPointInProduction, Action<SwaggerGenOptions>? genConfigure, Action<SwaggerUIOptions>? uiConfigure) : WebModule
{
	/// <inheritdoc />
	public override void ConfigureServices(IServiceCollection services)
		=> services
			.AddEndpointsApiExplorer()
			.AddSwaggerGen(genConfigure);
	/// <inheritdoc />
	public override void ApplyConfigurationTo(WebApplication app)
	{
		if (addEndPointInProduction || app.Environment.IsDevelopment())
		{
			app.UseSwagger();
			if (uiConfigure != null)
				app.UseSwaggerUI(uiConfigure);
			else
				app.UseSwaggerUI();
		}
	}
}
/// <inheritdoc />
public static class SwaggerModuleExtension
{
	/// <summary>
	/// Adds Swagger cofniguration to app
	/// </summary>
	public static ExtendedWebApplicationBuilder AddSwagger(this ExtendedWebApplicationBuilder builder, bool addEndPointInProduction = false, Action<SwaggerGenOptions>? genConfigure = null, Action<SwaggerUIOptions>? uiConfigure = null)
		=> builder.AddModule(new SwaggerModule(addEndPointInProduction, genConfigure, uiConfigure));
}
