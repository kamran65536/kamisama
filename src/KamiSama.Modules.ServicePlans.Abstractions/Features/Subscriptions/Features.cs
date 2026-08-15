using KamiSama.Chassis.Commons.Features;

namespace KamiSama.Modules.ServicePlans.Features.Subscriptions;

/// <summary>
/// Defines paged subscription listing using subscriber, plan, and status filters.
/// </summary>
public interface IListSubscriptions : IListFeature<SubscriptionDto, SubscriptionSearchModel>;
/// <summary>
/// Defines creation of a subscription for an existing subscriber and plan.
/// </summary>
public interface IAddSubscription : IAddFeature<AddSubscriptionRequest, SubscriptionDto>;
/// <summary>
/// Defines replacement of subscription relationships, lifecycle state, and usage values.
/// </summary>
public interface IUpdateSubscription : IUpdateFeature<UpdateSubscriptionRequest, Guid>;
/// <summary>
/// Defines deletion of a subscription selected by a <see cref="Guid"/> identifier.
/// </summary>
public interface IDeleteSubscription : IDeleteFeature<Guid>;
/// <summary>
/// Defines lookup of one subscription by its <see cref="Guid"/> identifier.
/// </summary>
public interface IFindSubscriptionById : IFindByIdFeature<SubscriptionDto, Guid>;
