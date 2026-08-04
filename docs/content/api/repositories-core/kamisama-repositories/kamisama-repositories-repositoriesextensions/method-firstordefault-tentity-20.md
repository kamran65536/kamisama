# FirstOrDefault<TEntity>

[Back to RepositoriesExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Core](../../index.md)

Source: [src/Repositories.Core/RepositoriesExtensions.cs:20](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Core/RepositoriesExtensions.cs#L20)

Type: `KamiSama.Repositories.RepositoriesExtensions`

Kind: `Method`

## Description

Returns first or default item for IQueryableRepository. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static TEntity? FirstOrDefault<TEntity>(this IQueryableRepository<TEntity> repository, Expression<Func<TEntity, bool>> predicate);
```

## Type Parameters

| Name | Description |
| --- | --- |
| `TEntity` |  |

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `repository (extension receiver)` | `IQueryableRepository<TEntity>` | `-` | The `repository` value passed to this member. |
| `predicate` | `Expression<Func<TEntity, bool>>` | `-` | The `predicate` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `TEntity?` | Returns a `TEntity?` value. |

## Remarks

if you want to search on IRepository, you can also use Find method

## Example

```csharp
var services = new ServiceCollection();
services.AutoAddDependenciesFrom<ISampleInterface>();

var descriptor = services.FirstOrDefault(x => x.ServiceType == typeof(ISampleInterface));
```

