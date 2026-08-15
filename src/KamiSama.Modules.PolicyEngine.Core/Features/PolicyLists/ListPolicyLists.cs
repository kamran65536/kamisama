using KamiSama.Modules.PolicyEngine.Features.PolicyLists;

namespace KamiSama.Modules.PolicyEngine.Features.PolicyLists;

[AutoInjectScoped<IListPolicyLists>]
internal class ListPolicyLists(IPolicyListRepository repository) :
	GenericListFeature<PolicyList, PolicyListListItemDto, PolicyListSearchModel, IPolicyListRepository>(repository)
{
	protected override Task<PolicyListListItemDto> ConvertToDto(PolicyList entity, CancellationToken cancellationToken)
		=> Task.FromResult(entity.ToListItemDto());
}
