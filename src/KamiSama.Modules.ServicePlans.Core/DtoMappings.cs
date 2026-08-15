using KamiSama.Modules.ServicePlans.Features.Plans;
using KamiSama.Modules.ServicePlans.Features.Subscribers;
using KamiSama.Modules.ServicePlans.Features.Subscriptions;
using Riok.Mapperly.Abstractions;

namespace KamiSama.Modules.ServicePlans;

[Mapper]
internal static partial class DtoMappings
{
	[MapperIgnoreSource(nameof(Plan.Offers))]
	[MapperIgnoreSource(nameof(Plan.Subscriptions))]
	public static partial PlanListItemDto ToListItemDto(this Plan entity);

	[MapperIgnoreSource(nameof(Plan.Offers))]
	[MapperIgnoreSource(nameof(Plan.Subscriptions))]
	public static partial PlanDto ToDto(this Plan entity);

	public static SubscriberDto ToDto(this Subscriber entity)
		=> new(entity.Id, entity.ExternalUserId, entity.IsEnabled, entity.CreatedAt, entity.UpdatedAt);

	public static SubscriptionDto ToDto(this Subscription entity)
		=> new(entity.Id, entity.Subscriber.Id, entity.Plan.Id, entity.Status, entity.StartsAt, entity.EndsAt,
			entity.RemainingComputationUnits, entity.DailyComputationUnits, entity.MonthlyComputationUnits,
			entity.ConsumedTrafficBytes, entity.CreatedAt, entity.UpdatedAt);
}
