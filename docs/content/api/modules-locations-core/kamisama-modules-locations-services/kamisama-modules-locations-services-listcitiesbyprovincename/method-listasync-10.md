# ListAsync

[Back to ListCitiesByProvinceName](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Locations.Core](../../index.md)

Source: [src/KamiSama.Modules.Locations.Core/Services/ListCitiesByProvinceName.cs:10](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Core/Services/ListCitiesByProvinceName.cs#L10)

Type: `KamiSama.Modules.Locations.Services.ListCitiesByProvinceName`

Kind: `Method`

## Description

Runs the `ListAsync` operation on `ListCitiesByProvinceName`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
public async Task<PagedResult<CityDto>> ListAsync(string provinceName, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `provinceName` | `string` | `-` | The `provinceName` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<PagedResult<CityDto>>` | Returns a `Task<PagedResult<CityDto>>` value. |

## Example

No concise standalone example is available yet.

