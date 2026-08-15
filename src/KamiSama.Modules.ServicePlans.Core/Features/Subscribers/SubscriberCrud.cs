using KamiSama.Modules.ServicePlans.Features.Subscribers;

namespace KamiSama.Modules.ServicePlans.Features.Subscribers;

[AutoInjectScoped<IListSubscribers>]
internal class ListSubscribers(ISubscriberRepository repository) :
	GenericListFeature<Subscriber, SubscriberDto, SubscriberSearchModel, ISubscriberRepository>(repository),
	IListSubscribers
{
	protected override Task<SubscriberDto> ConvertToDto(Subscriber entity, CancellationToken cancellationToken)
		=> Task.FromResult(entity.ToDto());
}

[AutoInjectScoped<IAddSubscriber>]
internal class AddSubscriber(ISubscriberRepository repository) :
	GenericAddFeature<AddSubscriberRequest, ISubscriberRepository, Subscriber, SubscriberDto>(repository),
	IAddSubscriber
{
	protected override async Task CheckDuplicateAsync(AddSubscriberRequest request, CancellationToken cancellationToken)
	{
		if (await Repository.FindByExternalUserIdAsync(request.ExternalUserId, cancellationToken) is not null)
			throw new AlreadyExistsException<Subscriber>(request.ExternalUserId, nameof(request.ExternalUserId));
	}

	protected override Task<Subscriber> ConvertToEntity(AddSubscriberRequest request, CancellationToken cancellationToken)
	{
		var now = DateTime.UtcNow;
		return Task.FromResult(new Subscriber
		{
			ExternalUserId = request.ExternalUserId,
			IsEnabled = request.IsEnabled,
			CreatedAt = now,
			UpdatedAt = now,
		});
	}

	protected override Task<SubscriberDto> ConvertToDto(Subscriber entity, CancellationToken cancellationToken)
		=> Task.FromResult(entity.ToDto());
}

[AutoInjectScoped<IUpdateSubscriber>]
internal class UpdateSubscriber(ISubscriberRepository repository) :
	GenericUpdateFeature<UpdateSubscriberRequest, Subscriber, ISubscriberRepository, Guid>(repository),
	IUpdateSubscriber
{
	protected override async Task CheckDuplicateAsync(Guid id, UpdateSubscriberRequest request, CancellationToken cancellationToken)
	{
		var entity = await Repository.FindByExternalUserIdAsync(request.ExternalUserId, cancellationToken);
		if (entity is not null && entity.Id != id)
			throw new AlreadyExistsException<Subscriber>(request.ExternalUserId, nameof(request.ExternalUserId));
	}

	protected override Task PatchEntityAsync(Subscriber entity, UpdateSubscriberRequest request, CancellationToken cancellationToken)
	{
		entity.ExternalUserId = request.ExternalUserId;
		entity.IsEnabled = request.IsEnabled;
		entity.UpdatedAt = DateTime.UtcNow;
		return Task.CompletedTask;
	}
}

[AutoInjectScoped<IDeleteSubscriber>]
internal class DeleteSubscriber(ISubscriberRepository repository) :
	GenericDeleteFeature<Subscriber, ISubscriberRepository, Guid>(repository),
	IDeleteSubscriber;

[AutoInjectScoped<IFindSubscriberById>]
internal class FindSubscriberById(ISubscriberRepository repository) :
	GenericFindByIdFeature<Subscriber, SubscriberDto, ISubscriberRepository, Guid>(repository),
	IFindSubscriberById
{
	protected override Task<SubscriberDto> ConvertToDto(Subscriber entity, CancellationToken cancellationToken)
		=> Task.FromResult(entity.ToDto());
}
