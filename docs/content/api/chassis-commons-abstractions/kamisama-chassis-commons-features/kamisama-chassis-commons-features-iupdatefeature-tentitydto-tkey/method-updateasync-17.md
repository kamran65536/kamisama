# UpdateAsync

[Back to IUpdateFeature<TEntityDto, TKey>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons.Abstractions](../../index.md)

Source: [src/Chassis.Commons.Abstractions/Features/IUpdateFeature.cs:17](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons.Abstractions/Features/IUpdateFeature.cs#L17)

Type: `KamiSama.Chassis.Commons.Features.IUpdateFeature<TEntityDto, TKey>`

Kind: `Method`

## Description

Applies the supplied values to the entity identified by the key. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
Task UpdateAsync(TKey key, TEntityDto dto, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `key` | `TKey` | `-` | The key of the entity to update. |
| `dto` | `TEntityDto` | `-` | The values to apply. |
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

