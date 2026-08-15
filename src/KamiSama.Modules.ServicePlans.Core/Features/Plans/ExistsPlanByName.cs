using KamiSama.Modules.ServicePlans.Features.Plans;

namespace KamiSama.Modules.ServicePlans.Features.Plans;

[AutoInjectScoped<IExistsPlanByName>]
internal class ExistsPlanByName(IPlanRepository repository) :
	GenericExistsByNameFeature<Plan, IPlanRepository>(repository),
	IExistsPlanByName
{
}
