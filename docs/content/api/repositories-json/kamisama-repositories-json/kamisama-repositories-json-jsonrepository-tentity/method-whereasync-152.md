# WhereAsync

[Back to JsonRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Json](../../index.md)

Source: [src/Repositories.Json/JsonRepository.cs:152](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Json/JsonRepository.cs#L152)

Type: `KamiSama.Repositories.Json.JsonRepository<TEntity>`

Kind: `Method`

## Description

Runs the `WhereAsync` operation on `JsonRepository<TEntity>`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
public async Task<IQueryable<TEntity>> WhereAsync(Expression<Func<TEntity, bool>>? predicate, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `predicate` | `Expression<Func<TEntity, bool>>?` | `-` | The `predicate` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<IQueryable<TEntity>>` | Returns a `Task<IQueryable<TEntity>>` value. |

## Example

No concise standalone example is available yet.

