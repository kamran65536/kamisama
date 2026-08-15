# PatchEntityAsync

[Back to GenericUpdateFeature<TUpdateRequest, TEntity, TRepository, TKey>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons](../../index.md)

Source: [src/Chassis.Commons/Features/GenericUpdateFeature.cs:34](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Features/GenericUpdateFeature.cs#L34)

Type: `KamiSama.Chassis.Commons.Features.GenericUpdateFeature<TUpdateRequest, TEntity, TRepository, TKey>`

Kind: `Method`

## Description

Mutation hook called after duplicate validation. Override it to copy request values onto the loaded entity before the base class saves it.

## Declaration

```csharp
protected abstract Task PatchEntityAsync(TEntity entity, TUpdateRequest request, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `entity` | `TEntity` | `-` | The tracked entity to modify. |
| `request` | `TUpdateRequest` | `-` | The update values to apply. |
| `cancellationToken` | `CancellationToken` | `-` | A token that can cancel the operation. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | A task that completes when the entity has been patched. |

## Example

```csharp
protected override Task PatchEntityAsync(Product entity, UpdateProductRequest request, CancellationToken cancellationToken)
{
    entity.Name = request.Name;
    entity.Price = request.Price;
    return Task.CompletedTask;
}
```

