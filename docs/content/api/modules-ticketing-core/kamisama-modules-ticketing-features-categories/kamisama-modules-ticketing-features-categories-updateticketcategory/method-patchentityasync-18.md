# PatchEntityAsync

[Back to UpdateTicketCategory](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Core](../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Core/Features/Categories/UpdateTicketCategory.cs:18](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Core/Features/Categories/UpdateTicketCategory.cs#L18)

Type: `KamiSama.Modules.Ticketing.Features.Categories.UpdateTicketCategory`

Kind: `Method`

## Description

Runs the `PatchEntityAsync` operation on `UpdateTicketCategory`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
protected override Task PatchEntityAsync(TicketCategory entity, UpdateTicketCategoryRequest request, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `entity` | `TicketCategory` | `-` | The `entity` value passed to this member. |
| `request` | `UpdateTicketCategoryRequest` | `-` | The `request` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | Returns a `Task` value. |

## Example

No concise standalone example is available yet.

