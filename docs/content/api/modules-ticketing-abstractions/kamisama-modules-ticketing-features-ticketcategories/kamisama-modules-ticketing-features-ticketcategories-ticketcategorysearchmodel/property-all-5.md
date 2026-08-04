# All

[Back to TicketCategorySearchModel](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Abstractions](../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Abstractions/Features/TicketCategories/Dtos.cs:5](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Abstractions/Features/TicketCategories/Dtos.cs#L5)

Type: `KamiSama.Modules.Ticketing.Features.TicketCategories.TicketCategorySearchModel`

Kind: `Property`

## Description

Exposes the `All` value on `TicketCategorySearchModel`. Read or set it as part of configuring or using the type.

## Declaration

```csharp
public static new TicketCategorySearchModel All { get; set; } = new(default, default, default, default);
```

## Value

| Detail | Description |
| --- | --- |
| `Property` | Gets or sets a `TicketCategorySearchModel` value. |

## Example

```csharp
using KamiSama.Extensions.Paging;

var search = SearchModel.All;
```

