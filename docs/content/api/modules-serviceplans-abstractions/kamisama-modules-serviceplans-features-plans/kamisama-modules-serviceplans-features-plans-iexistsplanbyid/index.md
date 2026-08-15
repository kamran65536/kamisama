# IExistsPlanById

<a id="iexistsplanbyid"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.ServicePlans.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.ServicePlans.Abstractions/Features/Plans/Features.cs:32](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Abstractions/Features/Plans/Features.cs#L32)

Namespace: `KamiSama.Modules.ServicePlans.Features.Plans`

Kind: `Interface`

## Description

Defines an existence check for a plan `Guid`.

## Declaration

```csharp
public interface IExistsPlanById : IExistsByIdFeature<Guid>;
```

## Example

```csharp
bool exists = await existsPlanById.ExistsByIdAsync(planId, cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

