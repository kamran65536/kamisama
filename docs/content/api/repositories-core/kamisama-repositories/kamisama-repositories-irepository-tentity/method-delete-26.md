# Delete

[Back to IRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Core](../../index.md)

Source: [src/Repositories.Core/IRepository.cs:26](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Core/IRepository.cs#L26)

Type: `KamiSama.Repositories.IRepository<TEntity>`

Kind: `Method`

## Description

Deletes an entity according to the implementation's matching and persistence rules.

## Declaration

```csharp
void Delete(TEntity item);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `item` | `TEntity` | `-` | The entity to delete. |

## Example

```csharp
repository.Delete(user);
```

