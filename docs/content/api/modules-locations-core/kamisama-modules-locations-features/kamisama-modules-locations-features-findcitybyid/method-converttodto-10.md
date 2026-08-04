# ConvertToDto

[Back to FindCityById](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Locations.Core](../../index.md)

Source: [src/KamiSama.Modules.Locations.Core/Features/FindCityById.cs:10](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Core/Features/FindCityById.cs#L10)

Type: `KamiSama.Modules.Locations.Features.FindCityById`

Kind: `Method`

## Description

Runs the `ConvertToDto` operation on `FindCityById`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
protected override Task<CityDto> ConvertToDto(City entity, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `entity` | `City` | `-` | The `entity` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<CityDto>` | Returns a `Task<CityDto>` value. |

## Example

No concise standalone example is available yet.

