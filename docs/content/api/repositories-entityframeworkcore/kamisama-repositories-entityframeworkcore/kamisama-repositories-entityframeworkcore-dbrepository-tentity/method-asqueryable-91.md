# AsQueryable

[Back to DbRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.EntityFrameworkCore](../../index.md)

Source: [src/Repositories.EntityFrameworkCore/DbRepository.cs:91](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFrameworkCore/DbRepository.cs#L91)

Type: `KamiSama.Repositories.EntityFrameworkCore.DbRepository<TEntity>`

Kind: `Method`

## Description

Returns the tracked entity set as a deferred query. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public virtual IQueryable<TEntity> AsQueryable();
```

## Parameters

This member does not declare parameters.

## Returns

| Type | Description |
| --- | --- |
| `IQueryable<TEntity>` | The underlying `DbSet{TEntity}` as an `IQueryable{TEntity}`. |

## Example

```csharp
IQueryable<User> trackedUsers = repository.AsQueryable();
```

