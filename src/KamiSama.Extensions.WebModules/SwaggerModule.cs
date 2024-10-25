using Microsoft.Extensions.Hosting;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace KamiSama.Extensions.WebModules;

/// <summary>
/// Swagger Documentation and endpoint module
/// </summary>
public class SwaggerModule(Action<SwaggerGenOptions>? setupAction, bool addEndPointInProduction) : WebModule
{
	/// <inheritdoc />
	public override void ConfigureServices(IServiceCollection services)
		=> services
			.AddEndpointsApiExplorer()
			.AddSwaggerGen(setupAction);
	/// <inheritdoc />
	public override void ApplyConfigurationTo(WebApplication app)
	{
		if (addEndPointInProduction || app.Environment.IsDevelopment())
		{
			app.UseSwagger();
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
	/// <param name="builder"></param>
	/// <param name="addEndPointInProduction"></param>
	/// <param name="setupAction"></param>
	/// <returns></returns>
	public static ExtendedWebApplicationBuilder AddSwagger(this ExtendedWebApplicationBuilder builder, bool addEndPointInProduction = false, Action<SwaggerGenOptions>? setupAction = null)
		=> builder.AddModule(new SwaggerModule(setupAction, addEndPointInProduction));
}
