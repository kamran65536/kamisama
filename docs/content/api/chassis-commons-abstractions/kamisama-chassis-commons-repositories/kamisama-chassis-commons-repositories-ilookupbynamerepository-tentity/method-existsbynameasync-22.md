# ExistsByNameAsync

[Back to ILookupByNameRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons.Abstractions](../../index.md)

Source: [src/Chassis.Commons.Abstractions/Repositories/ILookupByNameRepository.cs:22](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons.Abstractions/Repositories/ILookupByNameRepository.cs#L22)

Type: `KamiSama.Chassis.Commons.Repositories.ILookupByNameRepository<TEntity>`

Kind: `Method`

## Description

Checks that entity exists by name or not. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
Task<bool> ExistsByNameAsync(string name, CancellationToken cancellationToken);
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

