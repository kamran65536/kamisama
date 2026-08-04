# CountAsync

[Back to GenericRepository<TEntity, TSearchModel, TDbContext, TPagedResult>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons](../../index.md)

Source: [src/Chassis.Commons/Repositories/GenericRepository.cs:48](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Repositories/GenericRepository.cs#L48)

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
| `searchModel` | `TSearchModel` | `-` | The `searchModel` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<int>` | Returns a `Task<int>` value. |

## Example

No concise standalone example is available yet.

