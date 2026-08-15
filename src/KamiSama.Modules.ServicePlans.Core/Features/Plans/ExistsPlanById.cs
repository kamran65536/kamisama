using KamiSama.Modules.ServicePlans.Features.Plans;

namespace KamiSama.Modules.ServicePlans.Features.Plans;

[AutoInjectScoped<IExistsPlanById>]
internal class ExistsPlanById(IPlanRepository repository) :
	GenericExistsByIdFeature<Plan, IPlanRepository, Guid>(repository),
	IExistsPlanById
{
}
