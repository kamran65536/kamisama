# FindTicketCommentByCommentIdAsync

[Back to ITicketRepository](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Core](../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Core/Repositories/Abstractions/ITicketRepository.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Core/Repositories/Abstractions/ITicketRepository.cs#L9)

Type: `KamiSama.Modules.Ticketing.Repositories.Abstractions.ITicketRepository`

Kind: `Method`

## Description

Runs the `FindTicketCommentByCommentIdAsync` operation on `ITicketRepository`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
Task<TicketComment?> FindTicketCommentByCommentIdAsync(Guid commentId, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `commentId` | `Guid` | `-` | The `commentId` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<TicketComment?>` | Returns a `Task<TicketComment?>` value. |

## Example

No concise standalone example is available yet.

