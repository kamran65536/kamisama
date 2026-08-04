# ApplySearchModel

[Back to TicketCategoryRepository](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Core](../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Core/Repositories/Implementations/TicketCategoryRepository.cs:10](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Core/Repositories/Implementations/TicketCategoryRepository.cs#L10)

Type: `KamiSama.Modules.Ticketing.Repositories.Implementations.TicketCategoryRepository`

Kind: `Method`

## Description

Runs the `ApplySearchModel` operation on `TicketCategoryRepository`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
protected override IQueryable<TicketCategory> ApplySearchModel(IQueryable<TicketCategory> query, TicketCategorySearchModel searchModel);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `query` | `IQueryable<TicketCategory>` | `-` | The `query` value passed to this member. |
| `searchModel` | `TicketCategorySearchModel` | `-` | The `searchModel` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `IQueryable<TicketCategory>` | Returns a `IQueryable<TicketCategory>` value. |

## Example

No concise standalone example is available yet.

