# FindTicketAttachmentByAttachmentIdAsync

[Back to TicketRepository](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Core](../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Core/Repositories/Implementations/TicketRepository.cs:39](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Core/Repositories/Implementations/TicketRepository.cs#L39)

Type: `KamiSama.Modules.Ticketing.Repositories.Implementations.TicketRepository`

Kind: `Method`

## Description

Runs the `FindTicketAttachmentByAttachmentIdAsync` operation on `TicketRepository`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
public Task<TicketAttachment?> FindTicketAttachmentByAttachmentIdAsync(Guid attachmentId, CancellationToken cancellationToken);
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

