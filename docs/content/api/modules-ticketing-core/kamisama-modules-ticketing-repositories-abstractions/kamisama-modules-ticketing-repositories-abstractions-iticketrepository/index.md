# ITicketRepository

<a id="iticketrepository"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Core/Repositories/Abstractions/ITicketRepository.cs:5](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Core/Repositories/Abstractions/ITicketRepository.cs#L5)

Namespace: `KamiSama.Modules.Ticketing.Repositories.Abstractions`

Kind: `Interface`

## Description

Repository implementation or contract for `ITicketRepository`. Use it behind feature services to keep persistence access behind the KamiSama repository abstraction.

## Declaration

```csharp
internal interface ITicketRepository : 
    IGenericRepository<Ticket, TicketSearchModel>,
    ILookupByIdRepository<Ticket, Guid>
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [FindTicketAttachmentByAttachmentIdAsync](method-findticketattachmentbyattachmentidasync-10.md) | Runs the `FindTicketAttachmentByAttachmentIdAsync` operation on `ITicketRepository`. Use it when your code needs this specific behavior from the package. |
| [FindTicketCommentByCommentIdAsync](method-findticketcommentbycommentidasync-9.md) | Runs the `FindTicketCommentByCommentIdAsync` operation on `ITicketRepository`. Use it when your code needs this specific behavior from the package. |

