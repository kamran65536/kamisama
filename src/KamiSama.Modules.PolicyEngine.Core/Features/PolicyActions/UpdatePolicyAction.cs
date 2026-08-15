using KamiSama.Modules.PolicyEngine.Features.PolicyActions;

namespace KamiSama.Modules.PolicyEngine.Features.PolicyActions;

[AutoInjectScoped<IUpdatePolicyAction>]
internal class UpdatePolicyAction(IPolicyActionRepository repository) :
	GenericUpdateFeature<UpdatePolicyActionRequest, PolicyAction, IPolicyActionRepository, Guid>(repository),
	IUpdatePolicyAction
{
	protected override async Task CheckDuplicateAsync(Guid id, UpdatePolicyActionRequest request, CancellationToken cancellationToken)
	{
		var entity = await Repository.FindByNameAsync(request.Name, cancellationToken);
		if (entity != null && entity.Id != id)
			throw new AlreadyExistsException<PolicyAction>(request.Name, nameof(request.Name));
	}

	protected override Task PatchEntityAsync(PolicyAction entity, UpdatePolicyActionRequest request, CancellationToken cancellationToken)
	{
		entity.Name = request.Name;
		entity.HandlerName = request.HandlerName;
		entity.ConfigurationSource = request.ConfigurationSource;
		entity.AllowsMultiple = request.AllowsMultiple;
		entity.IsEnabled = request.IsEnabled;
		entity.UpdatedAt = DateTime.UtcNow;
		return Task.CompletedTask;
	}
}
