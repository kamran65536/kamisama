# ConvertToDto

[Back to ListTicketCategories](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Core](../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Core/Features/Categories/ListTicketCategories.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Core/Features/Categories/ListTicketCategories.cs#L9)

Type: `KamiSama.Modules.Ticketing.Features.Categories.ListTicketCategories`

Kind: `Method`

## Description

Runs the `ConvertToDto` operation on `ListTicketCategories`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
protected override Task<TicketCategoryListItemDto> ConvertToDto(TicketCategory entity, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `entity` | `TicketCategory` | `-` | The `entity` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<TicketCategoryListItemDto>` | Returns a `Task<TicketCategoryListItemDto>` value. |

## Example

No concise standalone example is available yet.

