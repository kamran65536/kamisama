# ConvertToDto

[Back to ListTickets](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Core](../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Core/Features/Tickets/ListTickets.cs:8](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Core/Features/Tickets/ListTickets.cs#L8)

Type: `KamiSama.Modules.Ticketing.Features.Tickets.ListTickets`

Kind: `Method`

## Description

Runs the `ConvertToDto` operation on `ListTickets`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
protected override Task<TicketListItemDto> ConvertToDto(Ticket entity, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `entity` | `Ticket` | `-` | The `entity` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<TicketListItemDto>` | Returns a `Task<TicketListItemDto>` value. |

## Example

No concise standalone example is available yet.

