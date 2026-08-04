# FindTicketAttachmentByAttachmentIdAsync

[Back to ITicketRepository](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Core](../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Core/Repositories/Abstractions/ITicketRepository.cs:10](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Core/Repositories/Abstractions/ITicketRepository.cs#L10)

Type: `KamiSama.Modules.Ticketing.Repositories.Abstractions.ITicketRepository`

Kind: `Method`

## Description

Runs the `FindTicketAttachmentByAttachmentIdAsync` operation on `ITicketRepository`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
Task<TicketAttachment?> FindTicketAttachmentByAttachmentIdAsync(Guid attachmentId, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `attachmentId` | `Guid` | `-` | The `attachmentId` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<TicketAttachment?>` | Returns a `Task<TicketAttachment?>` value. |

## Example

No concise standalone example is available yet.

