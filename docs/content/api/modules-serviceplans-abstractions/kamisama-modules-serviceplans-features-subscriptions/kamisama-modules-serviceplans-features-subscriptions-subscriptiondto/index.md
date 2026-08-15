# SubscriptionDto

<a id="subscriptiondto"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.ServicePlans.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.ServicePlans.Abstractions/Features/Subscriptions/Dtos.cs:42](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Abstractions/Features/Subscriptions/Dtos.cs#L42)

Namespace: `KamiSama.Modules.ServicePlans.Features.Subscriptions`

Kind: `Record`

## Description

Returns a subscriber&apos;s acquired plan, lifecycle state, and caller-managed usage counters. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public record SubscriptionDto(
	Guid Id,
	Guid SubscriberId,
	Guid PlanId,
	SubscriptionStatus Status,
	DateTime StartsAt,
	DateTime? EndsAt,
	decimal RemainingComputationUnits,
	decimal DailyComputationUnits,
	decimal MonthlyComputationUnits,
	long ConsumedTrafficBytes,
	DateTime CreatedAt,
	DateTime UpdatedAt);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Abstractions/Features/Subscriptions/Dtos.cs#L42)

Returns a subscriber&apos;s acquired plan, lifecycle state, and caller-managed usage counters. Use it with the surrounding package APIs when composing application code.

```csharp
public record SubscriptionDto(
	Guid Id,
	Guid SubscriberId,
	Guid PlanId,
	SubscriptionStatus Status,
	DateTime StartsAt,
	DateTime? EndsAt,
	decimal RemainingComputationUnits,
	decimal DailyComputationUnits,
	decimal MonthlyComputationUnits,
	long ConsumedTrafficBytes,
	DateTime CreatedAt,
	DateTime UpdatedAt);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `Id` | `Guid` | `-` | The subscription identifier. |
| `SubscriberId` | `Guid` | `-` | The owning subscriber identifier. |
| `PlanId` | `Guid` | `-` | The acquired plan identifier. |
| `Status` | `SubscriptionStatus` | `-` | The subscription status. |
| `StartsAt` | `DateTime` | `-` | The activation timestamp. |
| `EndsAt` | `DateTime?` | `-` | The optional expiration timestamp. |
| `RemainingComputationUnits` | `decimal` | `-` | The remaining allowance. |
| `DailyComputationUnits` | `decimal` | `-` | The daily usage counter. |
| `MonthlyComputationUnits` | `decimal` | `-` | The monthly usage counter. |
| `ConsumedTrafficBytes` | `long` | `-` | The consumed traffic counter in bytes. |
| `CreatedAt` | `DateTime` | `-` | The creation timestamp. |
| `UpdatedAt` | `DateTime` | `-` | The last update timestamp. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

