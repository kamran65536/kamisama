# All

[Back to TicketCategorySearchModel](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Abstractions](../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Abstractions/Features/TicketCategories/Dtos.cs:17](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/TicketCategories/Dtos.cs#L17)

Type: `KamiSama.Modules.Ticketing.Features.TicketCategories.TicketCategorySearchModel`

Kind: `Property`

## Description

Gets or sets the shared mutable search model requesting all categories without a name or ordering filter. Replace it only when application-wide callers intentionally need different all-results defaults.

## Declaration

```csharp
public static new TicketCategorySearchModel All { get; set; } = new(default, default, default, default);
```

## Value

| Detail | Description |
| --- | --- |
| `Property` | Gets or sets a `TicketCategorySearchModel` value. |

## Example

No concise standalone example is available yet.

