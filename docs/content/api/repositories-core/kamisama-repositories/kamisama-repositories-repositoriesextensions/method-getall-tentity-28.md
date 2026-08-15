# GetAll<TEntity>

[Back to RepositoriesExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Core](../../index.md)

Source: [src/Repositories.Core/RepositoriesExtensions.cs:28](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Core/RepositoriesExtensions.cs#L28)

Type: `KamiSama.Repositories.RepositoriesExtensions`

Kind: `Method`

## Description

Returns all entities by calling the repository's `Where` method with an always-true predicate.

## Declaration

```csharp
public static IQueryable<TEntity> GetAll<TEntity>(this IQueryableRepository<TEntity> repository);
```

## Type Parameters

| Name | Description |
| --- | --- |
| `TEntity` | The entity type exposed by the repository. |

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `repository (extension receiver)` | `IQueryableRepository<TEntity>` | `-` | The queryable repository to enumerate. |

## Returns

| Type | Description |
| --- | --- |
| `IQueryable<TEntity>` | A query containing all repository entities. |

## Example

```csharp
using KamiSama.Repositories;

var all = repository.GetAll().ToList();
```

