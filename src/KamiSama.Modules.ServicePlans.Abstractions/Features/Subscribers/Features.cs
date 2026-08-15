using KamiSama.Chassis.Commons.Features;

namespace KamiSama.Modules.ServicePlans.Features.Subscribers;

/// <summary>
/// Defines paged subscriber listing using external-user and enabled-state filters.
/// </summary>
public interface IListSubscribers : IListFeature<SubscriberDto, SubscriberSearchModel>;
/// <summary>
/// Defines creation of a subscriber linked to an externally managed user.
/// </summary>
public interface IAddSubscriber : IAddFeature<AddSubscriberRequest, SubscriberDto>;
/// <summary>
/// Defines replacement of subscriber values selected by a <see cref="Guid"/> identifier.
/// </summary>
public interface IUpdateSubscriber : IUpdateFeature<UpdateSubscriberRequest, Guid>;
/// <summary>
/// Defines deletion of a subscriber selected by a <see cref="Guid"/> identifier.
/// </summary>
public interface IDeleteSubscriber : IDeleteFeature<Guid>;
/// <summary>
/// Defines lookup of one subscriber by its <see cref="Guid"/> identifier.
/// </summary>
public interface IFindSubscriberById : IFindByIdFeature<SubscriberDto, Guid>;
