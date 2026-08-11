using KamiSama.Chassis.Commons.Features;

namespace KamiSama.Modules.Identity.Services.Roles;

[AutoInjectScoped<IExistsRoleById>]
internal class ExistsRoleById(IApplicationRoleRepository repository) :
	GenericExistsByIdFeature<ApplicationRole, IApplicationRoleRepository, Guid>(repository),
	IExistsRoleById
{
}
