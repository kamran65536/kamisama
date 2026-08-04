# ConvertToDto

[Back to GenericFindByNameFeature<TEntity, TEntityDto, TRepository>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons](../../index.md)

Source: [src/Chassis.Commons/Features/GenericFindByNameFeature.cs:17](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Features/GenericFindByNameFeature.cs#L17)

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
| `entity` | `TEntity` | `-` | The `entity` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<TEntityDto>` | Returns a `Task<TEntityDto>` value. |

## Example

No concise standalone example is available yet.

