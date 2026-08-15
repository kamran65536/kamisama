using KamiSama.Modules.ServicePlans.Features.Subscriptions;

namespace KamiSama.Modules.ServicePlans.Repositories.Implementations;

[AutoInjectScoped<ISubscriptionRepository>]
internal class SubscriptionRepository(ServicePlansDbContext context) :
	GenericRepository<Subscription, SubscriptionSearchModel, ServicePlansDbContext>(context),
	ISubscriptionRepository
{
	protected override IQueryable<Subscription> ApplySearchModel(IQueryable<Subscription> query, SubscriptionSearchModel searchModel)
	{
		if (searchModel.SubscriberId is not null)
			query = query.Where(x => x.Subscriber.Id == searchModel.SubscriberId);
		if (searchModel.PlanId is not null)
			query = query.Where(x => x.Plan.Id == searchModel.PlanId);
		if (searchModel.Statuses is { Length: > 0 })
			query = query.Where(x => searchModel.Statuses.Contains(x.Status));

		return searchModel.OrderBy?.ToLower() switch
		{
			"status" => query.OrderBy(x => x.Status),
			"startsat" => query.OrderBy(x => x.StartsAt),
			"endsat" => query.OrderBy(x => x.EndsAt),
			"updatedat" => query.OrderBy(x => x.UpdatedAt),
			_ => query.OrderBy(x => x.StartsAt),
		};
	}

	public Task<Subscription?> FindByIdAsync(Guid id, CancellationToken cancellationToken)
		=> FindAsync(x => x.Id == id, cancellationToken);

	public Task<bool> ExistsByIdAsync(Guid id, CancellationToken cancellationToken)
		=> AnyAsync(x => x.Id == id, cancellationToken);
}
