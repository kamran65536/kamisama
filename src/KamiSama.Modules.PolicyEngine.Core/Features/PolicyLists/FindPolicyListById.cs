using KamiSama.Modules.PolicyEngine.Features.PolicyLists;

namespace KamiSama.Modules.PolicyEngine.Features.PolicyLists;

[AutoInjectScoped<IFindPolicyListById>]
internal class FindPolicyListById(IPolicyListRepository repository) :
	GenericFindByIdFeature<PolicyList, PolicyListDto, IPolicyListRepository, Guid>(repository),
	IFindPolicyListById
{
	protected override Task<PolicyListDto> ConvertToDto(PolicyList entity, CancellationToken cancellationToken)
		=> Task.FromResult(entity.ToDto());
}
