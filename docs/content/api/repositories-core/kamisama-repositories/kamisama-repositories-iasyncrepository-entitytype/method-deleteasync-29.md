# DeleteAsync

[Back to IAsyncRepository<_EntityType>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Core](../../index.md)

Source: [src/Repositories.Core/IAsyncRepository.cs:29](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Core/IAsyncRepository.cs#L29)

Type: `KamiSama.Repositories.IAsyncRepository<_EntityType>`

Kind: `Method`

## Description

Asynchronously deletes an entity according to the implementation's matching, persistence, cancellation, and failure rules.

## Declaration

```csharp
Task DeleteAsync(_EntityType item, CancellationToken cancellation);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `item` | `_EntityType` | `-` | The entity to delete. |
| `cancellation` | `CancellationToken` | `-` | A token that can cancel the operation. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | A task that represents the delete operation. |

## Example

```csharp
await repository.DeleteAsync(user, cancellationToken);
```

