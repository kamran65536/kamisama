# ExistsByNameAsync

[Back to GenericExistsByNameFeature<TEntity, TRepository>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons](../../index.md)

Source: [src/Chassis.Commons/Features/GenericExistsByNameFeature.cs:17](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Features/GenericExistsByNameFeature.cs#L17)

Type: `KamiSama.Chassis.Commons.Features.GenericExistsByNameFeature<TEntity, TRepository>`

Kind: `Method`

## Description

Checks whether an entity exists for the supplied name by delegating to the repository.

## Declaration

```csharp
public virtual Task<bool> ExistsByNameAsync(string name, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `name` | `string` | `-` | The `name` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<bool>` | Returns a `Task<bool>` value. |

## Example

No concise standalone example is available yet.

