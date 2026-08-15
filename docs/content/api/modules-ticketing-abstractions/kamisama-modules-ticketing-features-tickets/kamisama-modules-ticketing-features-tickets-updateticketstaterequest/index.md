# UpdateTicketStateRequest

<a id="updateticketstaterequest"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Dtos.cs:97](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Dtos.cs#L97)

Namespace: `KamiSama.Modules.Ticketing.Features.Tickets`

Kind: `Record`

## Description

Carries replacement title, status, and priority values. Core accepts unchanged status, open or reopened to resolved, and resolved to reopened or closed; every other transition produces an HTTP 409 conflict.

## Declaration

```csharp
public record UpdateTicketStateRequest(string Title, TicketStatus Status, TicketPriority Priority);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Dtos.cs#L97)

Supplies replacement title, status, and priority values for a ticket update. Core permits unchanged status, open or reopened to resolved, and resolved to reopened or closed; it rejects every other transition.

```csharp
public record UpdateTicketStateRequest(string Title, TicketStatus Status, TicketPriority Priority);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `Title` | `string` | `-` | The replacement ticket title. |
| `Status` | `TicketStatus` | `-` | The replacement workflow status, which must be reachable from the ticket&apos;s current status. |
| `Priority` | `TicketPriority` | `-` | The replacement urgency. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

