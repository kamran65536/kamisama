# IDeleteTicketCategory

<a id="ideleteticketcategory"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Abstractions/Features/TicketCategories/Features.cs:24](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/TicketCategories/Features.cs#L24)

Namespace: `KamiSama.Modules.Ticketing.Features.TicketCategories`

Kind: `Interface`

## Description

Deletes a ticket category identified by a `Guid`. Implementations determine relationship and missing-category behavior.

## Declaration

```csharp
public interface IDeleteTicketCategory : IDeleteFeature<Guid>;
```

## Example

```csharp
await deleteCategory.DeleteAsync(categoryId, cancellationToken);
// Current Core registration for this specialized contract is non-assignable.
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

