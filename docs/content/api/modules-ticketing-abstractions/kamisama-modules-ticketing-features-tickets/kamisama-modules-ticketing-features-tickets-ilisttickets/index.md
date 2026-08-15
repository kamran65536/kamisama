# IListTickets

<a id="ilisttickets"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Features.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Features.cs#L9)

Namespace: `KamiSama.Modules.Ticketing.Features.Tickets`

Kind: `Interface`

## Description

Lists a page of tickets using text, author, status, priority, category, and ordering criteria. Implementations are not required to support every optional criterion.

## Declaration

```csharp
public interface IListTickets : IListFeature<TicketListItemDto, TicketSearchModel>;
```

## Example

```csharp
PagedResult<TicketListItemDto> tickets = await listTickets.ListAsync(
    new TicketSearchModel(1, 20, null, null, userId, [TicketStatus.Open], null, "updatedat"),
    cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

