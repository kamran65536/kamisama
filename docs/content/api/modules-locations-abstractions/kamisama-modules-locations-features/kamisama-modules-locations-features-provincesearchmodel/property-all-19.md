# All

[Back to ProvinceSearchModel](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Locations.Abstractions](../../index.md)

Source: [src/KamiSama.Modules.Locations.Abstractions/Features/Dtos.cs:19](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Abstractions/Features/Dtos.cs#L19)

Type: `KamiSama.Modules.Locations.Features.ProvinceSearchModel`

Kind: `Property`

## Description

Gets an unpaged search model without name filtering or an ordering token. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static new ProvinceSearchModel All { get; } = new(default, default, default, default);
```

## Value

| Detail | Description |
| --- | --- |
| `Property` | A reusable model whose paging and optional filter values are all defaults. |

## Example

No concise standalone example is available yet.

