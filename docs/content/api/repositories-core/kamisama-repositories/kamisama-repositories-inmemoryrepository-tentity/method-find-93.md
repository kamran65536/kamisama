# Find

[Back to InMemoryRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Core](../../index.md)

Source: [src/Repositories.Core/InMemoryRepository.cs:93](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Core/InMemoryRepository.cs#L93)

Type: `KamiSama.Repositories.InMemoryRepository<TEntity>`

Kind: `Method`

## Description

Returns the first in-memory entity matching the compiled predicate, or the default value when no predicate or match is available.

## Declaration

```csharp
public virtual TEntity? Find(Expression<Func<TEntity, bool>>? predicate);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `predicate` | `Expression<Func<TEntity, bool>>?` | `-` | The predicate to compile and apply. |

## Returns

| Type | Description |
| --- | --- |
| `TEntity?` | The first matching entity, or the default value for &lt;typeparamref name=&quot;TEntity&quot;/&gt;. |

## Example

No concise standalone example is available yet.

