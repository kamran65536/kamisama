# TicketRepository

<a id="ticketrepository"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Core/Repositories/Implementations/TicketRepository.cs:6](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Core/Repositories/Implementations/TicketRepository.cs#L6)

Namespace: `KamiSama.Modules.Ticketing.Repositories.Implementations`

Kind: `Class`

## Description

Repository implementation or contract for `TicketRepository`. Use it behind feature services to keep persistence access behind the KamiSama repository abstraction.

## Declaration

```csharp
internal class TicketRepository(TicketingDbContext context) : GenericRepository<Ticket, TicketSearchModel, TicketingDbContext>(context), ITicketRepository
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Core/Repositories/Implementations/TicketRepository.cs#L6)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
internal class TicketRepository(TicketingDbContext context) : GenericRepository<Ticket, TicketSearchModel, TicketingDbContext>(context), ITicketRepository
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `context` | `TicketingDbContext` | `-` | The `context` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [ApplySearchModel](method-applysearchmodel-9.md) | Runs the `ApplySearchModel` operation on `TicketRepository`. Use it when your code needs this specific behavior from the package. |
| [ExistsByIdAsync](method-existsbyidasync-35.md) | Runs the `ExistsByIdAsync` operation on `TicketRepository`. Use it when your code needs this specific behavior from the package. |
| [FindByIdAsync](method-findbyidasync-33.md) | Runs the `FindByIdAsync` operation on `TicketRepository`. Use it when your code needs this specific behavior from the package. |
| [FindTicketAttachmentByAttachmentIdAsync](method-findticketattachmentbyattachmentidasync-39.md) | Runs the `FindTicketAttachmentByAttachmentIdAsync` operation on `TicketRepository`. Use it when your code needs this specific behavior from the package. |
| [FindTicketCommentByCommentIdAsync](method-findticketcommentbycommentidasync-37.md) | Runs the `FindTicketCommentByCommentIdAsync` operation on `TicketRepository`. Use it when your code needs this specific behavior from the package. |

