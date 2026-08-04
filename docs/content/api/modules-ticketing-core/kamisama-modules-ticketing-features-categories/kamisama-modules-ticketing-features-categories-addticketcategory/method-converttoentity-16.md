# ConvertToEntity

[Back to AddTicketCategory](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Core](../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Core/Features/Categories/AddTicketCategory.cs:16](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Core/Features/Categories/AddTicketCategory.cs#L16)

Type: `KamiSama.Modules.Ticketing.Features.Categories.AddTicketCategory`

Kind: `Method`

## Description

Runs the `ConvertToEntity` operation on `AddTicketCategory`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
protected override Task<TicketCategory> ConvertToEntity(AddTicketCategoryRequest request, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `request` | `AddTicketCategoryRequest` | `-` | The `request` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<TicketCategory>` | Returns a `Task<TicketCategory>` value. |

## Example

No concise standalone example is available yet.

