using KamiSama.Chassis.Commons.Features;

namespace KamiSama.Modules.Identity.Services.Roles;

[AutoInjectScoped<IDeleteRole>]
internal class DeleteRole(IApplicationRoleRepository repository) :
	GenericDeleteFeature<ApplicationRole, IApplicationRoleRepository, Guid>(repository),
	IDeleteRole
{
}
