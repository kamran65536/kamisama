# ConvertToEntity

[Back to AddTicket](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Core](../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Core/Features/Tickets/AddTicket.cs:8](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Core/Features/Tickets/AddTicket.cs#L8)

Type: `KamiSama.Modules.Ticketing.Features.Tickets.AddTicket`

Kind: `Method`

## Description

Runs the `ConvertToEntity` operation on `AddTicket`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
protected override async Task<Ticket> ConvertToEntity(AddTicketRequest request, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `request` | `AddTicketRequest` | `-` | The `request` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<Ticket>` | Returns a `Task<Ticket>` value. |

## Example

No concise standalone example is available yet.

