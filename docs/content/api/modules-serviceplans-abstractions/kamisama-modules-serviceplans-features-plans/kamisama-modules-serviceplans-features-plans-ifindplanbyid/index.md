# IFindPlanById

<a id="ifindplanbyid"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.ServicePlans.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.ServicePlans.Abstractions/Features/Plans/Features.cs:24](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Abstractions/Features/Plans/Features.cs#L24)

Namespace: `KamiSama.Modules.ServicePlans.Features.Plans`

Kind: `Interface`

## Description

Defines plan lookup by `Guid`. Core throws the generic plan not-found HTTP exception when no row matches.

## Declaration

```csharp
public interface IFindPlanById : IFindByIdFeature<PlanDto, Guid>;
```

## Example

```csharp
PlanDto plan = await findPlanById.FindByIdAsync(planId, cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

