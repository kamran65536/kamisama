# DeleteAsync

[Back to GenericDeleteFeature<TEntity, TRepository, TKey>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons](../../index.md)

Source: [src/Chassis.Commons/Features/GenericDeleteFeature.cs:30](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Features/GenericDeleteFeature.cs#L30)

Type: `KamiSama.Chassis.Commons.Features.GenericDeleteFeature<TEntity, TRepository, TKey>`

Kind: `Method`

## Description

Runs the complete delete flow: load the entity by id, throw when missing, ask `CanBeDeletedAsync`, and delete through the repository only when allowed.

## Declaration

```csharp
public async virtual Task DeleteAsync(TKey id, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `id` | `TKey` | `-` | The key of the entity to delete. |
| `cancellationToken` | `CancellationToken` | `-` | A token that can cancel repository operations. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | A task that represents the asynchronous delete workflow. |

## Example

```csharp
await deleteProductFeature.DeleteAsync(productId, cancellationToken);
```

