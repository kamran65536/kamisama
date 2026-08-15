# IListCities

<a id="ilistcities"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Locations.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Locations.Abstractions/Features/Features.cs:30](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Abstractions/Features/Features.cs#L30)

Namespace: `KamiSama.Modules.Locations.Features`

Kind: `Interface`

## Description

Defines paged city listing through `CitySearchModel`. Core can shape the query by city name, parent id, parent name, and the `province` order token.

## Declaration

```csharp
public interface IListCities : IListFeature<CityDto, CitySearchModel>;
```

## Example

```csharp
PagedResult<CityDto> cities = await listCities.ListAsync(
    new CitySearchModel(1, 20, provinceId, null, null, "province"), cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

