# Ticket

<a id="ticket"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Core/Entities/Ticket.cs:7](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Core/Entities/Ticket.cs#L7)

Namespace: `KamiSama.Modules.Ticketing.Entities`

Kind: `Class`

## Description

EF Core ticket aggregate root with a required category, comments, attachment references, workflow state, priority, author, and timestamps. `CanTransitionTo` exposes Core's transition table, while `IsEditable` identifies open and reopened tickets.

## Declaration

```csharp
public class Ticket
```

## Example

```csharp
bool mayResolve = ticket.CanTransitionTo(TicketStatus.Resolved);
bool mayEdit = ticket.IsEditable();
// Endpoint policy must still authorize the caller before a mutation.
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [CanTransitionTo](method-cantransitionto-41.md) | Returns whether the requested status is unchanged or follows Core's workflow table: open or reopened to resolved, or resolved to reopened or closed. Undefined enum values and every other transition return `false`. |
| [IsEditable](method-iseditable-33.md) | Determines whether the current status permits editing under the entity&apos;s workflow rule. Current feature services do not consistently invoke this rule before mutations. |

### Properties

| Member | Description |
| --- | --- |
| [AuthorUserId](property-authoruserid-15.md) | Gets or sets the identifier of the user who opened the ticket. Use it with the surrounding package APIs when composing application code. |
| [Category](property-category-25.md) | Gets or sets the required category navigation. Use it with the surrounding package APIs when composing application code. |
| [Comments](property-comments-27.md) | Gets or sets the comments belonging to the ticket. Use it with the surrounding package APIs when composing application code. |
| [CreatedAt](property-createdat-21.md) | Gets or sets the ticket creation timestamp. Use it with the surrounding package APIs when composing application code. |
| [Id](property-id-10.md) | Gets or sets the ticket identifier. Use it with the surrounding package APIs when composing application code. |
| [Priority](property-priority-19.md) | Gets or sets the current urgency. Use it with the surrounding package APIs when composing application code. |
| [Status](property-status-17.md) | Gets or sets the current workflow status. Use it with the surrounding package APIs when composing application code. |
| [Title](property-title-12.md) | Gets or sets the required ticket title, limited to 100 characters by the EF Core model. Use it with the surrounding package APIs when composing application code. |
| [UpdatedAt](property-updatedat-23.md) | Gets or sets the latest ticket update timestamp. Use it with the surrounding package APIs when composing application code. |

