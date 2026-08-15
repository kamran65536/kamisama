# Where

[Back to DbRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.EntityFrameworkCore](../../index.md)

Source: [src/Repositories.EntityFrameworkCore/DbRepository.cs:96](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFrameworkCore/DbRepository.cs#L96)

Type: `KamiSama.Repositories.EntityFrameworkCore.DbRepository<TEntity>`

Kind: `Method`

## Description

Creates a tracked, deferred query filtered by a predicate. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public virtual IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `predicate` | `Expression<Func<TEntity, bool>>` | `-` | The expression translated by the EF Core query provider. |

## Returns

| Type | Description |
| --- | --- |
| `IQueryable<TEntity>` | A deferred query over matching entities. |

## Example

```csharp
IQueryable<User> activeUsers = repository.Where(user => user.IsActive);
```

