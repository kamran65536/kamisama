# ConvertToDto

[Back to FindProvinceById](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Locations.Core](../../index.md)

Source: [src/KamiSama.Modules.Locations.Core/Features/FindProvinceById.cs:10](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Core/Features/FindProvinceById.cs#L10)

Type: `KamiSama.Modules.Locations.Features.FindProvinceById`

Kind: `Method`

## Description

Runs the `ConvertToDto` operation on `FindProvinceById`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
protected override Task<ProvinceDto> ConvertToDto(Province entity, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `entity` | `Province` | `-` | The `entity` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<ProvinceDto>` | Returns a `Task<ProvinceDto>` value. |

## Example

No concise standalone example is available yet.

