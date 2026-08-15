# UpdateAsync

[Back to IUpdatableRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons.Abstractions](../../index.md)

Source: [src/Chassis.Commons.Abstractions/Repositories/IUpdatableRepository.cs:15](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons.Abstractions/Repositories/IUpdatableRepository.cs#L15)

Type: `KamiSama.Chassis.Commons.Repositories.IUpdatableRepository<TEntity>`

Kind: `Method`

## Description

Updates an entity in the underlying store. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `entity` | `TEntity` | `-` | The entity containing updated values. |
| `cancellationToken` | `CancellationToken` | `-` | A token that can cancel the operation. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | A task that represents the asynchronous update. |

## Example

```csharp
ITicketRepository repository = Substitute.For<ITicketRepository>();
Ticket ticket = CreateTicket(TicketStatus.Open);
repository.FindByIdAsync(ticket.Id, Arg.Any<CancellationToken>()).Returns(ticket);
var feature = new UpdateTicketState(repository);

await feature.UpdateAsync(
ticket.Id,
new UpdateTicketStateRequest("Changed", TicketStatus.Resolved, TicketPriority.High),
CancellationToken.None);

await repository.Received(1).UpdateAsync(ticket, Arg.Any<CancellationToken>());
```

