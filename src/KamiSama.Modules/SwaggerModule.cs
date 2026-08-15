using Microsoft.Extensions.Hosting;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace KamiSama.Modules;

/// <summary>
/// Registers Swagger generation and conditionally adds the Swagger document and UI middleware after build.
/// </summary>
/// <param name="addEndPointInProduction">Whether Swagger middleware should run outside the Development environment.</param>
/// <param name="genConfigure">An optional callback for Swagger generation options.</param>
/// <param name="uiConfigure">An optional callback for Swagger UI options.</param>
public class SwaggerModule(bool addEndPointInProduction, Action<SwaggerGenOptions>? genConfigure, Action<SwaggerUIOptions>? uiConfigure) : WebModule
{
	/// <summary>Registers endpoint metadata exploration and Swagger generation, routing generation options through <see cref="ConfigureSwaggerGen"/>.</summary>
	/// <param name="services">The service collection configured before build.</param>
	public override void ConfigureServices(IServiceCollection services)
		=> services
			.AddEndpointsApiExplorer()
			.AddSwaggerGen(ConfigureSwaggerGen);
	/// <summary>Adds Swagger document and UI middleware in Development, or in every environment when the constructor flag is true.</summary>
	/// <param name="app">The built application whose environment controls conditional registration.</param>
	/// <param name="cancellationToken">Ignored by this implementation.</param>
	/// <returns>An already completed task.</returns>
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
	/// Invokes the constructor callback for Swagger generation options; derived modules can override this hook.
	/// </summary>
	/// <param name="options">The generation options configured before build.</param>
	protected virtual void ConfigureSwaggerGen(SwaggerGenOptions options)
	{
		genConfigure?.Invoke(options);
	}
	/// <summary>
	/// Invokes the constructor callback for Swagger UI options; derived modules can override this hook.
	/// </summary>
	/// <param name="uiOptions">The UI options configured when middleware is added.</param>
	protected virtual void ConfigureUiOptions(SwaggerUIOptions uiOptions)
	{
		uiConfigure?.Invoke(uiOptions);
	}
}
/// <summary>Provides fluent registration of <see cref="SwaggerModule"/>.</summary>
public static class SwaggerModuleExtension
{
	/// <summary>
	/// Queues Swagger generation services and environment-sensitive document and UI middleware.
	/// </summary>
	/// <param name="builder">The builder that receives the module.</param>
	/// <param name="addEndPointInProduction">Whether to expose Swagger outside Development.</param>
	/// <param name="genConfigure">An optional generation-options callback.</param>
	/// <param name="uiConfigure">An optional UI-options callback.</param>
	/// <returns>The same builder for fluent composition.</returns>
	public static ExtendedWebApplicationBuilder AddSwagger(this ExtendedWebApplicationBuilder builder, bool addEndPointInProduction = false, Action<SwaggerGenOptions>? genConfigure = null, Action<SwaggerUIOptions>? uiConfigure = null)
		=> builder.AddModule(new SwaggerModule(addEndPointInProduction, genConfigure, uiConfigure));
}
