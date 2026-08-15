# AddSubscriptionRequest

<a id="addsubscriptionrequest"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.ServicePlans.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.ServicePlans.Abstractions/Features/Subscriptions/Dtos.cs:68](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Abstractions/Features/Subscriptions/Dtos.cs#L68)

Namespace: `KamiSama.Modules.ServicePlans.Features.Subscriptions`

Kind: `Record`

## Description

Carries caller-supplied relationship, lifecycle, and usage values for creating a subscription. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public record AddSubscriptionRequest(
	Guid SubscriberId,
	Guid PlanId,
	SubscriptionStatus Status,
	DateTime StartsAt,
	DateTime? EndsAt,
	decimal RemainingComputationUnits,
	decimal DailyComputationUnits,
	decimal MonthlyComputationUnits,
	long ConsumedTrafficBytes);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Abstractions/Features/Subscriptions/Dtos.cs#L68)

Carries caller-supplied relationship, lifecycle, and usage values for creating a subscription. Use it with the surrounding package APIs when composing application code.

```csharp
public record AddSubscriptionRequest(
	Guid SubscriberId,
	Guid PlanId,
	SubscriptionStatus Status,
	DateTime StartsAt,
	DateTime? EndsAt,
	decimal RemainingComputationUnits,
	decimal DailyComputationUnits,
	decimal MonthlyComputationUnits,
	long ConsumedTrafficBytes);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `SubscriberId` | `Guid` | `-` | The existing subscriber identifier. |
| `PlanId` | `Guid` | `-` | The existing plan identifier. |
| `Status` | `SubscriptionStatus` | `-` | The initial subscription status. |
| `StartsAt` | `DateTime` | `-` | The activation timestamp. |
| `EndsAt` | `DateTime?` | `-` | The optional expiration timestamp. |
| `RemainingComputationUnits` | `decimal` | `-` | The initial remaining allowance. |
| `DailyComputationUnits` | `decimal` | `-` | The initial daily usage counter. |
| `MonthlyComputationUnits` | `decimal` | `-` | The initial monthly usage counter. |
| `ConsumedTrafficBytes` | `long` | `-` | The initial consumed traffic counter in bytes. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

