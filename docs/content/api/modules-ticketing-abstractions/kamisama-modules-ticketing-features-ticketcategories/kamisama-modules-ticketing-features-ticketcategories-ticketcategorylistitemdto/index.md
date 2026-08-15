# TicketCategoryListItemDto

<a id="ticketcategorylistitemdto"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Abstractions/Features/TicketCategories/Dtos.cs:27](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/TicketCategories/Dtos.cs#L27)

Namespace: `KamiSama.Modules.Ticketing.Features.TicketCategories`

Kind: `Record`

## Description

Carries the category fields returned in ticket-category list results and nested ticket data. It contains no ticket collection.

## Declaration

```csharp
public record TicketCategoryListItemDto(Guid Id, string Name, DateTime CreatedAt, DateTime UpdatedAt);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/TicketCategories/Dtos.cs#L27)

Carries the category fields returned in ticket-category list results and nested ticket data. It contains no ticket collection.

```csharp
public record TicketCategoryListItemDto(Guid Id, string Name, DateTime CreatedAt, DateTime UpdatedAt);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `Id` | `Guid` | `-` | The category identifier. |
| `Name` | `string` | `-` | The category name. |
| `CreatedAt` | `DateTime` | `-` | The category creation timestamp. |
| `UpdatedAt` | `DateTime` | `-` | The category&apos;s latest update timestamp. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

