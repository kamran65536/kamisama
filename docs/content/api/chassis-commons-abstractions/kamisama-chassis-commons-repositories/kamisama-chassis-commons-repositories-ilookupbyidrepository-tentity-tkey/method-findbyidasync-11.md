# FindByIdAsync

[Back to ILookupByIdRepository<TEntity, TKey>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons.Abstractions](../../index.md)

Source: [src/Chassis.Commons.Abstractions/Repositories/ILookupByIdReposiotry.cs:11](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons.Abstractions/Repositories/ILookupByIdReposiotry.cs#L11)

Type: `KamiSama.Chassis.Commons.Repositories.ILookupByIdRepository<TEntity, TKey>`

Kind: `Method`

## Description

Runs the `FindByIdAsync` operation on `ILookupByIdRepository<TEntity, TKey>`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
Task<TEntity?> FindByIdAsync(TKey id, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `id` | `TKey` | `-` | The `id` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<TEntity?>` | Returns a `Task<TEntity?>` value. |

## Example

No concise standalone example is available yet.

