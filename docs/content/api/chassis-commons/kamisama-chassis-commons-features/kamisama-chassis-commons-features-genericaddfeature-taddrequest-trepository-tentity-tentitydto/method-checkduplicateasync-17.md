# CheckDuplicateAsync

[Back to GenericAddFeature<TAddRequest, TRepository, TEntity, TEntityDto>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons](../../index.md)

Source: [src/Chassis.Commons/Features/GenericAddFeature.cs:17](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Features/GenericAddFeature.cs#L17)

Type: `KamiSama.Chassis.Commons.Features.GenericAddFeature<TAddRequest, TRepository, TEntity, TEntityDto>`

Kind: `Method`

## Description

Validation hook called at the start of `AddAsync`. Override it to detect duplicate or conflicting data and throw a domain or HTTP exception before the entity is created.

## Declaration

```csharp
protected virtual Task CheckDuplicateAsync(TAddRequest request, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `request` | `TAddRequest` | `-` | The `request` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | Returns a `Task` value. |

## Example

```csharp
protected override async Task CheckDuplicateAsync(AddProductRequest request, CancellationToken cancellationToken)
{
    if (await Repository.ExistsByNameAsync(request.Name, cancellationToken))
        throw new AlreadyExistsException<Product>(request.Name, nameof(request.Name));
}
```

