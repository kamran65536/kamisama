# IFindTicketCategoryById

<a id="ifindticketcategorybyid"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Abstractions/Features/TicketCategories/Features.cs:29](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/TicketCategories/Features.cs#L29)

Namespace: `KamiSama.Modules.Ticketing.Features.TicketCategories`

Kind: `Interface`

## Description

Finds a ticket category by its `Guid` identifier. Implementations determine missing-category behavior.

## Declaration

```csharp
public interface IFindTicketCategoryById : IFindByIdFeature<TicketCategoryDto, Guid>;
```

## Example

```csharp
TicketCategoryDto category = await findCategory.FindByIdAsync(categoryId, cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

