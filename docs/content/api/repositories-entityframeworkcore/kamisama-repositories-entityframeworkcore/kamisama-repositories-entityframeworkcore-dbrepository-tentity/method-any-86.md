# Any

[Back to DbRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.EntityFrameworkCore](../../index.md)

Source: [src/Repositories.EntityFrameworkCore/DbRepository.cs:86](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFrameworkCore/DbRepository.cs#L86)

Type: `KamiSama.Repositories.EntityFrameworkCore.DbRepository<TEntity>`

Kind: `Method`

## Description

Checks if any entity exists in the repository. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public virtual bool Any(Expression<Func<TEntity, bool>> predicate);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `predicate` | `Expression<Func<TEntity, bool>>` | `-` | The `predicate` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `bool` | Returns a `bool` value. |

## Example

```csharp
var entity = new SampleEntity { Id = 1, Name = "Test" };
var context = GetDbContext();

var repository = new DbRepository<SampleEntity>(context);

repository.Add(entity);
```

