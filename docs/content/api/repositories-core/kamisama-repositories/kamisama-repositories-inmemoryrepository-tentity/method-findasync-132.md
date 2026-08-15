# FindAsync

[Back to InMemoryRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Core](../../index.md)

Source: [src/Repositories.Core/InMemoryRepository.cs:132](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Core/InMemoryRepository.cs#L132)

Type: `KamiSama.Repositories.InMemoryRepository<TEntity>`

Kind: `Method`

## Description

Returns the first in-memory entity matching the compiled predicate, or the default value when no predicate or match is available.

## Declaration

```csharp
public virtual Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>>? predicate, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `predicate` | `Expression<Func<TEntity, bool>>?` | `-` | The predicate to compile and apply, or to return the default value. |
| `cancellationToken` | `CancellationToken` | `-` | A token that is not observed because the lookup runs synchronously. |

## Returns

| Type | Description |
| --- | --- |
| `Task<TEntity?>` | A task containing the first matching entity, or the default value for &lt;typeparamref name=&quot;TEntity&quot;/&gt;. |

## Example

No concise standalone example is available yet.

