# IFindCityById

<a id="ifindcitybyid"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Locations.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Locations.Abstractions/Features/Features.cs:34](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Abstractions/Features/Features.cs#L34)

Namespace: `KamiSama.Modules.Locations.Features`

Kind: `Interface`

## Description

Defines city lookup by `Guid` and returns parent province data in the DTO. Core throws the generic city not-found HTTP exception when absent.

## Declaration

```csharp
public interface IFindCityById : IFindByIdFeature<CityDto, Guid>;
```

## Example

```csharp
CityDto city = await findCityById.FindByIdAsync(cityId, cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

