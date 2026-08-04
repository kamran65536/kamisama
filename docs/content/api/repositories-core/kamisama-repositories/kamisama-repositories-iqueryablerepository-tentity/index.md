# IQueryableRepository<TEntity>

<a id="iqueryablerepository-tentity"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Repositories.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Repositories.Core/IQueryableRepository.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Core/IQueryableRepository.cs#L9)

Namespace: `KamiSama.Repositories`

Kind: `Interface`

## Description

Queryable Repository Interface, these repositories can be searched throughout. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public interface IQueryableRepository<TEntity> : IRepository<TEntity>
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [Where](method-where-16.md) | Queries items in repository for the predicate specified. Use it with the surrounding package APIs when composing application code. |

