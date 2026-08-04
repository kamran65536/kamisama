# GetAll<TEntity>

[Back to RepositoriesExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Core](../../index.md)

Source: [src/Repositories.Core/RepositoriesExtensions.cs:28](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Core/RepositoriesExtensions.cs#L28)

Type: `KamiSama.Repositories.RepositoriesExtensions`

Kind: `Method`

## Description

Returns all Items in the repository. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static IQueryable<TEntity> GetAll<TEntity>(this IQueryableRepository<TEntity> repository);
```

## Type Parameters

| Name | Description |
| --- | --- |
| `TEntity` |  |

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `repository (extension receiver)` | `IQueryableRepository<TEntity>` | `-` | The `repository` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `IQueryable<TEntity>` | Returns a `IQueryable<TEntity>` value. |

## Example

```csharp
using KamiSama.Repositories;

var all = repository.GetAll().ToList();
```

