# All

[Back to TicketSearchModel](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Abstractions](../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Dtos.cs:7](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Dtos.cs#L7)

Type: `KamiSama.Modules.Ticketing.Features.Tickets.TicketSearchModel`

Kind: `Property`

## Description

Exposes the `All` value on `TicketSearchModel`. Read or set it as part of configuring or using the type.

## Declaration

```csharp
public static new TicketSearchModel All { get; set; } = new(default, default, default, default, default, default, default, default);
```

## Value

| Detail | Description |
| --- | --- |
| `Property` | Gets or sets a `TicketSearchModel` value. |

## Example

```csharp
using KamiSama.Extensions.Paging;

var search = SearchModel.All;
```

