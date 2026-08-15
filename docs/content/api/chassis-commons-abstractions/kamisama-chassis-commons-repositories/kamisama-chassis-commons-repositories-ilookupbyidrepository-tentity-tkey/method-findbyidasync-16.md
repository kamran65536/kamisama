# FindByIdAsync

[Back to ILookupByIdRepository<TEntity, TKey>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons.Abstractions](../../index.md)

Source: [src/Chassis.Commons.Abstractions/Repositories/ILookupByIdReposiotry.cs:16](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons.Abstractions/Repositories/ILookupByIdReposiotry.cs#L16)

Type: `KamiSama.Chassis.Commons.Repositories.ILookupByIdRepository<TEntity, TKey>`

Kind: `Method`

## Description

Finds an entity by identifier. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
Task<TEntity?> FindByIdAsync(TKey id, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `id` | `TKey` | `-` | The identifier to find. |
| `cancellationToken` | `CancellationToken` | `-` | A token that can cancel the operation. |

## Returns

| Type | Description |
| --- | --- |
| `Task<TEntity?>` | The matching entity, or when none exists. |

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

