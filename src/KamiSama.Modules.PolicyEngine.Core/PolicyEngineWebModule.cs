using KamiSama.Modules;
using KamiSama.Extensions.DependencyInjection;
using KamiSama.Modules.PolicyEngine.Repositories.Database;
using KamiSama.Repositories.EntityFrameworkCore;
using KamiSama.Repositories.EntityFrameworkCore.Initialization;
using KamiSama.Repositories.Initialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace KamiSama.Modules.PolicyEngine;

internal class PolicyEngineWebModule(
	IConfigurationSection moduleSection,
	IConfigurationSection databaseSection,
	Action<IMultiProviderDbContextBuilder<PolicyEngineDbContext>>? configureDbContext = null) : WebModule
{
	public const string ModuleName = "PolicyEngine";

	public override void ConfigureServices(IServiceCollection services)
	{
		services.Configure<PolicyEngineOptions>(moduleSection);
		services.Configure<DataInitializationOptions>(ModuleName, moduleSection.GetSection("initialization"));

		services.AutoAddDependenciesFrom<PolicyEngineDbContext>();
		var dbContextBuilder = services
			.AddMultiProviderDbContext<PolicyEngineDbContext>(databaseSection)
			.WithMigrationHistoryTable($"{HistoryRepository.DefaultTableName}_{ModuleName}");
		configureDbContext?.Invoke(dbContextBuilder);
	}

	public override async Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken)
	{
		using var scope = app.Services.CreateScope();

		var initializer =
			scope.ServiceProvider.GetService<IDatabaseInitializer<PolicyEngineDbContext>>()
			?? new DefaultDatabaseInitializer<PolicyEngineDbContext>(scope.ServiceProvider.GetRequiredService<PolicyEngineDbContext>());

		var options = scope.ServiceProvider.GetRequiredService<IOptionsSnapshot<DataInitializationOptions>>().Get(ModuleName);
		await initializer.InitializeAsync(options, cancellationToken);
	}
}

/// <summary>
/// Adds PolicyEngine definition persistence and startup initialization to an extended ASP.NET Core builder.
/// </summary>
public static class PolicyEngineExtendedWebApplicationBuilderExtensions
{
	/// <summary>
	/// Adds PolicyEngine definition persistence, CRUD feature discovery, provider configuration, and post-build database initialization.
	/// </summary>
	/// <param name="builder">The extended application builder that queues the module.</param>
	/// <param name="moduleSection">The PolicyEngine section containing the named <c>initialization</c> subsection.</param>
	/// <param name="databaseSection">The section containing <c>provider</c> and <c>connection-string</c> values.</param>
	/// <param name="configureDbContext">A callback that should register the concrete provider matching the configured provider key.</param>
	/// <returns>The same extended builder so additional modules can be chained.</returns>
	/// <remarks>
	/// The callback is nullable but is required in a normal host unless the matching keyed
	/// <see cref="PolicyEngineDbContext"/> is registered elsewhere. This module does not add a policy evaluator,
	/// controllers, endpoints, authentication, or authorization. The current Core assembly also contains six
	/// non-assignable list/delete feature registrations that can fail service-provider validation.
	/// </remarks>
	public static ExtendedWebApplicationBuilder AddPolicyEngineModule(
		this ExtendedWebApplicationBuilder builder,
		IConfigurationSection moduleSection,
		IConfigurationSection databaseSection,
		Action<IMultiProviderDbContextBuilder<PolicyEngineDbContext>>? configureDbContext = null)
		=> builder.AddModule(new PolicyEngineWebModule(moduleSection, databaseSection, configureDbContext));
}
