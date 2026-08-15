using KamiSama.Modules.PolicyEngine.Features.PolicyLists;

namespace KamiSama.Modules.PolicyEngine.Features.PolicyLists;

[AutoInjectScoped<IAddPolicyList>]
internal class AddPolicyList(IPolicyListRepository repository) :
	GenericAddFeature<AddPolicyListRequest, IPolicyListRepository, PolicyList, PolicyListDto>(repository),
	IAddPolicyList
{
	protected override async Task CheckDuplicateAsync(AddPolicyListRequest request, CancellationToken cancellationToken)
	{
		if (await Repository.ExistsByNameAsync(request.Name, cancellationToken))
			throw new AlreadyExistsException<PolicyList>(request.Name, nameof(request.Name));
	}

	protected override Task<PolicyList> ConvertToEntity(AddPolicyListRequest request, CancellationToken cancellationToken)
	{
		var now = DateTime.UtcNow;
		return Task.FromResult(new PolicyList
		{
			Name = request.Name,
			Type = request.Type,
			IsEnabled = request.IsEnabled,
			CreatedAt = now,
			UpdatedAt = now,
		});
	}

	protected override Task<PolicyListDto> ConvertToDto(PolicyList entity, CancellationToken cancellationToken)
		=> Task.FromResult(entity.ToDto());
}
