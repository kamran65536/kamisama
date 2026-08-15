# Update

[Back to DbRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.EntityFramework](../../index.md)

Source: [src/Repositories.EntityFramework/DbRepository.cs:47](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFramework/DbRepository.cs#L47)

Type: `KamiSama.Repositories.EntityFramework.DbRepository<TEntity>`

Kind: `Method`

## Description

Marks an entity as modified and immediately saves the context. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public virtual void Update(TEntity item);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `item` | `TEntity` | `-` | The entity whose complete mapped state should be treated as modified. |

## Example

```csharp
repository.Update(user); // Marks the complete entity modified and saves immediately.
```

