using KamiSama.Modules.ServicePlans.Features.Plans;

namespace KamiSama.Modules.ServicePlans.Features.Plans;

[AutoInjectScoped<IDeletePlan>]
internal class DeletePlan(IPlanRepository repository) :
	GenericDeleteFeature<Plan, IPlanRepository, Guid>(repository),
	IDeletePlan
{
}
