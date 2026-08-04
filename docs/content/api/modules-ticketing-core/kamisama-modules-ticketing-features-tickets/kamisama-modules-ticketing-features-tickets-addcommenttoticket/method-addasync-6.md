# AddAsync

[Back to AddCommentToTicket](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Core](../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Core/Features/Tickets/AddCommentToTicket.cs:6](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Core/Features/Tickets/AddCommentToTicket.cs#L6)

Type: `KamiSama.Modules.Ticketing.Features.Tickets.AddCommentToTicket`

Kind: `Method`

## Description

Runs the `AddAsync` operation on `AddCommentToTicket`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
public async Task<TicketDto> AddAsync(AddTicketCommentRequest request, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `request` | `AddTicketCommentRequest` | `-` | The `request` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<TicketDto>` | Returns a `Task<TicketDto>` value. |

## Example

```csharp
var sample = new SampleEntity { Id = 1, Name = "sample" };
var repository = new InMemoryRepository<SampleEntity>();

await repository.AddAsync(sample, CancellationToken.None);
```

