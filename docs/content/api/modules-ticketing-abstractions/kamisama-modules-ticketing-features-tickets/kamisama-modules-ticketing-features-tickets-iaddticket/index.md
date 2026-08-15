# IAddTicket

<a id="iaddticket"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Features.cs:14](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/Tickets/Features.cs#L14)

Namespace: `KamiSama.Modules.Ticketing.Features.Tickets`

Kind: `Interface`

## Description

Creates a ticket with an initial user comment and optional attachment content identifiers. Implementations determine identifier generation and persistence behavior.

## Declaration

```csharp
public interface IAddTicket : IAddFeature<AddTicketRequest, TicketDto>;
```

## Example

```csharp
TicketDto ticket = await addTicket.AddAsync(new AddTicketRequest(
    userId, "Cannot sign in", categoryId, "The login form rejects my password.",
    TicketPriority.High, []), cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

