# ConvertToEntity

[Back to GenericAddFeature<TAddRequest, TRepository, TEntity, TEntityDto>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons](../../index.md)

Source: [src/Chassis.Commons/Features/GenericAddFeature.cs:32](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Features/GenericAddFeature.cs#L32)

Type: `KamiSama.Chassis.Commons.Features.GenericAddFeature<TAddRequest, TRepository, TEntity, TEntityDto>`

Kind: `Method`

## Description

Mapping hook called after duplicate validation. Override it to create the entity that will be persisted from the incoming add request.

## Declaration

```csharp
protected abstract Task<TEntity> ConvertToEntity(TAddRequest request, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `request` | `TAddRequest` | `-` | The validated create request. |
| `cancellationToken` | `CancellationToken` | `-` | A token that can cancel the operation. |

## Returns

| Type | Description |
| --- | --- |
| `Task<TEntity>` | The entity to add. |

## Example

```csharp
protected override Task<Product> ConvertToEntity(AddProductRequest request, CancellationToken cancellationToken)
    => Task.FromResult(new Product { Id = Guid.NewGuid(), Name = request.Name, Price = request.Price });
```

