# Add

[Back to InMemoryRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Core](../../index.md)

Source: [src/Repositories.Core/InMemoryRepository.cs:57](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Core/InMemoryRepository.cs#L57)

Type: `KamiSama.Repositories.InMemoryRepository<TEntity>`

Kind: `Method`

## Description

Adds the entity to the in-memory set unless an equal entity already exists. Mutation is serialized per instance, but concurrent reads are not locked.

## Declaration

```csharp
public virtual void Add(TEntity item);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `item` | `TEntity` | `-` | The entity to add. Equal duplicates are ignored by `HashSet{T}`. |

## Example

No concise standalone example is available yet.

