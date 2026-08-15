using KamiSama.Modules.ServicePlans.Features.Plans;

namespace KamiSama.Modules.ServicePlans.Features.Plans;

[AutoInjectScoped<IFindPlanById>]
internal class FindPlanById(IPlanRepository repository) :
	GenericFindByIdFeature<Plan, PlanDto, IPlanRepository, Guid>(repository),
	IFindPlanById
{
	protected override Task<PlanDto> ConvertToDto(Plan entity, CancellationToken cancellationToken)
		=> Task.FromResult(entity.ToDto());
}
