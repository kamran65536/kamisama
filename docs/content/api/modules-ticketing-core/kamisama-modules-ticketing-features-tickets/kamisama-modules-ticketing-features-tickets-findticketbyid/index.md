# FindTicketById

<a id="findticketbyid"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Core/Features/Tickets/FindTicketById.cs:3](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Core/Features/Tickets/FindTicketById.cs#L3)

Namespace: `KamiSama.Modules.Ticketing.Features.Tickets`

Kind: `Class`

## Description

Provides the `FindTicketById` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
internal class FindTicketById(ITicketRepository repository) :
    GenericFindByIdFeature<Ticket, TicketDto, ITicketRepository, Guid>(repository),
    IFindTicketById
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Core/Features/Tickets/FindTicketById.cs#L3)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
internal class FindTicketById(ITicketRepository repository) :
    GenericFindByIdFeature<Ticket, TicketDto, ITicketRepository, Guid>(repository),
    IFindTicketById
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `repository` | `ITicketRepository` | `-` | The `repository` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [ConvertToDto](method-converttodto-8.md) | Runs the `ConvertToDto` operation on `FindTicketById`. Use it when your code needs this specific behavior from the package. |

