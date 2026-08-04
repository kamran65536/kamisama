# DeleteAsync

[Back to GenericDeleteFeature<TEntity, TRepository, TKey>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons](../../index.md)

Source: [src/Chassis.Commons/Features/GenericDeleteFeature.cs:25](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Features/GenericDeleteFeature.cs#L25)

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
| `id` | `TKey` | `-` | The `id` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | Returns a `Task` value. |

## Example

```csharp
await deleteProductFeature.DeleteAsync(productId, cancellationToken);
```

