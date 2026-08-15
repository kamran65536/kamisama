# Any

[Back to DbRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.EntityFramework](../../index.md)

Source: [src/Repositories.EntityFramework/DbRepository.cs:105](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFramework/DbRepository.cs#L105)

Type: `KamiSama.Repositories.EntityFramework.DbRepository<TEntity>`

Kind: `Method`

## Description

Determines synchronously whether any entity matches a predicate. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public virtual bool Any(Expression<Func<TEntity, bool>> predicate);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `predicate` | `Expression<Func<TEntity, bool>>` | `-` | The expression translated by the EF6 query provider. |

## Returns

| Type | Description |
| --- | --- |
| `bool` | when at least one entity matches; otherwise, . |

## Example

```csharp
bool exists = repository.Any(user => user.Email == email);
```

