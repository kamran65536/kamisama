# ListAsync

[Back to IListCitiesByProvinceName](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Locations.Abstractions](../../index.md)

Source: [src/KamiSama.Modules.Locations.Abstractions/Features/Features.cs:20](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Abstractions/Features/Features.cs#L20)

Type: `KamiSama.Modules.Locations.Features.IListCitiesByProvinceName`

Kind: `Method`

## Description

Runs the `ListAsync` operation on `IListCitiesByProvinceName`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
Task<PagedResult<CityDto>> ListAsync(string provinceName, CancellationToken cancellationToken);
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

