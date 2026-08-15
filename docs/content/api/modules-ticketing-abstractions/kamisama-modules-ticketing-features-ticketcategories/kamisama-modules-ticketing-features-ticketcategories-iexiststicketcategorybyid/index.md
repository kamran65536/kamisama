# IExistsTicketCategoryById

<a id="iexiststicketcategorybyid"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Abstractions/Features/TicketCategories/Features.cs:39](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/TicketCategories/Features.cs#L39)

Namespace: `KamiSama.Modules.Ticketing.Features.TicketCategories`

Kind: `Interface`

## Description

Tests whether a ticket category exists for a `Guid` identifier. Implementations define the underlying lookup behavior.

## Declaration

```csharp
public interface IExistsTicketCategoryById : IExistsByIdFeature<Guid>;
```

## Example

```csharp
bool exists = await categoryExists.ExistsByIdAsync(categoryId, cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

