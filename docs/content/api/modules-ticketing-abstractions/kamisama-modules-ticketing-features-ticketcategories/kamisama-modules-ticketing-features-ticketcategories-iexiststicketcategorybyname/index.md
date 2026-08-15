# IExistsTicketCategoryByName

<a id="iexiststicketcategorybyname"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Abstractions/Features/TicketCategories/Features.cs:44](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/TicketCategories/Features.cs#L44)

Namespace: `KamiSama.Modules.Ticketing.Features.TicketCategories`

Kind: `Interface`

## Description

Tests whether a ticket category exists for a name. Core&apos;s repository performs a case-insensitive exact comparison.

## Declaration

```csharp
public interface IExistsTicketCategoryByName : IExistsByNameFeature;
```

## Example

```csharp
bool exists = await categoryExists.ExistsByNameAsync("Billing", cancellationToken);
// Current Core registration for this specialized contract is non-assignable.
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

