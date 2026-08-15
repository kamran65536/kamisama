using KamiSama.Modules.PolicyEngine.Features.PolicyRules;

namespace KamiSama.Modules.PolicyEngine.Features.PolicyRules;

[AutoInjectScoped<IFindPolicyRuleById>]
internal class FindPolicyRuleById(IPolicyRuleRepository repository) :
	GenericFindByIdFeature<PolicyRule, PolicyRuleDto, IPolicyRuleRepository, Guid>(repository),
	IFindPolicyRuleById
{
	protected override Task<PolicyRuleDto> ConvertToDto(PolicyRule entity, CancellationToken cancellationToken)
		=> Task.FromResult(entity.ToDto());
}
