# CanBeDeletedAsync

[Back to GenericDeleteFeature<TEntity, TRepository, TKey>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons](../../index.md)

Source: [src/Chassis.Commons/Features/GenericDeleteFeature.cs:23](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Features/GenericDeleteFeature.cs#L23)

Type: `KamiSama.Chassis.Commons.Features.GenericDeleteFeature<TEntity, TRepository, TKey>`

Kind: `Method`

## Description

Deletion guard called after the entity is loaded and before deletion. Override it to prevent deletes for entities that are still referenced or otherwise protected.

## Declaration

```csharp
protected virtual Task<bool> CanBeDeletedAsync(TRepository repository, TEntity entity);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `repository` | `TRepository` | `-` | The repository used by the delete workflow. |
| `entity` | `TEntity` | `-` | The loaded entity proposed for deletion. |

## Returns

| Type | Description |
| --- | --- |
| `Task<bool>` | to delete the entity; otherwise, . |

## Example

```csharp
protected override Task<bool> CanBeDeletedAsync(IProductRepository repository, Product entity)
    => Task.FromResult(!entity.HasOpenOrders);
```

