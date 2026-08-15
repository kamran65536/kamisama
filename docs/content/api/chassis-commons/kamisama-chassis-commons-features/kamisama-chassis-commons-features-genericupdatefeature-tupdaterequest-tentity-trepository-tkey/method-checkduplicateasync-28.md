# CheckDuplicateAsync

[Back to GenericUpdateFeature<TUpdateRequest, TEntity, TRepository, TKey>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons](../../index.md)

Source: [src/Chassis.Commons/Features/GenericUpdateFeature.cs:28](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Features/GenericUpdateFeature.cs#L28)

Type: `KamiSama.Chassis.Commons.Features.GenericUpdateFeature<TUpdateRequest, TEntity, TRepository, TKey>`

Kind: `Method`

## Description

Validation hook called after the entity is loaded and before it is patched. Override it to reject conflicting update requests.

## Declaration

```csharp
protected virtual Task CheckDuplicateAsync(TKey id, TUpdateRequest request, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `id` | `TKey` | `-` | The key of the entity being updated. |
| `request` | `TUpdateRequest` | `-` | The update request to validate. |
| `cancellationToken` | `CancellationToken` | `-` | A token that can cancel the operation. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | A task that completes when validation succeeds. |

## Example

```csharp
protected override async Task CheckDuplicateAsync(Guid id, UpdateProductRequest request, CancellationToken cancellationToken)
{
    var duplicate = await Repository.FindByNameAsync(request.Name, cancellationToken);
    if (duplicate is not null && duplicate.Id != id)
        throw new AlreadyExistsException<Product>(request.Name, nameof(request.Name));
}
```

