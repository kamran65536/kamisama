# TicketCategoryDto

<a id="ticketcategorydto"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Abstractions/Features/TicketCategories/Dtos.cs:36](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/TicketCategories/Dtos.cs#L36)

Namespace: `KamiSama.Modules.Ticketing.Features.TicketCategories`

Kind: `Record`

## Description

Carries the complete public representation of a ticket category. The current shape is the same as the list-item representation.

## Declaration

```csharp
public record TicketCategoryDto(Guid Id, string Name, DateTime CreatedAt, DateTime UpdatedAt);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/TicketCategories/Dtos.cs#L36)

Carries the complete public representation of a ticket category. The current shape is the same as the list-item representation.

```csharp
public record TicketCategoryDto(Guid Id, string Name, DateTime CreatedAt, DateTime UpdatedAt);
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

