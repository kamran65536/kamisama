# UpdateAsync

[Back to GenericUpdateFeature<TUpdateRequest, TEntity, TRepository, TKey>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons](../../index.md)

Source: [src/Chassis.Commons/Features/GenericUpdateFeature.cs:24](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Features/GenericUpdateFeature.cs#L24)

Type: `KamiSama.Chassis.Commons.Features.GenericUpdateFeature<TUpdateRequest, TEntity, TRepository, TKey>`

Kind: `Method`

## Description

Runs the complete update flow: load the entity by id, throw when missing, check duplicate state, patch the entity, and save it through the repository.

## Declaration

```csharp
public async virtual Task UpdateAsync(TKey id, TUpdateRequest request, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `id` | `TKey` | `-` | The `id` value passed to this member. |
| `request` | `TUpdateRequest` | `-` | The `request` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | Returns a `Task` value. |

## Example

```csharp
await updateProductFeature.UpdateAsync(productId, new UpdateProductRequest("Keyboard", 120), cancellationToken);
```

