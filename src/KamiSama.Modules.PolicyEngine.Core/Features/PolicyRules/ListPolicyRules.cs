using KamiSama.Modules.PolicyEngine.Features.PolicyRules;

namespace KamiSama.Modules.PolicyEngine.Features.PolicyRules;

[AutoInjectScoped<IListPolicyRules>]
internal class ListPolicyRules(IPolicyRuleRepository repository) :
	GenericListFeature<PolicyRule, PolicyRuleListItemDto, PolicyRuleSearchModel, IPolicyRuleRepository>(repository)
{
	protected override Task<PolicyRuleListItemDto> ConvertToDto(PolicyRule entity, CancellationToken cancellationToken)
		=> Task.FromResult(entity.ToListItemDto());
}
