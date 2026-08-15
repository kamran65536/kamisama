# AddPlanRequest

<a id="addplanrequest"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.ServicePlans.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.ServicePlans.Abstractions/Features/Plans/Dtos.cs:82](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Abstractions/Features/Plans/Dtos.cs#L82)

Namespace: `KamiSama.Modules.ServicePlans.Features.Plans`

Kind: `Record`

## Description

Carries caller-supplied values for creating a plan. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public record AddPlanRequest(
	string Name,
	decimal ComputationUnits,
	int RateLimit,
	SubscriptionPeriodType PeriodType,
	int? DurationInDays,
	bool IsEnabled);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Abstractions/Features/Plans/Dtos.cs#L82)

Carries caller-supplied values for creating a plan. Use it with the surrounding package APIs when composing application code.

```csharp
public record AddPlanRequest(
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
| `Name` | `string` | `-` | The plan name. |
| `ComputationUnits` | `decimal` | `-` | The allowance supplied by the plan. |
| `RateLimit` | `int` | `-` | The maximum usage rate. |
| `PeriodType` | `SubscriptionPeriodType` | `-` | The allowance period. |
| `DurationInDays` | `int?` | `-` | The optional validity duration in days. |
| `IsEnabled` | `bool` | `-` | Whether the new plan is enabled. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

