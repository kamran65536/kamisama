# Update

[Back to IRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Core](../../index.md)

Source: [src/Repositories.Core/IRepository.cs:21](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Core/IRepository.cs#L21)

Type: `KamiSama.Repositories.IRepository<TEntity>`

Kind: `Method`

## Description

Updates an entity according to the implementation's matching and persistence rules; the contract does not require replacement or merging.

## Declaration

```csharp
void Update(TEntity item);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `item` | `TEntity` | `-` | The entity to update. |

## Example

```csharp
repository.Update(user); // Persistence semantics depend on the implementation.
```

