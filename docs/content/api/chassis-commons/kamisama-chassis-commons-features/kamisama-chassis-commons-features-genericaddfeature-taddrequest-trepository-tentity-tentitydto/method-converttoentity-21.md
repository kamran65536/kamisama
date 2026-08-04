# ConvertToEntity

[Back to GenericAddFeature<TAddRequest, TRepository, TEntity, TEntityDto>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons](../../index.md)

Source: [src/Chassis.Commons/Features/GenericAddFeature.cs:21](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Features/GenericAddFeature.cs#L21)

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
| `request` | `TAddRequest` | `-` | The `request` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<TEntity>` | Returns a `Task<TEntity>` value. |

## Example

```csharp
protected override Task<Product> ConvertToEntity(AddProductRequest request, CancellationToken cancellationToken)
    => Task.FromResult(new Product { Id = Guid.NewGuid(), Name = request.Name, Price = request.Price });
```

