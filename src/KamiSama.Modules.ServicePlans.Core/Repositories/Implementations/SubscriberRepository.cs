using KamiSama.Modules.ServicePlans.Features.Subscribers;

namespace KamiSama.Modules.ServicePlans.Repositories.Implementations;

[AutoInjectScoped<ISubscriberRepository>]
internal class SubscriberRepository(ServicePlansDbContext context) :
	GenericRepository<Subscriber, SubscriberSearchModel, ServicePlansDbContext>(context),
	ISubscriberRepository
{
	protected override IQueryable<Subscriber> ApplySearchModel(IQueryable<Subscriber> query, SubscriberSearchModel searchModel)
	{
		if (searchModel.ExternalUserId is not null)
			query = query.Where(x => x.ExternalUserId == searchModel.ExternalUserId);
		if (searchModel.IsEnabled is not null)
			query = query.Where(x => x.IsEnabled == searchModel.IsEnabled);

		return searchModel.OrderBy?.ToLower() switch
		{
			"externaluserid" => query.OrderBy(x => x.ExternalUserId),
			"createdat" => query.OrderBy(x => x.CreatedAt),
			"updatedat" => query.OrderBy(x => x.UpdatedAt),
			_ => query.OrderBy(x => x.CreatedAt),
		};
	}

	public Task<Subscriber?> FindByIdAsync(Guid id, CancellationToken cancellationToken)
		=> FindAsync(x => x.Id == id, cancellationToken);

	public Task<bool> ExistsByIdAsync(Guid id, CancellationToken cancellationToken)
		=> AnyAsync(x => x.Id == id, cancellationToken);

	public Task<Subscriber?> FindByExternalUserIdAsync(Guid externalUserId, CancellationToken cancellationToken)
		=> FindAsync(x => x.ExternalUserId == externalUserId, cancellationToken);
}
