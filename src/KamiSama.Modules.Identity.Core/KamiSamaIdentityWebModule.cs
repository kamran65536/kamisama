using KamiSama.Modules;
using KamiSama.Repositories;
using KamiSama.Repositories.EntityFrameworkCore;
using KamiSama.Repositories.EntityFrameworkCore.Initialization;
using KamiSama.Repositories.Initialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using KamiSama.Modules.Identity.Services.AccountSecurity;
using KamiSama.Modules.Identity.Repositories.Database;
using System.Text;

namespace KamiSama.Modules.Identity;
/// <summary>
/// Registers Identity options, authentication, attributed feature implementations, and a multi-provider Identity DbContext, then runs configured database initialization after build.
/// A provider callback is operationally required, and the host must place authentication middleware before authorization middleware.
/// </summary>
/// <param name="moduleSection">The Identity section containing <c>options</c>, <c>jwt</c>, and <c>initialization</c> children.</param>
/// <param name="databaseSection">The database section containing <c>provider</c> and <c>connection-string</c>.</param>
/// <param name="registerIdentity">Whether to register ASP.NET Core Identity stores, managers, sign-in manager, and token providers.</param>
/// <param name="useJwtAuth">Whether to configure JWT bearer authentication instead of Identity application-scheme defaults.</param>
/// <param name="configure">The callback that must add an installed provider to the multi-provider context builder.</param>
public class KamiSamaIdentityWebModule(
	IConfigurationSection moduleSection,
	IConfigurationSection databaseSection,
	bool registerIdentity,
	bool useJwtAuth,
	Action<IMultiProviderDbContextBuilder<KamiSamaIdentityDbContext>>? configure = null) : WebModule
{
	/// <summary>Gets the name used for named options and migration-history configuration.</summary>
	public const string ModuleName = "Identity";

	/// <summary>
	/// Registers named database and initialization options, Identity when selected, authentication, scanned features, and the base multi-provider DbContext.
	/// The provider callback must call an installed provider extension or context resolution will fail later.
	/// </summary>
	/// <param name="services">The application service collection.</param>
	public override void ConfigureServices(IServiceCollection services)
	{
		services.Configure<ConnectionStringOption>(ModuleName, databaseSection);
		services.Configure<DataInitializationOptions>(ModuleName, moduleSection.GetSection("initialization"));
        services.Configure<IdentityOptions>(moduleSection.GetSection("options"));
		
		if (registerIdentity)
			services.AddIdentity<ApplicationUser, ApplicationRole>()
				.AddEntityFrameworkStores<KamiSamaIdentityDbContext>()
				.AddSignInManager<ApplicationSignInManager>()
				.AddDefaultTokenProviders();

		if (useJwtAuth)
		{
			var jwtSection = moduleSection.GetSection("jwt");
			services.Configure<JwtOptions>(jwtSection);

			var jwtOption = jwtSection.Get<JwtOptions>() ?? throw new InvalidOperationException("Cannot read " + moduleSection.Path + ":jwt");

			var key = Encoding.UTF8.GetBytes(jwtOption.Key);

			services.AddAuthentication(opt =>
				{
					opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
					opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				})
				.AddJwtBearer(opt =>
				{
					opt.RequireHttpsMetadata = false; // true in production
					opt.SaveToken = true;
					opt.EventsType = typeof(ApplicationSessionJwtBearerEvents);
					opt.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuer = true,
						ValidateAudience = true,
						ValidateLifetime = true,
						ValidateIssuerSigningKey = true,
						ValidIssuer = jwtOption.Issuer,
						ValidAudience = jwtOption.Audience,
						IssuerSigningKey = new SymmetricSecurityKey(key)
					};
				});

		}
		else
		{
			services.AddAuthentication(options =>
				{
					options.DefaultScheme = IdentityConstants.ApplicationScheme;
					options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
				});
				//.AddIdentityCookies();

			services.ConfigureApplicationCookie(options =>
			{
				options.EventsType = typeof(ApplicationSessionCookieEvents);
			});
		}

		services.AutoAddDependenciesFrom<KamiSamaIdentityWebModule>();
		var dbContextBuilder = services
			.AddMultiProviderDbContext<KamiSamaIdentityDbContext>(databaseSection)
			.WithMigrationHistoryTable($"{HistoryRepository.DefaultTableName}_{ModuleName}");
		configure?.Invoke(dbContextBuilder);
	}
	
	/// <summary>Creates a startup scope and runs migration and seed stages selected by the named initialization options.</summary>
	/// <param name="app">The built web application.</param>
	/// <param name="cancellationToken">A token that requests cancellation of startup initialization.</param>
	/// <returns>A task that completes when startup database initialization finishes.</returns>
	public override async Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken)
	{
		using var scope = app.Services.CreateScope();

		var initializer = 
			scope.ServiceProvider.GetService<IDatabaseInitializer<KamiSamaIdentityDbContext>>() ??
			new DefaultDatabaseInitializer<KamiSamaIdentityDbContext>(scope.ServiceProvider.GetRequiredService<KamiSamaIdentityDbContext>());

		var options = scope.ServiceProvider.GetRequiredService<IOptionsSnapshot<DataInitializationOptions>>().Get(ModuleName);

		await initializer.InitializeAsync(options, cancellationToken);
	}
}
/// <summary>Provides modular builder registration for the KamiSama Identity Core module.</summary>
public static class ExtendedWebApplicationBuilderExtensions
{
	/// <summary>Adds Identity registration and startup initialization to an extended application builder.</summary>
	/// <param name="builder">The extended application builder.</param>
	/// <param name="moduleSection">The Identity options, JWT, and initialization section.</param>
	/// <param name="databaseSection">The database provider and connection-string section.</param>
	/// <param name="registerIdentity">Whether Core should register ASP.NET Core Identity services.</param>
	/// <param name="useJwtAuth">Whether Core should configure JWT bearer rather than Identity application-scheme defaults.</param>
	/// <param name="configureDbContext">The required-in-practice callback that adds exactly one installed Identity database provider.</param>
	/// <returns>The same builder for fluent module composition.</returns>
	public static ExtendedWebApplicationBuilder AddKamiSamaIdentityModule(
		this ExtendedWebApplicationBuilder builder,
		IConfigurationSection moduleSection,
		IConfigurationSection databaseSection,
		bool registerIdentity = true,
		bool useJwtAuth = true,
		Action<IMultiProviderDbContextBuilder<KamiSamaIdentityDbContext>>? configureDbContext = null)
		=> builder.AddModule(new KamiSamaIdentityWebModule(
			moduleSection,
			databaseSection,
			registerIdentity,
			useJwtAuth,
			configureDbContext));
}
