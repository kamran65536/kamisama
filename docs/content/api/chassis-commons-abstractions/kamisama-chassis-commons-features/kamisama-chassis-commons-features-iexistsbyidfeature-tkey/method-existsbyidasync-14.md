# ExistsByIdAsync

[Back to IExistsByIdFeature<TKey>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons.Abstractions](../../index.md)

Source: [src/Chassis.Commons.Abstractions/Features/IExistsByIdFeature.cs:14](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons.Abstractions/Features/IExistsByIdFeature.cs#L14)

Type: `KamiSama.Chassis.Commons.Features.IExistsByIdFeature<TKey>`

Kind: `Method`

## Description

checks if entity exists or not. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
Task<bool> ExistsByIdAsync(TKey id, CancellationToken cancellationToken);
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

