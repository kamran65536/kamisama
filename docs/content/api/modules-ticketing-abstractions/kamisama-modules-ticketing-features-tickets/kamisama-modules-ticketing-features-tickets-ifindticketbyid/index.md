# IFindTicketById

<a id="ifindticketbyid"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Features.cs:25](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Features.cs#L25)

Namespace: `KamiSama.Modules.Ticketing.Features.Tickets`

Kind: `Interface`

## Description

Finds a ticket and its category, comments, and attachments by identifier. Implementations determine missing-ticket and loading behavior.

## Declaration

```csharp
public interface IFindTicketById : IFindByIdFeature<TicketDto, Guid>;
```

## Example

```csharp
TicketDto ticket = await findTicket.FindByIdAsync(ticketId, cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

