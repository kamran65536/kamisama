using KamiSama.Extensions.WebModules;
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
using KamiSama.Modules.Identity.Features.AccountSecurity;
using KamiSama.Modules.Identity.Repositories.Database;
using System.Text;

namespace KamiSama.Modules.Identity;
public class KamiSamaIdentityWebModule(
	IConfigurationSection moduleSection,
	IConfigurationSection databaseSection,
	bool registerIdentity,
	bool useJwtAuth,
	Action<IMultiProviderDbContextBuilder<KamiSamaIdentityDbContext>>? configureDbContext = null) : WebModule
{
	public const string ModuleName = "Identity";

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
		configureDbContext?.Invoke(dbContextBuilder);
	}
	
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
public static class ExtendedWebApplicationBuilderExtensions
{
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
