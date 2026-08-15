# ListAsync

[Back to IListCitiesByProvinceName](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Locations.Abstractions](../../index.md)

Source: [src/KamiSama.Modules.Locations.Abstractions/Features/Features.cs:59](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Abstractions/Features/Features.cs#L59)

Type: `KamiSama.Modules.Locations.Features.IListCitiesByProvinceName`

Kind: `Method`

## Description

Builds `CitySearchModel.All` with the supplied parent-province name, lists through the Core city repository, and converts every matching tracked entity to a `CityDto`. The result is page-shaped but unpaged.

## Declaration

```csharp
Task<PagedResult<CityDto>> ListAsync(string provinceName, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `provinceName` | `string` | `-` | The province-name substring to match. |
| `cancellationToken` | `CancellationToken` | `-` | A token that can cancel the database query. |

## Returns

| Type | Description |
| --- | --- |
| `Task<PagedResult<CityDto>>` | A page-shaped result containing all matching city DTOs because the implementation starts from `CitySearchModel.All`. |

## Example

```csharp
PagedResult<CityDto> cities = await listCitiesByProvinceName.ListAsync("central", cancellationToken);
```

