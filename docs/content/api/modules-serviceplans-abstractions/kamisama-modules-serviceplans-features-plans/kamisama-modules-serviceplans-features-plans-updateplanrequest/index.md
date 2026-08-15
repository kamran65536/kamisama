# UpdatePlanRequest

<a id="updateplanrequest"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.ServicePlans.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.ServicePlans.Abstractions/Features/Plans/Dtos.cs:99](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Abstractions/Features/Plans/Dtos.cs#L99)

Namespace: `KamiSama.Modules.ServicePlans.Features.Plans`

Kind: `Record`

## Description

Carries replacement values for an existing plan. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public record UpdatePlanRequest(
	string Name,
	decimal ComputationUnits,
	int RateLimit,
	SubscriptionPeriodType PeriodType,
	int? DurationInDays,
	bool IsEnabled);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Abstractions/Features/Plans/Dtos.cs#L99)

Carries replacement values for an existing plan. Use it with the surrounding package APIs when composing application code.

```csharp
public record UpdatePlanRequest(
	string Name,
	decimal ComputationUnits,
	int RateLimit,
	SubscriptionPeriodType PeriodType,
	int? DurationInDays,
	bool IsEnabled);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `Name` | `string` | `-` | The replacement plan name. |
| `ComputationUnits` | `decimal` | `-` | The replacement allowance. |
| `RateLimit` | `int` | `-` | The replacement maximum usage rate. |
| `PeriodType` | `SubscriptionPeriodType` | `-` | The replacement allowance period. |
| `DurationInDays` | `int?` | `-` | The replacement optional validity duration in days. |
| `IsEnabled` | `bool` | `-` | Whether the plan is enabled. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

