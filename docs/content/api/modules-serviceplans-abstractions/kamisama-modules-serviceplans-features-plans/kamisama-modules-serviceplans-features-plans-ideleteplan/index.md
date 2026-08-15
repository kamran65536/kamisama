# IDeletePlan

<a id="ideleteplan"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.ServicePlans.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.ServicePlans.Abstractions/Features/Plans/Features.cs:20](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Abstractions/Features/Plans/Features.cs#L20)

Namespace: `KamiSama.Modules.ServicePlans.Features.Plans`

Kind: `Interface`

## Description

Defines deletion of a plan by `Guid`. Core applies no deletion guard before saving the deletion.

## Declaration

```csharp
public interface IDeletePlan : IDeleteFeature<Guid>;
```

## Example

```csharp
await deletePlan.DeleteAsync(planId, cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

