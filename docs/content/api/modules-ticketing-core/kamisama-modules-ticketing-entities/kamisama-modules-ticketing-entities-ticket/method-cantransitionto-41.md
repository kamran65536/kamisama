# CanTransitionTo

[Back to Ticket](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Core](../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Core/Entities/Ticket.cs:41](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Core/Entities/Ticket.cs#L41)

Type: `KamiSama.Modules.Ticketing.Entities.Ticket`

Kind: `Method`

## Description

Returns whether the requested status is unchanged or follows Core's workflow table: open or reopened to resolved, or resolved to reopened or closed. Undefined enum values and every other transition return `false`.

## Declaration

```csharp
public bool CanTransitionTo(TicketStatus targetStatus);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `targetStatus` | `TicketStatus` | `-` | The status requested for the ticket. |

## Returns

| Type | Description |
| --- | --- |
| `bool` | True when the status is unchanged or the requested transition is allowed; otherwise false. |

## Example

```csharp
bool mayResolve = ticket.CanTransitionTo(TicketStatus.Resolved);
```

