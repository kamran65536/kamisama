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
			.AddSwaggerGen(ConfigureSwaggerGen);
	/// <inheritdoc />
	public override Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken)
	{
		if (addEndPointInProduction || app.Environment.IsDevelopment())
		{
			app.UseSwagger();
			app.UseSwaggerUI(ConfigureUiOptions);
		}

		return Task.CompletedTask;
	}
	/// <summary>
	/// Configures swagger gen for inheritance
	/// </summary>
	protected virtual void ConfigureSwaggerGen(SwaggerGenOptions options)
	{
		genConfigure?.Invoke(options);
	}
	/// <summary>
	/// Configures swagger ui options for inheritance
	/// </summary>
	protected virtual void ConfigureUiOptions(SwaggerUIOptions uiOptions)
	{
		uiConfigure?.Invoke(uiOptions);
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
