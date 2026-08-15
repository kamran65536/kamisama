using KamiSama.Modules.PolicyEngine.Features.PolicyLists;

namespace KamiSama.Modules.PolicyEngine.Features.PolicyLists;

[AutoInjectScoped<IUpdatePolicyList>]
internal class UpdatePolicyList(IPolicyListRepository repository) :
	GenericUpdateFeature<UpdatePolicyListRequest, PolicyList, IPolicyListRepository, Guid>(repository),
	IUpdatePolicyList
{
	protected override async Task CheckDuplicateAsync(Guid id, UpdatePolicyListRequest request, CancellationToken cancellationToken)
	{
		var entity = await Repository.FindByNameAsync(request.Name, cancellationToken);
		if (entity != null && entity.Id != id)
			throw new AlreadyExistsException<PolicyList>(request.Name, nameof(request.Name));
	}

	protected override Task PatchEntityAsync(PolicyList entity, UpdatePolicyListRequest request, CancellationToken cancellationToken)
	{
		entity.Name = request.Name;
		entity.Type = request.Type;
		entity.IsEnabled = request.IsEnabled;
		entity.UpdatedAt = DateTime.UtcNow;
		return Task.CompletedTask;
	}
}
