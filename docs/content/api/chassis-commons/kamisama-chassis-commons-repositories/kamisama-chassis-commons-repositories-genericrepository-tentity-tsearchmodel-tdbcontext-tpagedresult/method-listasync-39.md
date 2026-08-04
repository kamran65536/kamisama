# ListAsync

[Back to GenericRepository<TEntity, TSearchModel, TDbContext, TPagedResult>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons](../../index.md)

Source: [src/Chassis.Commons/Repositories/GenericRepository.cs:39](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Repositories/GenericRepository.cs#L39)

Type: `KamiSama.Chassis.Commons.Repositories.GenericRepository<TEntity, TSearchModel, TDbContext, TPagedResult>`

Kind: `Method`

## Description

Applies the search model and returns a paged repository result.

## Declaration

```csharp
public Task<TPagedResult> ListAsync(TSearchModel searchModel, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `searchModel` | `TSearchModel` | `-` | The `searchModel` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<TPagedResult>` | Returns a `Task<TPagedResult>` value. |

## Example

No concise standalone example is available yet.

