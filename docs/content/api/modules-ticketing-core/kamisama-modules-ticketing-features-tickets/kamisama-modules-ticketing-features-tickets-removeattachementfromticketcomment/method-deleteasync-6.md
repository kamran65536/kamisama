# DeleteAsync

[Back to RemoveAttachementFromTicketComment](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Core](../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Core/Features/Tickets/RemoveAttachementFromTicketComment.cs:6](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Core/Features/Tickets/RemoveAttachementFromTicketComment.cs#L6)

Type: `KamiSama.Modules.Ticketing.Features.Tickets.RemoveAttachementFromTicketComment`

Kind: `Method`

## Description

Runs the `DeleteAsync` operation on `RemoveAttachementFromTicketComment`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
public async Task DeleteAsync(Guid attachmentId, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `attachmentId` | `Guid` | `-` | The `attachmentId` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | Returns a `Task` value. |

## Example

```csharp
var entity = new SampleEntity { Id = 1, Name = "Test" };
var context = GetDbContext(initialDbSet: [entity]);

var repository = new DbRepository<SampleEntity>(context);

await repository.DeleteAsync(entity, CancellationToken.None);
```

