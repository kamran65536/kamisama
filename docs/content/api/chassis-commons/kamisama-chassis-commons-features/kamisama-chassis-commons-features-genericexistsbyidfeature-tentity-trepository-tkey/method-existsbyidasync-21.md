# ExistsByIdAsync

[Back to GenericExistsByIdFeature<TEntity, TRepository, TKey>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons](../../index.md)

Source: [src/Chassis.Commons/Features/GenericExistsByIdFeature.cs:21](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Features/GenericExistsByIdFeature.cs#L21)

Type: `KamiSama.Chassis.Commons.Features.GenericExistsByIdFeature<TEntity, TRepository, TKey>`

Kind: `Method`

## Description

Checks whether an entity exists for the supplied key by delegating to the repository.

## Declaration

```csharp
public virtual Task<bool> ExistsByIdAsync(TKey id, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `id` | `TKey` | `-` | The `id` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<bool>` | Returns a `Task<bool>` value. |

## Example

No concise standalone example is available yet.

