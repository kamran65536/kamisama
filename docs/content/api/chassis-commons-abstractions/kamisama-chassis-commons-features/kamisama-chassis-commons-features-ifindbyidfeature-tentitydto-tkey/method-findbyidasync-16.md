# FindByIdAsync

[Back to IFindByIdFeature<TEntityDto, TKey>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons.Abstractions](../../index.md)

Source: [src/Chassis.Commons.Abstractions/Features/IFindByIdFeature.cs:16](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons.Abstractions/Features/IFindByIdFeature.cs#L16)

Type: `KamiSama.Chassis.Commons.Features.IFindByIdFeature<TEntityDto, TKey>`

Kind: `Method`

## Description

Finds an entity by identifier and returns its &lt;typeparamref name=&quot;TEntityDto&quot;/&gt; representation. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
Task<TEntityDto> FindByIdAsync(TKey id, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `id` | `TKey` | `-` | The identifier to find. |
| `cancellationToken` | `CancellationToken` | `-` | A token that can cancel the operation. |

## Returns

| Type | Description |
| --- | --- |
| `Task<TEntityDto>` | The DTO for the matching entity. |

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

