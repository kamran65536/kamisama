namespace Project;

public static class WebApplicationExtensions
{
	public static async Task<WebApplication> TryInitializeBoundedContextAsync(this WebApplication app, DataInitializationOptions options, CancellationToken cancellationToken)
	{
		using var scope = app.Services.CreateScope();
		var initializer = scope.ServiceProvider.GetRequiredService<IDatabaseInitializer<ScfPlatformDbContext>>();

		await initializer.InitializeAsync(options, cancellationToken);

		return app;
	}
}