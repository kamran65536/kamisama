using KamiSama.Modules.PolicyEngine.Features.PolicyRules;

namespace KamiSama.Modules.PolicyEngine.Features.PolicyRules;

[AutoInjectScoped<IAddPolicyRule>]
internal class AddPolicyRule(IPolicyRuleRepository repository) :
	GenericAddFeature<AddPolicyRuleRequest, IPolicyRuleRepository, PolicyRule, PolicyRuleDto>(repository),
	IAddPolicyRule
{
	protected override async Task CheckDuplicateAsync(AddPolicyRuleRequest request, CancellationToken cancellationToken)
	{
		if (await Repository.ExistsByNameAsync(request.Name, cancellationToken))
			throw new AlreadyExistsException<PolicyRule>(request.Name, nameof(request.Name));
	}

	protected override Task<PolicyRule> ConvertToEntity(AddPolicyRuleRequest request, CancellationToken cancellationToken)
	{
		var now = DateTime.UtcNow;
		return Task.FromResult(new PolicyRule
		{
			Name = request.Name,
			ProcessOrder = request.ProcessOrder,
			ConditionSource = request.ConditionSource,
			IsEnabled = request.IsEnabled,
			CreatedAt = now,
			UpdatedAt = now,
		});
	}

	protected override Task<PolicyRuleDto> ConvertToDto(PolicyRule entity, CancellationToken cancellationToken)
		=> Task.FromResult(entity.ToDto());
}
