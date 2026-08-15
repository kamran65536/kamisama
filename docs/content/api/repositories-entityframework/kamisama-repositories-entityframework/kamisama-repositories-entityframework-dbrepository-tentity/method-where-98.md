# Where

[Back to DbRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.EntityFramework](../../index.md)

Source: [src/Repositories.EntityFramework/DbRepository.cs:98](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFramework/DbRepository.cs#L98)

Type: `KamiSama.Repositories.EntityFramework.DbRepository<TEntity>`

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
| `predicate` | `Expression<Func<TEntity, bool>>` | `-` | The expression translated by the EF6 query provider. |

## Returns

| Type | Description |
| --- | --- |
| `IQueryable<TEntity>` | A deferred query over matching entities. |

## Example

```csharp
IQueryable<User> activeUsers = repository.Where(user => user.IsActive);
```

