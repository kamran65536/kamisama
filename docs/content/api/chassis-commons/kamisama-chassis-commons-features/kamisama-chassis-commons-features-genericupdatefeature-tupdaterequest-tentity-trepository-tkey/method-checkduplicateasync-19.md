# CheckDuplicateAsync

[Back to GenericUpdateFeature<TUpdateRequest, TEntity, TRepository, TKey>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons](../../index.md)

Source: [src/Chassis.Commons/Features/GenericUpdateFeature.cs:19](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Features/GenericUpdateFeature.cs#L19)

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
| `id` | `TKey` | `-` | The `id` value passed to this member. |
| `request` | `TUpdateRequest` | `-` | The `request` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | Returns a `Task` value. |

## Example

```csharp
protected override async Task CheckDuplicateAsync(Guid id, UpdateProductRequest request, CancellationToken cancellationToken)
{
    var duplicate = await Repository.FindByNameAsync(request.Name, cancellationToken);
    if (duplicate is not null && duplicate.Id != id)
        throw new AlreadyExistsException<Product>(request.Name, nameof(request.Name));
}
```

