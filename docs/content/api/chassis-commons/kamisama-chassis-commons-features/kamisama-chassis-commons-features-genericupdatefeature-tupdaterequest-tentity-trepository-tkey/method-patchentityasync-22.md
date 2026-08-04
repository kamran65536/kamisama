# PatchEntityAsync

[Back to GenericUpdateFeature<TUpdateRequest, TEntity, TRepository, TKey>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons](../../index.md)

Source: [src/Chassis.Commons/Features/GenericUpdateFeature.cs:22](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Features/GenericUpdateFeature.cs#L22)

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
| `entity` | `TEntity` | `-` | The `entity` value passed to this member. |
| `request` | `TUpdateRequest` | `-` | The `request` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | Returns a `Task` value. |

## Example

```csharp
protected override Task PatchEntityAsync(Product entity, UpdateProductRequest request, CancellationToken cancellationToken)
{
    entity.Name = request.Name;
    entity.Price = request.Price;
    return Task.CompletedTask;
}
```

