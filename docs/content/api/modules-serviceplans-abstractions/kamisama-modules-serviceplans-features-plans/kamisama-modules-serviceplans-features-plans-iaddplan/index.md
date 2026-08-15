# IAddPlan

<a id="iaddplan"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.ServicePlans.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.ServicePlans.Abstractions/Features/Plans/Features.cs:12](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Abstractions/Features/Plans/Features.cs#L12)

Namespace: `KamiSama.Modules.ServicePlans.Features.Plans`

Kind: `Interface`

## Description

Defines plan creation. Core checks name duplication before immediately saving but performs no numeric, period/duration, or enabled-state domain validation.

## Declaration

```csharp
public interface IAddPlan : IAddFeature<AddPlanRequest, PlanDto>;
```

## Example

```csharp
PlanDto plan = await addPlan.AddAsync(new AddPlanRequest(
    "Standard", 1000m, 20, SubscriptionPeriodType.Monthly, 30, true), cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

