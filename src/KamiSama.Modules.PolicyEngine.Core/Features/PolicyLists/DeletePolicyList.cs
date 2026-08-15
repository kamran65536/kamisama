using KamiSama.Modules.PolicyEngine.Features.PolicyLists;

namespace KamiSama.Modules.PolicyEngine.Features.PolicyLists;

[AutoInjectScoped<IDeletePolicyList>]
internal class DeletePolicyList(IPolicyListRepository repository) :
	GenericDeleteFeature<PolicyList, IPolicyListRepository, Guid>(repository)
{
}
