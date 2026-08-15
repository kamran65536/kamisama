using KamiSama.Modules.PolicyEngine.Features.PolicyActions;

namespace KamiSama.Modules.PolicyEngine.Features.PolicyActions;

[AutoInjectScoped<IListPolicyActions>]
internal class ListPolicyActions(IPolicyActionRepository repository) :
	GenericListFeature<PolicyAction, PolicyActionListItemDto, PolicyActionSearchModel, IPolicyActionRepository>(repository)
{
	protected override Task<PolicyActionListItemDto> ConvertToDto(PolicyAction entity, CancellationToken cancellationToken)
		=> Task.FromResult(entity.ToListItemDto());
}
