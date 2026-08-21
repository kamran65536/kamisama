using KamiSama.Modules;
using Microsoft.Extensions.Configuration;
//#if (UserManagement || Ticketing)
using KamiSama.Modules.Identity;
//#endif
//#if (Ticketing)
using KamiSama.Modules.Ticketing;
//#endif

namespace Example.Bootstrap;

public static class BootstrapExtensions
{
    public static ExtendedWebApplicationBuilder AddPlatformModules(
        this ExtendedWebApplicationBuilder builder,
        IConfiguration configuration,
        bool registerIdentity = true,
        bool useJwtAuth = false)
    {
        //#if (UserManagement || Ticketing)
        builder.AddKamiSamaIdentityModule(
            configuration.GetSection("modules:identity"),
            configuration.GetSection("databases:user-management"),
            registerIdentity,
            useJwtAuth,
            providers =>
            {
                //#if (UserManagementProvider == "Postgresql")
                providers.AddPostgresql();
                //#else
                providers.AddSqlite();
                //#endif
            });
        //#endif

        //#if (Ticketing)
        builder.AddTicketingModule(
            configuration.GetSection("modules:ticketing"),
            configuration.GetSection("databases:ticketing"),
            providers =>
            {
                //#if (TicketingProvider == "Postgresql")
                providers.AddPostgresql();
                //#else
                providers.AddSqlite();
                //#endif
            });
        //#endif

        return builder;
    }
}
