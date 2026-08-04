# Any

[Back to DbRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.EntityFramework](../../index.md)

Source: [src/Repositories.EntityFramework/DbRepository.cs:94](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFramework/DbRepository.cs#L94)

Type: `KamiSama.Repositories.EntityFramework.DbRepository<TEntity>`

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

