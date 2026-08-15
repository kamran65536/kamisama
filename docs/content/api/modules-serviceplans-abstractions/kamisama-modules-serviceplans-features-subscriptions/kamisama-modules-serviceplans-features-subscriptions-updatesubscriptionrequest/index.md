# UpdateSubscriptionRequest

<a id="updatesubscriptionrequest"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.ServicePlans.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.ServicePlans.Abstractions/Features/Subscriptions/Dtos.cs:91](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Abstractions/Features/Subscriptions/Dtos.cs#L91)

Namespace: `KamiSama.Modules.ServicePlans.Features.Subscriptions`

Kind: `Record`

## Description

Carries replacement relationship, lifecycle, and usage values for an existing subscription. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public record UpdateSubscriptionRequest(
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

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Abstractions/Features/Subscriptions/Dtos.cs#L91)

Carries replacement relationship, lifecycle, and usage values for an existing subscription. Use it with the surrounding package APIs when composing application code.

```csharp
public record UpdateSubscriptionRequest(
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
| `SubscriberId` | `Guid` | `-` | The replacement existing subscriber identifier. |
| `PlanId` | `Guid` | `-` | The replacement existing plan identifier. |
| `Status` | `SubscriptionStatus` | `-` | The replacement subscription status. |
| `StartsAt` | `DateTime` | `-` | The replacement activation timestamp. |
| `EndsAt` | `DateTime?` | `-` | The replacement optional expiration timestamp. |
| `RemainingComputationUnits` | `decimal` | `-` | The replacement remaining allowance. |
| `DailyComputationUnits` | `decimal` | `-` | The replacement daily usage counter. |
| `MonthlyComputationUnits` | `decimal` | `-` | The replacement monthly usage counter. |
| `ConsumedTrafficBytes` | `long` | `-` | The replacement consumed traffic counter in bytes. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

