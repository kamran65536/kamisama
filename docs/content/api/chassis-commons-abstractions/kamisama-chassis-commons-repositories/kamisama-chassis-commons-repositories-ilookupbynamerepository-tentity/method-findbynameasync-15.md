# FindByNameAsync

[Back to ILookupByNameRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons.Abstractions](../../index.md)

Source: [src/Chassis.Commons.Abstractions/Repositories/ILookupByNameRepository.cs:15](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons.Abstractions/Repositories/ILookupByNameRepository.cs#L15)

Type: `KamiSama.Chassis.Commons.Repositories.ILookupByNameRepository<TEntity>`

Kind: `Method`

## Description

Runs the `FindByNameAsync` operation on `ILookupByNameRepository<TEntity>`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
Task<TEntity?> FindByNameAsync(string name, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `name` | `string` | `-` | The `name` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<TEntity?>` | Returns a `Task<TEntity?>` value. |

## Example

No concise standalone example is available yet.

