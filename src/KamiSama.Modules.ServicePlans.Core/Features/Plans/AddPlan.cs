using KamiSama.Modules.ServicePlans.Features.Plans;

namespace KamiSama.Modules.ServicePlans.Features.Plans;

[AutoInjectScoped<IAddPlan>]
internal class AddPlan(IPlanRepository repository) :
	GenericAddFeature<AddPlanRequest, IPlanRepository, Plan, PlanDto>(repository),
	IAddPlan
{
	protected override async Task CheckDuplicateAsync(AddPlanRequest request, CancellationToken cancellationToken)
	{
		if (await Repository.ExistsByNameAsync(request.Name, cancellationToken))
			throw new AlreadyExistsException<Plan>(request.Name, nameof(request.Name));
	}

	protected override Task<Plan> ConvertToEntity(AddPlanRequest request, CancellationToken cancellationToken)
		=> Task.FromResult(new Plan
		{
			Name = request.Name,
			ComputationUnits = request.ComputationUnits,
			RateLimit = request.RateLimit,
			PeriodType = request.PeriodType,
			DurationInDays = request.DurationInDays,
			IsEnabled = request.IsEnabled,
			CreatedAt = DateTime.UtcNow,
			UpdatedAt = DateTime.UtcNow,
		});

	protected override Task<PlanDto> ConvertToDto(Plan entity, CancellationToken cancellationToken)
		=> Task.FromResult(entity.ToDto());
}
