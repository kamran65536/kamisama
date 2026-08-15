# All

[Back to CitySearchModel](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Locations.Abstractions](../../index.md)

Source: [src/KamiSama.Modules.Locations.Abstractions/Features/Dtos.cs:37](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Abstractions/Features/Dtos.cs#L37)

Type: `KamiSama.Modules.Locations.Features.CitySearchModel`

Kind: `Property`

## Description

Gets an unpaged search model without province or city filters. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static new CitySearchModel All { get; } = new(default, default, default, default, default, default);
```

## Value

| Detail | Description |
| --- | --- |
| `Property` | A reusable model whose paging, filters, and ordering token are all defaults. |

## Example

No concise standalone example is available yet.

