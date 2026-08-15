using KamiSama.Modules.ServicePlans.Features.Subscribers;

namespace KamiSama.Modules.ServicePlans.Repositories.Abstractions;

internal interface ISubscriberRepository :
	IGenericRepository<Subscriber, SubscriberSearchModel>,
	ILookupByIdRepository<Subscriber, Guid>
{
	Task<Subscriber?> FindByExternalUserIdAsync(Guid externalUserId, CancellationToken cancellationToken);
}
