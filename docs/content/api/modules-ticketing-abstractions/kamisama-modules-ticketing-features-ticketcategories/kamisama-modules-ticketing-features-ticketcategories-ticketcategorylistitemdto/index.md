# TicketCategoryListItemDto

<a id="ticketcategorylistitemdto"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Abstractions/Features/TicketCategories/Dtos.cs:7](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/TicketCategories/Dtos.cs#L7)

Namespace: `KamiSama.Modules.Ticketing.Features.TicketCategories`

Kind: `Record`

## Description

Provides the `TicketCategoryListItemDto` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
public record TicketCategoryListItemDto(Guid Id, string Name, DateTime CreatedAt, DateTime UpdatedAt);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/TicketCategories/Dtos.cs#L7)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
public record TicketCategoryListItemDto(Guid Id, string Name, DateTime CreatedAt, DateTime UpdatedAt);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `Id` | `Guid` | `-` | The `Id` value passed to this member. |
| `Name` | `string` | `-` | The `Name` value passed to this member. |
| `CreatedAt` | `DateTime` | `-` | The `CreatedAt` value passed to this member. |
| `UpdatedAt` | `DateTime` | `-` | The `UpdatedAt` value passed to this member. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

