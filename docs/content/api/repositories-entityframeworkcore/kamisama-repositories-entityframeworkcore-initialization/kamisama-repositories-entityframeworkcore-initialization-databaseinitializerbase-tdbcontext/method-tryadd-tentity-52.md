# TryAdd<TEntity>

[Back to DatabaseInitializerBase<TDbContext>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.EntityFrameworkCore](../../index.md)

Source: [src/Repositories.EntityFrameworkCore/Initialization/DatabaseInitializerBase.cs:52](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFrameworkCore/Initialization/DatabaseInitializerBase.cs#L52)

Type: `KamiSama.Repositories.EntityFrameworkCore.Initialization.DatabaseInitializerBase<TDbContext>`

Kind: `Method`

## Description

Safely adds an entity if it is not already exist. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
protected async Task<TEntity> TryAdd<TEntity>(Expression<Func<TEntity, bool>> predicate, TEntity entity, CancellationToken cancellationToken)
    where TEntity : class;
```

## Type Parameters

| Name | Description |
| --- | --- |
| `TEntity` |  |

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `predicate` | `Expression<Func<TEntity, bool>>` | `-` | The `predicate` value passed to this member. |
| `entity` | `TEntity` | `-` | The `entity` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<TEntity>` | Returns a `Task<TEntity>` value. |

## Example

No concise standalone example is available yet.

