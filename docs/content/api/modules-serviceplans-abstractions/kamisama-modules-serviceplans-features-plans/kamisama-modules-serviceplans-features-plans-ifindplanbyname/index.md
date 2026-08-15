# IFindPlanByName

<a id="ifindplanbyname"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.ServicePlans.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.ServicePlans.Abstractions/Features/Plans/Features.cs:28](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Abstractions/Features/Plans/Features.cs#L28)

Namespace: `KamiSama.Modules.ServicePlans.Features.Plans`

Kind: `Interface`

## Description

Defines plan lookup by case-normalized exact name. Core's translated lowercase comparison depends on provider behavior.

## Declaration

```csharp
public interface IFindPlanByName : IFindByNameFeature<PlanDto>;
```

## Example

```csharp
PlanDto plan = await findPlanByName.FindByNameAsync("Standard", cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

