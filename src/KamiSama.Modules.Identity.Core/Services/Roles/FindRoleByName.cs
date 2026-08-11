using KamiSama.Chassis.Commons.Features;

namespace KamiSama.Modules.Identity.Services.Roles;

[AutoInjectScoped<IFindRoleByName>]
internal class FindRoleByName(IApplicationRoleRepository repository) :
	GenericFindByNameFeature<ApplicationRole, RoleDto, IApplicationRoleRepository>(repository),
	IFindRoleByName
{
	protected override Task<RoleDto> ConvertToDto(ApplicationRole entity, CancellationToken cancellationToken)
		=> Task.FromResult(entity.ToDto());
}
