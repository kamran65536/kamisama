# ExistsByIdAsync

[Back to GenericExistsByIdFeature<TEntity, TRepository, TKey>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons](../../index.md)

Source: [src/Chassis.Commons/Features/GenericExistsByIdFeature.cs:25](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Features/GenericExistsByIdFeature.cs#L25)

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
| `id` | `TKey` | `-` | The identifier to test. |
| `cancellationToken` | `CancellationToken` | `-` | A token that can cancel the repository operation. |

## Returns

| Type | Description |
| --- | --- |
| `Task<bool>` | when an entity exists; otherwise, . |

## Example

No concise standalone example is available yet.

