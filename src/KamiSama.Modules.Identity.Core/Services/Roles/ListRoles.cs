using KamiSama.Chassis.Commons.Features;

namespace KamiSama.Modules.Identity.Services.Roles;

[AutoInjectScoped<IListRoles>]
internal class ListRoles(IApplicationRoleRepository repository) :
	GenericListFeature<ApplicationRole, RoleDto, RoleSearchModel, IApplicationRoleRepository>(repository),
	IListRoles
{
	protected override Task<RoleDto> ConvertToDto(ApplicationRole entity, CancellationToken cancellationToken)
		=> Task.FromResult(entity.ToDto());
}
