using KamiSama.Modules.PolicyEngine.Features.PolicyActions;

namespace KamiSama.Modules.PolicyEngine.Features.PolicyActions;

[AutoInjectScoped<IFindPolicyActionById>]
internal class FindPolicyActionById(IPolicyActionRepository repository) :
	GenericFindByIdFeature<PolicyAction, PolicyActionDto, IPolicyActionRepository, Guid>(repository),
	IFindPolicyActionById
{
	protected override Task<PolicyActionDto> ConvertToDto(PolicyAction entity, CancellationToken cancellationToken)
		=> Task.FromResult(entity.ToDto());
}
