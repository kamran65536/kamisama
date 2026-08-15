using KamiSama.Modules.PolicyEngine.Features.PolicyActions;

namespace KamiSama.Modules.PolicyEngine.Features.PolicyActions;

[AutoInjectScoped<IDeletePolicyAction>]
internal class DeletePolicyAction(IPolicyActionRepository repository) :
	GenericDeleteFeature<PolicyAction, IPolicyActionRepository, Guid>(repository)
{
}
