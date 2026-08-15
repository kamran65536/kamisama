# Plan

<a id="plan"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.ServicePlans.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.ServicePlans.Core/Entities/Plan.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Core/Entities/Plan.cs#L9)

Namespace: `KamiSama.Modules.ServicePlans.Entities`

Kind: `Class`

## Description

Represents a reusable subscription definition. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public class Plan
```

## Example

```csharp
var plan = new Plan
{
    Name = "Standard", ComputationUnits = 1000m, RateLimit = 20,
    PeriodType = SubscriptionPeriodType.Monthly, DurationInDays = 30, IsEnabled = true,
    CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
};
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Properties

| Member | Description |
| --- | --- |
| [ComputationUnits](property-computationunits-25.md) | Gets or sets the usage units provided by the plan during its allowance period. Use it with the surrounding package APIs when composing application code. |
| [CreatedAt](property-createdat-50.md) | Gets or sets the creation timestamp of the subscription plan. Use it with the surrounding package APIs when composing application code. |
| [DurationInDays](property-durationindays-40.md) | Gets or sets the optional number of days for which an activated plan remains valid. Use it with the surrounding package APIs when composing application code. |
| [Id](property-id-14.md) | Gets or sets the identifier of the subscription plan. Use it with the surrounding package APIs when composing application code. |
| [IsEnabled](property-isenabled-45.md) | Gets or sets a value indicating whether the subscription plan may be offered to users. Use it with the surrounding package APIs when composing application code. |
| [Name](property-name-19.md) | Gets or sets the unique name of the subscription plan. Use it with the surrounding package APIs when composing application code. |
| [Offers](property-offers-60.md) | Gets or sets the offers through which the subscription plan may be acquired. Use it with the surrounding package APIs when composing application code. |
| [PeriodType](property-periodtype-35.md) | Gets or sets the period over which the plan allowance is measured. Use it with the surrounding package APIs when composing application code. |
| [RateLimit](property-ratelimit-30.md) | Gets or sets the maximum usage rate allowed by the plan. Use it with the surrounding package APIs when composing application code. |
| [Subscriptions](property-subscriptions-65.md) | Gets or sets the subscriptions created from this plan. Use it with the surrounding package APIs when composing application code. |
| [UpdatedAt](property-updatedat-55.md) | Gets or sets the last update timestamp of the subscription plan. Use it with the surrounding package APIs when composing application code. |

