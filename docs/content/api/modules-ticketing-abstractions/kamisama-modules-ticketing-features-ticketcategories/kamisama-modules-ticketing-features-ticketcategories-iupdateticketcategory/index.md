# IUpdateTicketCategory

<a id="iupdateticketcategory"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Abstractions/Features/TicketCategories/Features.cs:19](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/TicketCategories/Features.cs#L19)

Namespace: `KamiSama.Modules.Ticketing.Features.TicketCategories`

Kind: `Interface`

## Description

Updates a ticket category identified by a `Guid`. Core replaces the name and rejects a case-insensitive name owned by another category.

## Declaration

```csharp
public interface IUpdateTicketCategory : IUpdateFeature<UpdateTicketCategoryRequest, Guid>;
```

## Example

```csharp
await updateCategory.UpdateAsync(categoryId,
    new UpdateTicketCategoryRequest("Accounts"), cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

