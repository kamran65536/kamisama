# PlanListItemDto

<a id="planlistitemdto"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.ServicePlans.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.ServicePlans.Abstractions/Features/Plans/Dtos.cs:39](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Abstractions/Features/Plans/Dtos.cs#L39)

Namespace: `KamiSama.Modules.ServicePlans.Features.Plans`

Kind: `Record`

## Description

Returns the list-facing fields of a subscription plan. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public record PlanListItemDto(
	Guid Id,
	string Name,
	decimal ComputationUnits,
	int RateLimit,
	SubscriptionPeriodType PeriodType,
	int? DurationInDays,
	bool IsEnabled,
	DateTime CreatedAt,
	DateTime UpdatedAt);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Abstractions/Features/Plans/Dtos.cs#L39)

Returns the list-facing fields of a subscription plan. Use it with the surrounding package APIs when composing application code.

```csharp
public record PlanListItemDto(
	Guid Id,
	string Name,
	decimal ComputationUnits,
	int RateLimit,
	SubscriptionPeriodType PeriodType,
	int? DurationInDays,
	bool IsEnabled,
	DateTime CreatedAt,
	DateTime UpdatedAt);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `Id` | `Guid` | `-` | The plan identifier. |
| `Name` | `string` | `-` | The plan name. |
| `ComputationUnits` | `decimal` | `-` | The allowance supplied by the plan. |
| `RateLimit` | `int` | `-` | The maximum usage rate. |
| `PeriodType` | `SubscriptionPeriodType` | `-` | The allowance period. |
| `DurationInDays` | `int?` | `-` | The optional validity duration in days. |
| `IsEnabled` | `bool` | `-` | Whether the plan is enabled. |
| `CreatedAt` | `DateTime` | `-` | The creation timestamp. |
| `UpdatedAt` | `DateTime` | `-` | The last update timestamp. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

