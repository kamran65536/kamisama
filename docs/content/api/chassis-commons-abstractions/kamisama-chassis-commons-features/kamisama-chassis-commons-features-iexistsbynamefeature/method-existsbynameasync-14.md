# ExistsByNameAsync

[Back to IExistsByNameFeature](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons.Abstractions](../../index.md)

Source: [src/Chassis.Commons.Abstractions/Features/IExistsByNameFeature.cs:14](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons.Abstractions/Features/IExistsByNameFeature.cs#L14)

Type: `KamiSama.Chassis.Commons.Features.IExistsByNameFeature`

Kind: `Method`

## Description

Determines whether an entity with the supplied name exists. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
Task<bool> ExistsByNameAsync(string name, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `name` | `string` | `-` | The name to test. |
| `cancellationToken` | `CancellationToken` | `-` | A token that can cancel the operation. |

## Returns

| Type | Description |
| --- | --- |
| `Task<bool>` | when the entity exists; otherwise, . |

## Example

No concise standalone example is available yet.

