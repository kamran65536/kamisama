# ApplySearchModel

[Back to TicketRepository](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Core](../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Core/Repositories/Implementations/TicketRepository.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Core/Repositories/Implementations/TicketRepository.cs#L9)

Type: `KamiSama.Modules.Ticketing.Repositories.Implementations.TicketRepository`

Kind: `Method`

## Description

Runs the `ApplySearchModel` operation on `TicketRepository`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
protected override IQueryable<Ticket> ApplySearchModel(IQueryable<Ticket> query, TicketSearchModel searchModel);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `query` | `IQueryable<Ticket>` | `-` | The `query` value passed to this member. |
| `searchModel` | `TicketSearchModel` | `-` | The `searchModel` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `IQueryable<Ticket>` | Returns a `IQueryable<Ticket>` value. |

## Example

No concise standalone example is available yet.

