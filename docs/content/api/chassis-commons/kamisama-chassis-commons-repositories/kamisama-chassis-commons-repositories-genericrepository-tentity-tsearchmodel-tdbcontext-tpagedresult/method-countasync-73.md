# CountAsync

[Back to GenericRepository<TEntity, TSearchModel, TDbContext, TPagedResult>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons](../../index.md)

Source: [src/Chassis.Commons/Repositories/GenericRepository.cs:73](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Repositories/GenericRepository.cs#L73)

Type: `KamiSama.Chassis.Commons.Repositories.GenericRepository<TEntity, TSearchModel, TDbContext, TPagedResult>`

Kind: `Method`

## Description

Applies the search model and returns the total matching entity count.

## Declaration

```csharp
public Task<int> CountAsync(TSearchModel searchModel, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `searchModel` | `TSearchModel` | `-` | The filtering values. |
| `cancellationToken` | `CancellationToken` | `-` | A token that can cancel query execution. |

## Returns

| Type | Description |
| --- | --- |
| `Task<int>` | The number of matching entities. |

## Example

No concise standalone example is available yet.

