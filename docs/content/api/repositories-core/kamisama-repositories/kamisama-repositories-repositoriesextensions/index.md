# RepositoriesExtensions

<a id="repositoriesextensions"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Repositories.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Repositories.Core/RepositoriesExtensions.cs:10](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Core/RepositoriesExtensions.cs#L10)

Namespace: `KamiSama.Repositories`

Kind: `Class`

## Description

Provides first-match and all-entity convenience queries for `IQueryableRepository<TEntity>`. Both methods delegate to the repository's `Where` implementation and preserve its query and concurrency semantics.

## Declaration

```csharp
public static class RepositoriesExtensions
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [FirstOrDefault<TEntity>](method-firstordefault-tentity-20.md) | Delegates filtering to the repository's `Where` method and returns the first result or the default value. |
| [GetAll<TEntity>](method-getall-tentity-28.md) | Returns all entities by calling the repository's `Where` method with an always-true predicate. |

