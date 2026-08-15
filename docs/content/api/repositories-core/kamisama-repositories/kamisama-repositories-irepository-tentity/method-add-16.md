# Add

[Back to IRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Core](../../index.md)

Source: [src/Repositories.Core/IRepository.cs:16](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Core/IRepository.cs#L16)

Type: `KamiSama.Repositories.IRepository<TEntity>`

Kind: `Method`

## Description

Adds an entity according to the implementation's persistence and duplicate rules.

## Declaration

```csharp
void Add(TEntity item);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `item` | `TEntity` | `-` | The entity to add. |

## Example

```csharp
repository.Add(user);
```

