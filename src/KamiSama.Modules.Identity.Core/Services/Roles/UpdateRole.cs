using KamiSama.Chassis.Commons.Features;

namespace KamiSama.Modules.Identity.Services.Roles;

[AutoInjectScoped<IUpdateRole>]
internal class UpdateRole(IApplicationRoleRepository repository, ILookupNormalizer normalizer) :
	GenericUpdateFeature<UpdateRoleRequest, ApplicationRole, IApplicationRoleRepository, Guid>(repository),
	IUpdateRole
{
	protected override async Task CheckDuplicateAsync(Guid id, UpdateRoleRequest request, CancellationToken cancellationToken)
	{
		var role = await Repository.FindByNameAsync(request.Name, cancellationToken);

		if (role != null && role.Id != id)
			throw new AlreadyExistsException<ApplicationRole>(request.Name, nameof(request.Name));
	}

	protected override Task PatchEntityAsync(ApplicationRole entity, UpdateRoleRequest request, CancellationToken cancellationToken)
	{
		entity.Name = request.Name;
		entity.NormalizedName = normalizer.NormalizeName(request.Name);

		return Task.CompletedTask;
	}
}
