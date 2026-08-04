# FindByIdAsync

[Back to TicketRepository](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Core](../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Core/Repositories/Implementations/TicketRepository.cs:33](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Core/Repositories/Implementations/TicketRepository.cs#L33)

Type: `KamiSama.Modules.Ticketing.Repositories.Implementations.TicketRepository`

Kind: `Method`

## Description

Runs the `FindByIdAsync` operation on `TicketRepository`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
public Task<Ticket?> FindByIdAsync(Guid id, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `id` | `Guid` | `-` | The `id` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<Ticket?>` | Returns a `Task<Ticket?>` value. |

## Example

No concise standalone example is available yet.

