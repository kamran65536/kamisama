using KamiSama.Chassis.Commons.Features;

namespace KamiSama.Modules.Identity.Services.Roles;

[AutoInjectScoped<IAddRole>]
internal class AddRole(IApplicationRoleRepository repository, ILookupNormalizer normalizer) :
	GenericAddFeature<AddRoleRequest, IApplicationRoleRepository, ApplicationRole, RoleDto>(repository),
	IAddRole
{
	protected override async Task CheckDuplicateAsync(AddRoleRequest request, CancellationToken cancellationToken)
	{
		if (await Repository.ExistsByNameAsync(request.Name, cancellationToken))
			throw new AlreadyExistsException<ApplicationRole>(request.Name, nameof(request.Name));
	}

	protected override Task<ApplicationRole> ConvertToEntity(AddRoleRequest request, CancellationToken cancellationToken)
		=> Task.FromResult(new ApplicationRole(request.Name)
		{
			NormalizedName = normalizer.NormalizeName(request.Name)
		});

	protected override Task<RoleDto> ConvertToDto(ApplicationRole entity, CancellationToken cancellationToken)
		=> Task.FromResult(entity.ToDto());
}
