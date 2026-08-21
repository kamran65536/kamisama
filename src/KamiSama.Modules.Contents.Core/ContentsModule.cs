using KamiSama.Modules.Contents.Repositories.Database;
using KamiSama.Repositories;
using KamiSama.Repositories.EntityFrameworkCore;
using KamiSama.Repositories.EntityFrameworkCore.Initialization;
using KamiSama.Repositories.Initialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace KamiSama.Modules.Contents;

internal class ContentsModule(
	IConfigurationSection moduleSection,
	IConfigurationSection databaseSection,
	Action<IMultiProviderDbContextBuilder<ContentsDbContext>>? configureDbContext = null) : WebModule
{
	public const string ModuleName = "Contents";

	public override void ConfigureServices(IServiceCollection services)
	{
		services.Configure<ConnectionStringOption>(ModuleName, databaseSection);
		services.Configure<DataInitializationOptions>(ModuleName, moduleSection.GetSection("initialization"));

		services.AutoAddDependenciesFrom<ContentsDbContext>();
		var provider = services
			.AddMultiProviderDbContext<ContentsDbContext>(databaseSection)
			.WithMigrationHistoryTable($"{HistoryRepository.DefaultTableName}_{ModuleName}");

		configureDbContext?.Invoke(provider);
	}

	public override async Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken)
	{
		using var scope = app.Services.CreateScope();

		var initializer =
			scope.ServiceProvider.GetService<IDatabaseInitializer<ContentsDbContext>>()
			?? new DefaultDatabaseInitializer<ContentsDbContext>(scope.ServiceProvider.GetRequiredService<ContentsDbContext>());

		var options = scope.ServiceProvider.GetRequiredService<IOptionsSnapshot<DataInitializationOptions>>().Get(ModuleName);

		await initializer.InitializeAsync(options, cancellationToken);
	}
}

/// <summary>
/// Provides modular ASP.NET Core registration for the content-file implementation.
/// </summary>
public static class ExtendedWebApplicationBuilderExtensions
{
	/// <summary>
	/// Adds Contents scoped feature and repository discovery, provider-neutral DbContext registration, and post-build database initialization.
	/// </summary>
	/// <param name="builder">The extended application builder that queues the Contents module.</param>
	/// <param name="moduleSection">The Contents module section; its <c>initialization</c> child binds the named migration and seed options.</param>
	/// <param name="databaseSection">The section containing required <c>provider</c> and <c>connection-string</c> values.</param>
	/// <param name="configureDbContext">The provider-registration callback. Although nullable for API compatibility, it is required in a normal host so the configured keyed <see cref="ContentsDbContext"/> can be resolved.</param>
	/// <returns>The same extended builder for fluent module composition.</returns>
	/// <remarks>
	/// Register the PostgreSQL or SQLite provider matching the configured provider key, then call <c>BuildAsync</c> before resolving Contents features.
	/// During the post-build phase the module resolves a custom named <c>IDatabaseInitializer&lt;ContentsDbContext&gt;</c>, or falls back to migration-only initialization.
	/// This module registers services only; it does not add controllers, endpoints, or authorization.
	/// </remarks>
	public static ExtendedWebApplicationBuilder AddContentsModule(
		this ExtendedWebApplicationBuilder builder,
		IConfigurationSection moduleSection,
		IConfigurationSection databaseSection,
		Action<IMultiProviderDbContextBuilder<ContentsDbContext>>? configureDbContext = null)
		=> builder.AddModule(new ContentsModule(moduleSection, databaseSection, configureDbContext));
}
