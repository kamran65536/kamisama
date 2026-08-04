# UpdateTicketStateRequest

<a id="updateticketstaterequest"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Dtos.cs:15](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Dtos.cs#L15)

Namespace: `KamiSama.Modules.Ticketing.Features.Tickets`

Kind: `Record`

## Description

Provides the `UpdateTicketStateRequest` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
public record UpdateTicketStateRequest(string Title, TicketStatus Status, TicketPriority Priority);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Dtos.cs#L15)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
public record UpdateTicketStateRequest(string Title, TicketStatus Status, TicketPriority Priority);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `Title` | `string` | `-` | The `Title` value passed to this member. |
| `Status` | `TicketStatus` | `-` | The `Status` value passed to this member. |
| `Priority` | `TicketPriority` | `-` | The `Priority` value passed to this member. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

