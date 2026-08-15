using KamiSama.Modules.ServicePlans.Features.Plans;

namespace KamiSama.Modules.ServicePlans.Features.Plans;

[AutoInjectScoped<IUpdatePlan>]
internal class UpdatePlan(IPlanRepository repository) :
	GenericUpdateFeature<UpdatePlanRequest, Plan, IPlanRepository, Guid>(repository),
	IUpdatePlan
{
	protected override async Task CheckDuplicateAsync(Guid id, UpdatePlanRequest request, CancellationToken cancellationToken)
	{
		var entity = await Repository.FindByNameAsync(request.Name, cancellationToken);
		if (entity is not null && entity.Id != id)
			throw new AlreadyExistsException<Plan>(request.Name, nameof(request.Name));
	}

	protected override Task PatchEntityAsync(Plan entity, UpdatePlanRequest request, CancellationToken cancellationToken)
	{
		entity.Name = request.Name;
		entity.ComputationUnits = request.ComputationUnits;
		entity.RateLimit = request.RateLimit;
		entity.PeriodType = request.PeriodType;
		entity.DurationInDays = request.DurationInDays;
		entity.IsEnabled = request.IsEnabled;
		entity.UpdatedAt = DateTime.UtcNow;
		return Task.CompletedTask;
	}
}
