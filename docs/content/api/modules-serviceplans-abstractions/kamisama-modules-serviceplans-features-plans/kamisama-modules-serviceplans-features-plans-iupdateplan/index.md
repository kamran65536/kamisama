# IUpdatePlan

<a id="iupdateplan"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.ServicePlans.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.ServicePlans.Abstractions/Features/Plans/Features.cs:16](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Abstractions/Features/Plans/Features.cs#L16)

Namespace: `KamiSama.Modules.ServicePlans.Features.Plans`

Kind: `Interface`

## Description

Defines replacement of a plan by `Guid`. Core performs a separate duplicate-name read, updates timestamps, and saves immediately.

## Declaration

```csharp
public interface IUpdatePlan : IUpdateFeature<UpdatePlanRequest, Guid>;
```

## Example

```csharp
await updatePlan.UpdateAsync(planId, new UpdatePlanRequest(
    "Standard", 1500m, 25, SubscriptionPeriodType.Monthly, 30, true), cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

