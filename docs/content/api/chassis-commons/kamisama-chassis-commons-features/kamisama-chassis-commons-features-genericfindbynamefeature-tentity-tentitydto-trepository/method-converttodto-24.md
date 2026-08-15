# ConvertToDto

[Back to GenericFindByNameFeature<TEntity, TEntityDto, TRepository>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons](../../index.md)

Source: [src/Chassis.Commons/Features/GenericFindByNameFeature.cs:24](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Features/GenericFindByNameFeature.cs#L24)

Type: `KamiSama.Chassis.Commons.Features.GenericFindByNameFeature<TEntity, TEntityDto, TRepository>`

Kind: `Method`

## Description

Mapping hook called after the entity is found. Override it to return the DTO shape expected by callers.

## Declaration

```csharp
protected abstract Task<TEntityDto> ConvertToDto(TEntity entity, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `entity` | `TEntity` | `-` | The entity loaded from the repository. |
| `cancellationToken` | `CancellationToken` | `-` | A token that can cancel the mapping operation. |

## Returns

| Type | Description |
| --- | --- |
| `Task<TEntityDto>` | The DTO representation of the entity. |

## Example

No concise standalone example is available yet.

