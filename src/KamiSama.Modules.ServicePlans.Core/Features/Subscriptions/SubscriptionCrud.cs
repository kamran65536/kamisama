using KamiSama.Modules.ServicePlans.Features.Subscriptions;

namespace KamiSama.Modules.ServicePlans.Features.Subscriptions;

[AutoInjectScoped<IListSubscriptions>]
internal class ListSubscriptions(ISubscriptionRepository repository) :
	GenericListFeature<Subscription, SubscriptionDto, SubscriptionSearchModel, ISubscriptionRepository>(repository),
	IListSubscriptions
{
	protected override Task<SubscriptionDto> ConvertToDto(Subscription entity, CancellationToken cancellationToken)
		=> Task.FromResult(entity.ToDto());
}

[AutoInjectScoped<IAddSubscription>]
internal class AddSubscription(
	ISubscriptionRepository repository,
	ISubscriberRepository subscriberRepository,
	IPlanRepository planRepository) :
	GenericAddFeature<AddSubscriptionRequest, ISubscriptionRepository, Subscription, SubscriptionDto>(repository),
	IAddSubscription
{
	protected override async Task<Subscription> ConvertToEntity(AddSubscriptionRequest request, CancellationToken cancellationToken)
	{
		var subscriber = await subscriberRepository.FindByIdAsync(request.SubscriberId, cancellationToken)
			?? throw new NotFoundException<Subscriber>(request.SubscriberId, nameof(request.SubscriberId));
		var plan = await planRepository.FindByIdAsync(request.PlanId, cancellationToken)
			?? throw new NotFoundException<Plan>(request.PlanId, nameof(request.PlanId));
		var now = DateTime.UtcNow;

		return new Subscription
		{
			Subscriber = subscriber,
			Plan = plan,
			Status = request.Status,
			StartsAt = request.StartsAt,
			EndsAt = request.EndsAt,
			RemainingComputationUnits = request.RemainingComputationUnits,
			DailyComputationUnits = request.DailyComputationUnits,
			MonthlyComputationUnits = request.MonthlyComputationUnits,
			ConsumedTrafficBytes = request.ConsumedTrafficBytes,
			CreatedAt = now,
			UpdatedAt = now,
		};
	}

	protected override Task<SubscriptionDto> ConvertToDto(Subscription entity, CancellationToken cancellationToken)
		=> Task.FromResult(entity.ToDto());
}

[AutoInjectScoped<IUpdateSubscription>]
internal class UpdateSubscription(
	ISubscriptionRepository repository,
	ISubscriberRepository subscriberRepository,
	IPlanRepository planRepository) :
	GenericUpdateFeature<UpdateSubscriptionRequest, Subscription, ISubscriptionRepository, Guid>(repository),
	IUpdateSubscription
{
	protected override async Task PatchEntityAsync(Subscription entity, UpdateSubscriptionRequest request, CancellationToken cancellationToken)
	{
		entity.Subscriber = await subscriberRepository.FindByIdAsync(request.SubscriberId, cancellationToken)
			?? throw new NotFoundException<Subscriber>(request.SubscriberId, nameof(request.SubscriberId));
		entity.Plan = await planRepository.FindByIdAsync(request.PlanId, cancellationToken)
			?? throw new NotFoundException<Plan>(request.PlanId, nameof(request.PlanId));
		entity.Status = request.Status;
		entity.StartsAt = request.StartsAt;
		entity.EndsAt = request.EndsAt;
		entity.RemainingComputationUnits = request.RemainingComputationUnits;
		entity.DailyComputationUnits = request.DailyComputationUnits;
		entity.MonthlyComputationUnits = request.MonthlyComputationUnits;
		entity.ConsumedTrafficBytes = request.ConsumedTrafficBytes;
		entity.UpdatedAt = DateTime.UtcNow;
	}
}

[AutoInjectScoped<IDeleteSubscription>]
internal class DeleteSubscription(ISubscriptionRepository repository) :
	GenericDeleteFeature<Subscription, ISubscriptionRepository, Guid>(repository),
	IDeleteSubscription;

[AutoInjectScoped<IFindSubscriptionById>]
internal class FindSubscriptionById(ISubscriptionRepository repository) :
	GenericFindByIdFeature<Subscription, SubscriptionDto, ISubscriptionRepository, Guid>(repository),
	IFindSubscriptionById
{
	protected override Task<SubscriptionDto> ConvertToDto(Subscription entity, CancellationToken cancellationToken)
		=> Task.FromResult(entity.ToDto());
}
