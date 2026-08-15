# ListAsync

[Back to IListingRepository<TEntity, TSearchModel, TPagedResult>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons.Abstractions](../../index.md)

Source: [src/Chassis.Commons.Abstractions/Repositories/IListingRepository.cs:19](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons.Abstractions/Repositories/IListingRepository.cs#L19)

Type: `KamiSama.Chassis.Commons.Repositories.IListingRepository<TEntity, TSearchModel, TPagedResult>`

Kind: `Method`

## Description

Searches the store and returns the requested page. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
Task<TPagedResult> ListAsync(TSearchModel searchModel, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `searchModel` | `TSearchModel` | `-` | The filtering and paging values. |
| `cancellationToken` | `CancellationToken` | `-` | A token that can cancel the operation. |

## Returns

| Type | Description |
| --- | --- |
| `Task<TPagedResult>` | A page of matching entities. |

## Example

No concise standalone example is available yet.

