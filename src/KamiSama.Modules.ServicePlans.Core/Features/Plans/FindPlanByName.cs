using KamiSama.Modules.ServicePlans.Features.Plans;

namespace KamiSama.Modules.ServicePlans.Features.Plans;

[AutoInjectScoped<IFindPlanByName>]
internal class FindPlanByName(IPlanRepository repository) :
	GenericFindByNameFeature<Plan, PlanDto, IPlanRepository>(repository),
	IFindPlanByName
{
	protected override Task<PlanDto> ConvertToDto(Plan entity, CancellationToken cancellationToken)
		=> Task.FromResult(entity.ToDto());
}
