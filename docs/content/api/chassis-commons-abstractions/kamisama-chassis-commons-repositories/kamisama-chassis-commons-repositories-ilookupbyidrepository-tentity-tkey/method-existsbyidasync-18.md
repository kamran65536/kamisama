# ExistsByIdAsync

[Back to ILookupByIdRepository<TEntity, TKey>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons.Abstractions](../../index.md)

Source: [src/Chassis.Commons.Abstractions/Repositories/ILookupByIdReposiotry.cs:18](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons.Abstractions/Repositories/ILookupByIdReposiotry.cs#L18)

Type: `KamiSama.Chassis.Commons.Repositories.ILookupByIdRepository<TEntity, TKey>`

Kind: `Method`

## Description

Exists if an entity exists by id or not. Use it with the surrounding package APIs when composing application code.

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

