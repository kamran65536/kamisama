using KamiSama.Chassis.ProblemDetails;
using KamiSama.Extensions.WebModules;
using Microsoft.AspNetCore.Components.Authorization;
using Polareum.Identity;
using Polareum.Localization;
//#if (Ticketing)
using Polareum.Ticketing;
//#endif
using Suma.AdminPanel.Properties;
using Suma.AdminPanel.Server.Components;
using Suma.AdminPanel.Server.Components.Account;
using System.Text.Json.Serialization;
using Serilog;

namespace Suma.AdminPanel.Server;

/// <inheritdoc />
public class Program
{
    /// <inheritdoc />
    public static async Task Main(string[] args)
    {
        var _builder = WebApplication.CreateBuilder(args);

        if (_builder.Environment.IsDevelopment())
        {
            _builder.Host.UseDefaultServiceProvider(opt =>
            {
                opt.ValidateScopes = true;
                opt.ValidateOnBuild = true;
            });
        }
		_builder.Host.UseSerilog((context, services, loggerConfiguration) =>
		{
			loggerConfiguration
				.ReadFrom.Configuration(context.Configuration)
				.ReadFrom.Services(services);
		});
		var builder = _builder.Extend();
        var databaseSection = builder.Configuration.GetSection("database");
        var identitySection = builder.Configuration.GetSection("modules:identity");
        var localizationSection = builder.Configuration.GetSection("modules:localization");
		//#if (Ticketing)
		var ticketingSection = builder.Configuration.GetSection("modules:ticketing");
		//#endif

        // Add services to the container.
		builder.Services.AddHttpContextAccessor();
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents()
            .AddInteractiveWebAssemblyComponents()
            .AddAuthenticationStateSerialization();

        builder.Services.AddCascadingAuthenticationState();
        builder.Services.AddScoped<IdentityUserAccessor>();
        builder.Services.AddScoped<IdentityRedirectManager>();
        builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();
        builder.Services.AddHttpClient();
        builder.Services.AddDatabaseDeveloperPageExceptionFilter();
        builder.Services.AddHealthChecks();
        builder.Services.AddBlazorBootstrap();

		builder.Services.ConfigureApplicationCookie(options =>
        {
            options.Cookie.Name = ".AspNetCore.Identity.Application";
            options.Cookie.HttpOnly = true;
            options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            options.Cookie.SameSite = SameSiteMode.None;
            options.SlidingExpiration = true;
        });

        builder
            .AddControllers(mvcBuilder => mvcBuilder
                .AddExceptionFilterForProblemDetails(opt => opt.UseResourceLocalizer<Resources>())
                .AddJsonOptions(opts => opts.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter())))
			.AddAuthorization()
			.AddHttpsRedirection()
            .AddAntiForgery()
            .AddStaticFiles()
			.AddLocalizationModule(localizationSection)
			//#if (IdentityManagement)
			.AddPolareumIdentityModule(identitySection, databaseSection, registerIdentity: true, useJwtAuth: false)
			//#endif
			//#if (Ticketing)
			.AddTicketingModule(ticketingSection, databaseSection)
			//#endif
            .AddAdminPanelPlatform();

        var app = await builder.BuildAsync(CancellationToken.None);

		app.UseSerilogRequestLogging();

		// Configure the HTTP request pipeline.
		if (app.Environment.IsDevelopment())
        {
            app.UseWebAssemblyDebugging();
            app.UseMigrationsEndPoint();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.MapStaticAssets();
		app.UseHttpsRedirection();
        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode()
            .AddInteractiveWebAssemblyRenderMode()
            .AddAdditionalAssemblies(typeof(Client._Imports).Assembly);
        app.MapAdditionalIdentityEndpoints();

		app.Run();
    }
}
