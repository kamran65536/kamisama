using KamiSama.Chassis.Commons.Features;

namespace KamiSama.Modules.Identity.Services.Roles;

[AutoInjectScoped<IExistsRoleByName>]
internal class ExistsRoleByName(IApplicationRoleRepository repository) :
	GenericExistsByNameFeature<ApplicationRole, IApplicationRoleRepository>(repository),
	IExistsRoleByName
{
}
