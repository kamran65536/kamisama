using KamiSama.Modules.PolicyEngine.Features.PolicyActions;

namespace KamiSama.Modules.PolicyEngine.Features.PolicyActions;

[AutoInjectScoped<IAddPolicyAction>]
internal class AddPolicyAction(IPolicyActionRepository repository) :
	GenericAddFeature<AddPolicyActionRequest, IPolicyActionRepository, PolicyAction, PolicyActionDto>(repository),
	IAddPolicyAction
{
	protected override async Task CheckDuplicateAsync(AddPolicyActionRequest request, CancellationToken cancellationToken)
	{
		if (await Repository.ExistsByNameAsync(request.Name, cancellationToken))
			throw new AlreadyExistsException<PolicyAction>(request.Name, nameof(request.Name));
	}

	protected override Task<PolicyAction> ConvertToEntity(AddPolicyActionRequest request, CancellationToken cancellationToken)
	{
		var now = DateTime.UtcNow;
		return Task.FromResult(new PolicyAction
		{
			Name = request.Name,
			HandlerName = request.HandlerName,
			ConfigurationSource = request.ConfigurationSource,
			AllowsMultiple = request.AllowsMultiple,
			IsEnabled = request.IsEnabled,
			CreatedAt = now,
			UpdatedAt = now,
		});
	}

	protected override Task<PolicyActionDto> ConvertToDto(PolicyAction entity, CancellationToken cancellationToken)
		=> Task.FromResult(entity.ToDto());
}
