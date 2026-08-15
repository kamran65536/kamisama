# IListTicketCategories

<a id="ilistticketcategories"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Abstractions/Features/TicketCategories/Features.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/TicketCategories/Features.cs#L9)

Namespace: `KamiSama.Modules.Ticketing.Features.TicketCategories`

Kind: `Interface`

## Description

Lists a page of ticket categories matching name and ordering criteria. Implementations define persistence and exact filtering semantics.

## Declaration

```csharp
public interface IListTicketCategories : IListFeature<TicketCategoryListItemDto, TicketCategorySearchModel>;
```

## Example

```csharp
PagedResult<TicketCategoryListItemDto> categories = await listCategories.ListAsync(
    new TicketCategorySearchModel(1, 20, null, "name"), cancellationToken);
// Current Core registration for this specialized contract is non-assignable.
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

