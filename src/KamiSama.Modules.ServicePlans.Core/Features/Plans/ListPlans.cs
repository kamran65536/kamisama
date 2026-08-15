using KamiSama.Modules.ServicePlans.Features.Plans;

namespace KamiSama.Modules.ServicePlans.Features.Plans;

[AutoInjectScoped<IListPlans>]
internal class ListPlans(IPlanRepository repository) :
	GenericListFeature<Plan, PlanListItemDto, PlanSearchModel, IPlanRepository>(repository),
	IListPlans
{
	protected override Task<PlanListItemDto> ConvertToDto(Plan entity, CancellationToken cancellationToken)
		=> Task.FromResult(entity.ToListItemDto());
}
