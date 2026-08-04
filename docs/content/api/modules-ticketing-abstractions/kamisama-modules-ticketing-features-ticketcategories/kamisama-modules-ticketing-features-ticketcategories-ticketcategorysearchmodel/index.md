# TicketCategorySearchModel

<a id="ticketcategorysearchmodel"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Abstractions/Features/TicketCategories/Dtos.cs:3](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/TicketCategories/Dtos.cs#L3)

Namespace: `KamiSama.Modules.Ticketing.Features.TicketCategories`

Kind: `Record`

## Description

Provides the `TicketCategorySearchModel` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
public record TicketCategorySearchModel(int Page, int PageSize, string? Name, string? OrderBy) : SearchModel(Page, PageSize, OrderBy)
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/TicketCategories/Dtos.cs#L3)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
public record TicketCategorySearchModel(int Page, int PageSize, string? Name, string? OrderBy) : SearchModel(Page, PageSize, OrderBy)
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `Page` | `int` | `-` | The `Page` value passed to this member. |
| `PageSize` | `int` | `-` | The `PageSize` value passed to this member. |
| `Name` | `string?` | `-` | The `Name` value passed to this member. |
| `OrderBy` | `string?` | `-` | The `OrderBy` value passed to this member. |

## Members

### Properties

| Member | Description |
| --- | --- |
| [All](property-all-5.md) | Exposes the `All` value on `TicketCategorySearchModel`. Read or set it as part of configuring or using the type. |

