# IListCitiesByProvinceName

<a id="ilistcitiesbyprovincename"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Locations.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Locations.Abstractions/Features/Features.cs:51](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Abstractions/Features/Features.cs#L51)

Namespace: `KamiSama.Modules.Locations.Features`

Kind: `Interface`

## Description

Defines city listing by a parent-province name substring. Core starts from `CitySearchModel.All`, so the result is page-shaped but contains all matches rather than a finite page.

## Declaration

```csharp
public interface IListCitiesByProvinceName
```

## Example

```csharp
PagedResult<CityDto> cities = await listCitiesByProvinceName.ListAsync("central", cancellationToken);
// Core returns every match because this operation uses CitySearchModel.All.
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [ListAsync](method-listasync-59.md) | Builds `CitySearchModel.All` with the supplied parent-province name, lists through the Core city repository, and converts every matching tracked entity to a `CityDto`. The result is page-shaped but unpaged. |

