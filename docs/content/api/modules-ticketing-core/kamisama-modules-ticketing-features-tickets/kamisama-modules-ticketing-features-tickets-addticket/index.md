# AddTicket

<a id="addticket"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Core/Features/Tickets/AddTicket.cs:3](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Core/Features/Tickets/AddTicket.cs#L3)

Namespace: `KamiSama.Modules.Ticketing.Features.Tickets`

Kind: `Class`

## Description

Provides the `AddTicket` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
internal class AddTicket(ITicketRepository repository, ITicketCategoryRepository ticketCategoryRepository) : 
    GenericAddFeature<AddTicketRequest, ITicketRepository, Ticket, TicketDto>(repository),
    IAddTicket
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Core/Features/Tickets/AddTicket.cs#L3)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
internal class AddTicket(ITicketRepository repository, ITicketCategoryRepository ticketCategoryRepository) : 
    GenericAddFeature<AddTicketRequest, ITicketRepository, Ticket, TicketDto>(repository),
    IAddTicket
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `repository` | `ITicketRepository` | `-` | The `repository` value passed to this member. |
| `ticketCategoryRepository` | `ITicketCategoryRepository` | `-` | The `ticketCategoryRepository` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [ConvertToDto](method-converttodto-49.md) | Runs the `ConvertToDto` operation on `AddTicket`. Use it when your code needs this specific behavior from the package. |
| [ConvertToEntity](method-converttoentity-8.md) | Runs the `ConvertToEntity` operation on `AddTicket`. Use it when your code needs this specific behavior from the package. |

