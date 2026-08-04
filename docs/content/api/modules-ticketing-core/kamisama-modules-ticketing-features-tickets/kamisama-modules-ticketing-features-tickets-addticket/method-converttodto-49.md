# ConvertToDto

[Back to AddTicket](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Core](../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Core/Features/Tickets/AddTicket.cs:49](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Core/Features/Tickets/AddTicket.cs#L49)

Type: `KamiSama.Modules.Ticketing.Features.Tickets.AddTicket`

Kind: `Method`

## Description

Runs the `ConvertToDto` operation on `AddTicket`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
protected override Task<TicketDto> ConvertToDto(Ticket entity, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `entity` | `Ticket` | `-` | The `entity` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<TicketDto>` | Returns a `Task<TicketDto>` value. |

## Example

No concise standalone example is available yet.

