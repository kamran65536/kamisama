using KamiSama.Chassis.Commons.Features;

namespace KamiSama.Modules.Identity.Services.Roles;

[AutoInjectScoped<IFindRoleById>]
internal class FindRoleById(IApplicationRoleRepository repository) :
	GenericFindByIdFeature<ApplicationRole, RoleDto, IApplicationRoleRepository, Guid>(repository),
	IFindRoleById
{
	protected override Task<RoleDto> ConvertToDto(ApplicationRole entity, CancellationToken cancellationToken)
		=> Task.FromResult(entity.ToDto());
}
