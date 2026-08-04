# FindByIdAsync

[Back to TicketCategoryRepository](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Core](../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Core/Repositories/Implementations/TicketCategoryRepository.cs:25](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Core/Repositories/Implementations/TicketCategoryRepository.cs#L25)

Type: `KamiSama.Modules.Ticketing.Repositories.Implementations.TicketCategoryRepository`

Kind: `Method`

## Description

Runs the `FindByIdAsync` operation on `TicketCategoryRepository`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
public Task<TicketCategory?> FindByIdAsync(Guid id, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `id` | `Guid` | `-` | The `id` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<TicketCategory?>` | Returns a `Task<TicketCategory?>` value. |

## Example

No concise standalone example is available yet.

