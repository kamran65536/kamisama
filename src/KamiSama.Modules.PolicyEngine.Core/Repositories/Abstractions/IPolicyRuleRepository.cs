using KamiSama.Modules.PolicyEngine.Features.PolicyRules;

namespace KamiSama.Modules.PolicyEngine.Repositories.Abstractions;

internal interface IPolicyRuleRepository :
	IGenericRepository<PolicyRule, PolicyRuleSearchModel>,
	ILookupByIdRepository<PolicyRule, Guid>,
	ILookupByNameRepository<PolicyRule>
{
}
