# FindByIdAsync

[Back to GenericFindByIdFeature<TEntity, TEntityDto, TRepository, TKey>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons](../../index.md)

Source: [src/Chassis.Commons/Features/GenericFindByIdFeature.cs:34](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Features/GenericFindByIdFeature.cs#L34)

Type: `KamiSama.Chassis.Commons.Features.GenericFindByIdFeature<TEntity, TEntityDto, TRepository, TKey>`

Kind: `Method`

## Description

Loads an entity by key through the repository, throws `NotFoundException<TEntity>` when no entity exists, and maps the entity to a DTO.

## Declaration

```csharp
public async virtual Task<TEntityDto> FindByIdAsync(TKey id, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `id` | `TKey` | `-` | The identifier to find. |
| `cancellationToken` | `CancellationToken` | `-` | A token that can cancel the operation. |

## Returns

| Type | Description |
| --- | --- |
| `Task<TEntityDto>` | The DTO for the matching entity. |

## Example

```csharp
var dto = await findProductFeature.FindByIdAsync(productId, cancellationToken);
```

