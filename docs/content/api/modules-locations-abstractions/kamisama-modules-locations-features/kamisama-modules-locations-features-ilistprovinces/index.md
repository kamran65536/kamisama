# IListProvinces

<a id="ilistprovinces"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Locations.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Locations.Abstractions/Features/Features.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Abstractions/Features/Features.cs#L9)

Namespace: `KamiSama.Modules.Locations.Features`

Kind: `Interface`

## Description

Defines paged province listing through `ProvinceSearchModel`. Core filters by a case-normalized name substring and always orders by name.

## Declaration

```csharp
public interface IListProvinces : IListFeature<ProvinceDto, ProvinceSearchModel>;
```

## Example

```csharp
PagedResult<ProvinceDto> provinces = await listProvinces.ListAsync(
    new ProvinceSearchModel(1, 20, "north", null), cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

