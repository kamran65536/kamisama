# ConvertToDto

[Back to AddTicketCategory](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Core](../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Core/Features/Categories/AddTicketCategory.cs:23](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Core/Features/Categories/AddTicketCategory.cs#L23)

Type: `KamiSama.Modules.Ticketing.Features.Categories.AddTicketCategory`

Kind: `Method`

## Description

Runs the `ConvertToDto` operation on `AddTicketCategory`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
protected override Task<TicketCategoryDto> ConvertToDto(TicketCategory entity, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `entity` | `TicketCategory` | `-` | The `entity` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<TicketCategoryDto>` | Returns a `Task<TicketCategoryDto>` value. |

## Example

No concise standalone example is available yet.

