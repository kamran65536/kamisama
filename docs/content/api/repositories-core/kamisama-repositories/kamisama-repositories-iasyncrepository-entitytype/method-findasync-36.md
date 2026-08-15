# FindAsync

[Back to IAsyncRepository<_EntityType>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Core](../../index.md)

Source: [src/Repositories.Core/IAsyncRepository.cs:36](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Core/IAsyncRepository.cs#L36)

Type: `KamiSama.Repositories.IAsyncRepository<_EntityType>`

Kind: `Method`

## Description

Asynchronously returns the first entity matching the predicate, or `null` when none matches.

## Declaration

```csharp
Task<_EntityType?> FindAsync(Expression<Func<_EntityType, bool>> predicate, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `predicate` | `Expression<Func<_EntityType, bool>>` | `-` | The predicate used to select an entity. |
| `cancellationToken` | `CancellationToken` | `-` | A token that can cancel the operation. |

## Returns

| Type | Description |
| --- | --- |
| `Task<_EntityType?>` | A task containing the first matching entity, or . |

## Example

```csharp
User? user = await repository.FindAsync(x => x.Id == userId, cancellationToken);
```

