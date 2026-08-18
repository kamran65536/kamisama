using KamiSama.Modules;
using KamiSama.Modules.Otp.Repositories.Database;
using KamiSama.Repositories;
using KamiSama.Repositories.EntityFrameworkCore;
using KamiSama.Repositories.EntityFrameworkCore.Initialization;
using KamiSama.Repositories.Initialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace KamiSama.Modules.Otp;

internal class OtpModule(
	IConfigurationSection moduleSection,
	IConfigurationSection databaseSection,
	Action<IMultiProviderDbContextBuilder<OtpDbContext>>? configureDbContext = null) : WebModule
{
	public const string ModuleName = "Otp";

	public override void ConfigureServices(IServiceCollection services)
	{
		services.Configure<OtpOptions>(moduleSection);
		services.Configure<ConnectionStringOption>(ModuleName, databaseSection);
		services.Configure<DataInitializationOptions>(ModuleName, moduleSection.GetSection("initialization"));

		services.AutoAddDependenciesFrom<OtpDbContext>();
		var provider = services
			.AddMultiProviderDbContext<OtpDbContext>(databaseSection)
			.WithMigrationHistoryTable($"{HistoryRepository.DefaultTableName}_{ModuleName}");

		configureDbContext?.Invoke(provider);
	}

	public override async Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken)
	{
		using var scope = app.Services.CreateScope();

		var initializer =
			scope.ServiceProvider.GetService<IDatabaseInitializer<OtpDbContext>>()
			?? new DefaultDatabaseInitializer<OtpDbContext>(scope.ServiceProvider.GetRequiredService<OtpDbContext>());

		var options = scope.ServiceProvider.GetRequiredService<IOptionsSnapshot<DataInitializationOptions>>().Get(ModuleName);

		await initializer.InitializeAsync(options, cancellationToken);
	}
}

/// <summary>
/// Provides modular ASP.NET Core registration for the one-time-password implementation.
/// </summary>
public static class ExtendedWebApplicationBuilderExtensions
{
	/// <summary>
	/// Adds Otp options binding, scoped feature and repository discovery, provider-neutral DbContext registration, and post-build database initialization.
	/// </summary>
	/// <param name="builder">The extended application builder that queues the Otp module.</param>
	/// <param name="moduleSection">The Otp module section; its <c>digits</c>, <c>send-interval</c>, and <c>lifetime</c> keys bind <see cref="OtpOptions"/>, and its <c>initialization</c> child binds the named migration and seed options.</param>
	/// <param name="databaseSection">The section containing required <c>provider</c> and <c>connection-string</c> values.</param>
	/// <param name="configureDbContext">The provider-registration callback. Although nullable for API compatibility, it is required in a normal host so the configured keyed <see cref="OtpDbContext"/> can be resolved.</param>
	/// <returns>The same extended builder for fluent module composition.</returns>
	/// <remarks>
	/// Register the PostgreSQL or SQLite provider matching the configured provider key, then call <c>BuildAsync</c> before resolving Otp features.
	/// During the post-build phase the module resolves a custom named <c>IDatabaseInitializer&lt;OtpDbContext&gt;</c>, or falls back to migration-only initialization.
	/// This module registers services only; it does not add controllers, endpoints, or authorization.
	/// </remarks>
	public static ExtendedWebApplicationBuilder AddOtpModule(
		this ExtendedWebApplicationBuilder builder,
		IConfigurationSection moduleSection,
		IConfigurationSection databaseSection,
		Action<IMultiProviderDbContextBuilder<OtpDbContext>>? configureDbContext = null)
		=> builder.AddModule(new OtpModule(moduleSection, databaseSection, configureDbContext));
}
