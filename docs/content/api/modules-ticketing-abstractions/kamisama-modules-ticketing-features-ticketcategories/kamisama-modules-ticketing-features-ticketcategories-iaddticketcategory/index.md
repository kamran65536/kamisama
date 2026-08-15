# IAddTicketCategory

<a id="iaddticketcategory"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Abstractions/Features/TicketCategories/Features.cs:14](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/TicketCategories/Features.cs#L14)

Namespace: `KamiSama.Modules.Ticketing.Features.TicketCategories`

Kind: `Interface`

## Description

Creates a ticket category and returns its persisted representation. Core rejects an existing case-insensitive name before insertion.

## Declaration

```csharp
public interface IAddTicketCategory : IAddFeature<AddTicketCategoryRequest, TicketCategoryDto>;
```

## Example

```csharp
TicketCategoryDto category = await addCategory.AddAsync(
    new AddTicketCategoryRequest("Billing"), cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

