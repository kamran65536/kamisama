using KamiSama.Modules.PolicyEngine.Features.PolicyRules;

namespace KamiSama.Modules.PolicyEngine.Features.PolicyRules;

[AutoInjectScoped<IUpdatePolicyRule>]
internal class UpdatePolicyRule(IPolicyRuleRepository repository) :
	GenericUpdateFeature<UpdatePolicyRuleRequest, PolicyRule, IPolicyRuleRepository, Guid>(repository),
	IUpdatePolicyRule
{
	protected override async Task CheckDuplicateAsync(Guid id, UpdatePolicyRuleRequest request, CancellationToken cancellationToken)
	{
		var entity = await Repository.FindByNameAsync(request.Name, cancellationToken);
		if (entity != null && entity.Id != id)
			throw new AlreadyExistsException<PolicyRule>(request.Name, nameof(request.Name));
	}

	protected override Task PatchEntityAsync(PolicyRule entity, UpdatePolicyRuleRequest request, CancellationToken cancellationToken)
	{
		entity.Name = request.Name;
		entity.ProcessOrder = request.ProcessOrder;
		entity.ConditionSource = request.ConditionSource;
		entity.IsEnabled = request.IsEnabled;
		entity.UpdatedAt = DateTime.UtcNow;
		return Task.CompletedTask;
	}
}
