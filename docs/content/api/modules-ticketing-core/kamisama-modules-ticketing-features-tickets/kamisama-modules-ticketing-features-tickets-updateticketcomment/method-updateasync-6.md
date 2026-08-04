# UpdateAsync

[Back to UpdateTicketComment](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Core](../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Core/Features/Tickets/UpdateTicketComment.cs:6](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Core/Features/Tickets/UpdateTicketComment.cs#L6)

Type: `KamiSama.Modules.Ticketing.Features.Tickets.UpdateTicketComment`

Kind: `Method`

## Description

Runs the `UpdateAsync` operation on `UpdateTicketComment`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
public async Task UpdateAsync(Guid key, UpdateTicketCommentRequest request, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `key` | `Guid` | `-` | The `key` value passed to this member. |
| `request` | `UpdateTicketCommentRequest` | `-` | The `request` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | Returns a `Task` value. |

## Example

```csharp
var sample = new SampleEntity { Id = 1, Name = "sample" };
var repository = new InMemoryRepository<SampleEntity>([sample]);

sample.Name = "sample2";

await repository.UpdateAsync(sample, CancellationToken.None);

var retrieved = repository.Find(x => x.Name == "sample2");
```

