using KamiSama.Chassis.ProblemDetails;
using KamiSama.Modules;
using KamiSama.Modules.Contents;
using KamiSama.Modules.Identity;
using KamiSama.Modules.Localization;
using KamiSama.Modules.Locations;
using KamiSama.Modules.Otp;
using KamiSama.Modules.PolicyEngine;
using KamiSama.Modules.ServicePlans;
using KamiSama.Modules.Ticketing;
using KamiSama.Repositories.EntityFrameworkCore.Postgresql;
using TestApiServer.Properties;

namespace ChassisTestProject;

public class Program
{
    public static void Main(string[] args)
    {
		var _builder = WebApplication.CreateBuilder(args);
		var builder = _builder.Extend();
		var databaseSection = builder.Configuration.GetSection("database");
		var contentsSection = builder.Configuration.GetSection("modules:contents");
		var identitySection = builder.Configuration.GetSection("modules:identity");
		var localizationSection = builder.Configuration.GetSection("modules:localization");
		var locationsSection = builder.Configuration.GetSection("modules:locations");
		var otpSection = builder.Configuration.GetSection("modules:otp");
		var policyEngineSection = builder.Configuration.GetSection("modules:policyengine");
		var serviceplansSection= builder.Configuration.GetSection("modules:serviceplans");
		var ticketingSection = builder.Configuration.GetSection("modules:ticketing");
		//var serviceDefaultsSection = builder.Configuration.GetSection("services:defaults");
		//var smtpSection = builder.Configuration.GetSection("services:smtp");
		//var neoZarinSection = builder.Configuration.GetSection("services:neo-zarin");
		//var kavenegarSection = builder.Configuration.GetSection("services:kavenegar");
		//var jwtSection = builder.Configuration.GetSection("modules:identity:jwt");

        // Add services to the container.
        builder.Services.AddControllers()
            .AddExceptionFilterForProblemDetails(opt => opt.UseResourceLocalizer<Resources>());
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddLocalization();
		builder
			.AddContentsModule(contentsSection, databaseSection, b => b.AddSqlite().AddPostgresql())
			.AddKamiSamaIdentityModule(identitySection, databaseSection, registerIdentity: true, useJwtAuth: false, b => b.AddSqlite().AddPostgresql())
			.AddLocationsModule(locationsSection, databaseSection, b => b.AddSqlite().AddPostgresql())
			.AddOtpModule(otpSection, databaseSection, b => b.AddSqlite().AddPostgresql())
			.AddPolicyEngineModule(policyEngineSection, databaseSection, b => b.AddSqlite().AddPostgresql())
			.AddServicePlansModule(serviceplansSection, databaseSection, b => b.AddSqlite().AddPostgresql())
			.AddTicketingModule(ticketingSection, databaseSection, b => b.AddSqlite().AddPostgresql())
			.AddLocalizationModule(localizationSection);

		var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
