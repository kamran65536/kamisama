using KamiSama.Modules.ServicePlans.Features.Subscriptions;

namespace KamiSama.Modules.ServicePlans.Repositories.Abstractions;

internal interface ISubscriptionRepository :
	IGenericRepository<Subscription, SubscriptionSearchModel>,
	ILookupByIdRepository<Subscription, Guid>
{
}
