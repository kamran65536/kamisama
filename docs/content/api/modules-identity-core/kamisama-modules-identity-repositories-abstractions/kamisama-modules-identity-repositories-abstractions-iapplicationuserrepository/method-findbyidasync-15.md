# FindByIdAsync

[Back to IApplicationUserRepository](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Repositories/Abstractions/IApplicationUserRepository.cs:15](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Repositories/Abstractions/IApplicationUserRepository.cs#L15)

Type: `KamiSama.Modules.Identity.Repositories.Abstractions.IApplicationUserRepository`

Kind: `Method`

## Description

Finds a user by identifier. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
Task<ApplicationUser?> FindByIdAsync(Guid Id, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `Id` | `Guid` | `-` | The user identifier. |
| `cancellationToken` | `CancellationToken` | `-` | A token that requests cancellation. |

## Returns

| Type | Description |
| --- | --- |
| `Task<ApplicationUser?>` | The matching user, or . |

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

