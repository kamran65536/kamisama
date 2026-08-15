using KamiSama.Modules.PolicyEngine.Features.PolicyRules;

namespace KamiSama.Modules.PolicyEngine.Features.PolicyRules;

[AutoInjectScoped<IDeletePolicyRule>]
internal class DeletePolicyRule(IPolicyRuleRepository repository) :
	GenericDeleteFeature<PolicyRule, IPolicyRuleRepository, Guid>(repository)
{
}
