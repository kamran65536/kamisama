# Subscription

<a id="subscription"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.ServicePlans.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.ServicePlans.Core/Entities/Subscription.cs:8](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Core/Entities/Subscription.cs#L8)

Namespace: `KamiSama.Modules.ServicePlans.Entities`

Kind: `Class`

## Description

Represents a subscriber&apos;s acquired plan and remaining usage balance. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public class Subscription
```

## Example

```csharp
var subscription = new Subscription
{
    Subscriber = subscriber, Plan = plan, Status = SubscriptionStatus.Active,
    StartsAt = DateTime.UtcNow, EndsAt = DateTime.UtcNow.AddDays(30),
    RemainingComputationUnits = 1000m, DailyComputationUnits = 0m,
    MonthlyComputationUnits = 0m, ConsumedTrafficBytes = 0,
    CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
};
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Properties

| Member | Description |
| --- | --- |
| [ConsumedTrafficBytes](property-consumedtrafficbytes-58.md) | Gets or sets the total metered traffic consumed by the subscription in bytes. Use it with the surrounding package APIs when composing application code. |
| [CreatedAt](property-createdat-63.md) | Gets or sets the creation timestamp of the subscription. Use it with the surrounding package APIs when composing application code. |
| [DailyComputationUnits](property-dailycomputationunits-48.md) | Gets or sets the computation units consumed during the current daily window. Use it with the surrounding package APIs when composing application code. |
| [EndsAt](property-endsat-38.md) | Gets or sets the optional timestamp at which the subscription expires. Use it with the surrounding package APIs when composing application code. |
| [Id](property-id-13.md) | Gets or sets the identifier of the subscription. Use it with the surrounding package APIs when composing application code. |
| [MonthlyComputationUnits](property-monthlycomputationunits-53.md) | Gets or sets the computation units consumed during the current monthly window. Use it with the surrounding package APIs when composing application code. |
| [Plan](property-plan-23.md) | Gets or sets the plan acquired by the subscriber. Use it with the surrounding package APIs when composing application code. |
| [RemainingComputationUnits](property-remainingcomputationunits-43.md) | Gets or sets the computation units remaining in the subscription. Use it with the surrounding package APIs when composing application code. |
| [StartsAt](property-startsat-33.md) | Gets or sets the timestamp at which the subscription becomes active. Use it with the surrounding package APIs when composing application code. |
| [Status](property-status-28.md) | Gets or sets the status of the subscription. Use it with the surrounding package APIs when composing application code. |
| [Subscriber](property-subscriber-18.md) | Gets or sets the subscriber that owns the subscription. Use it with the surrounding package APIs when composing application code. |
| [UpdatedAt](property-updatedat-68.md) | Gets or sets the last update timestamp of the subscription. Use it with the surrounding package APIs when composing application code. |

