# TryAdd<TEntity>

[Back to DatabaseInitializerBase<TDbContext>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.EntityFrameworkCore](../../index.md)

Source: [src/Repositories.EntityFrameworkCore/Initialization/DatabaseInitializerBase.cs:61](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFrameworkCore/Initialization/DatabaseInitializerBase.cs#L61)

Type: `KamiSama.Repositories.EntityFrameworkCore.Initialization.DatabaseInitializerBase<TDbContext>`

Kind: `Method`

## Description

Returns an existing matching entity or adds and immediately saves a new entity. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
protected async Task<TEntity> TryAdd<TEntity>(Expression<Func<TEntity, bool>> predicate, TEntity entity, CancellationToken cancellationToken)
    where TEntity : class;
```

## Type Parameters

| Name | Description |
| --- | --- |
| `TEntity` | The entity type to query and seed. |

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `predicate` | `Expression<Func<TEntity, bool>>` | `-` | The expression used to identify an existing row. |
| `entity` | `TEntity` | `-` | The entity to add when no row matches. |
| `cancellationToken` | `CancellationToken` | `-` | A token that can cancel lookup or saving. |

## Returns

| Type | Description |
| --- | --- |
| `Task<TEntity>` | The existing tracked entity when found; otherwise, the newly saved entity. |

## Remarks

The lookup and insert are separate operations and do not prevent concurrent duplicate inserts.

## Example

```csharp
User admin = await TryAdd(
    user => user.Name == "Admin", new User { Name = "Admin" }, cancellationToken);
```

