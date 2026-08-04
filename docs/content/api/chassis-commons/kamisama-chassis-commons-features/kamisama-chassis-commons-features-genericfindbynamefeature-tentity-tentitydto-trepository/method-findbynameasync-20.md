# FindByNameAsync

[Back to GenericFindByNameFeature<TEntity, TEntityDto, TRepository>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons](../../index.md)

Source: [src/Chassis.Commons/Features/GenericFindByNameFeature.cs:20](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Features/GenericFindByNameFeature.cs#L20)

Type: `KamiSama.Chassis.Commons.Features.GenericFindByNameFeature<TEntity, TEntityDto, TRepository>`

Kind: `Method`

## Description

Loads an entity by name through the repository, throws `NotFoundException<TEntity>` when no entity exists, and maps the entity to a DTO.

## Declaration

```csharp
public async virtual Task<TEntityDto> FindByNameAsync(string name, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `name` | `string` | `-` | The `name` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<TEntityDto>` | Returns a `Task<TEntityDto>` value. |

## Example

No concise standalone example is available yet.

