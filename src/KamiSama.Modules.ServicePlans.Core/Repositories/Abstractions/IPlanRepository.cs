using KamiSama.Modules.ServicePlans.Features.Plans;

namespace KamiSama.Modules.ServicePlans.Repositories.Abstractions;

internal interface IPlanRepository :
	IGenericRepository<Plan, PlanSearchModel>,
	ILookupByIdRepository<Plan, Guid>,
	ILookupByNameRepository<Plan>
{
}
