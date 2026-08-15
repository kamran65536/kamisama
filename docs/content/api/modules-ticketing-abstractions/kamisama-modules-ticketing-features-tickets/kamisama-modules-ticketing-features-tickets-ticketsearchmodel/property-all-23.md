# All

[Back to TicketSearchModel](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Abstractions](../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Dtos.cs:23](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Dtos.cs#L23)

Type: `KamiSama.Modules.Ticketing.Features.Tickets.TicketSearchModel`

Kind: `Property`

## Description

Gets or sets the shared mutable search model requesting all tickets without filters or explicit ordering. Replace it only when application-wide callers intentionally need different all-results defaults.

## Declaration

```csharp
public static new TicketSearchModel All { get; set; } = new(default, default, default, default, default, default, default, default);
```

## Value

| Detail | Description |
| --- | --- |
| `Property` | Gets or sets a `TicketSearchModel` value. |

## Example

No concise standalone example is available yet.

