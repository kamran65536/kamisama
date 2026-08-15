# ExistsByIdAsync

[Back to IExistsByIdFeature<TKey>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons.Abstractions](../../index.md)

Source: [src/Chassis.Commons.Abstractions/Features/IExistsByIdFeature.cs:15](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons.Abstractions/Features/IExistsByIdFeature.cs#L15)

Type: `KamiSama.Chassis.Commons.Features.IExistsByIdFeature<TKey>`

Kind: `Method`

## Description

Determines whether an entity with the supplied identifier exists. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
Task<bool> ExistsByIdAsync(TKey id, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `id` | `TKey` | `-` | The identifier to test. |
| `cancellationToken` | `CancellationToken` | `-` | A token that can cancel the operation. |

## Returns

| Type | Description |
| --- | --- |
| `Task<bool>` | when the entity exists; otherwise, . |

## Example

No concise standalone example is available yet.

