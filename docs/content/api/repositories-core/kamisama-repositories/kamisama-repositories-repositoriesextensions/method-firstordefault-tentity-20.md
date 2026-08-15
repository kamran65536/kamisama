# FirstOrDefault<TEntity>

[Back to RepositoriesExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Core](../../index.md)

Source: [src/Repositories.Core/RepositoriesExtensions.cs:20](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Core/RepositoriesExtensions.cs#L20)

Type: `KamiSama.Repositories.RepositoriesExtensions`

Kind: `Method`

## Description

Delegates filtering to the repository's `Where` method and returns the first result or the default value.

## Declaration

```csharp
public static TEntity? FirstOrDefault<TEntity>(this IQueryableRepository<TEntity> repository, Expression<Func<TEntity, bool>> predicate);
```

## Type Parameters

| Name | Description |
| --- | --- |
| `TEntity` | The entity type exposed by the repository. |

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `repository (extension receiver)` | `IQueryableRepository<TEntity>` | `-` | The queryable repository to search. |
| `predicate` | `Expression<Func<TEntity, bool>>` | `-` | The predicate used to select an entity. |

## Returns

| Type | Description |
| --- | --- |
| `TEntity?` | The first matching entity, or the default value for &lt;typeparamref name=&quot;TEntity&quot;/&gt;. |

## Remarks

This delegates filtering to `IQueryableRepository{TEntity}.Where` and then applies LINQ `FirstOrDefault`.

## Example

```csharp
using KamiSama.Repositories;

User? admin = repository.FirstOrDefault(user => user.IsAdmin);
```

