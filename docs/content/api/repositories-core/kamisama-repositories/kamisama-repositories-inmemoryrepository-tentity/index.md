# InMemoryRepository<TEntity>

<a id="inmemoryrepository-tentity"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Repositories.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Repositories.Core/InMemoryRepository.cs:11](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Core/InMemoryRepository.cs#L11)

Namespace: `KamiSama.Repositories`

Kind: `Class`

## Description

The internal memory repository, this class can be used for testing The class operations are thread safe. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public class InMemoryRepository<TEntity> : IQueryableRepository<TEntity>, IAsyncQueryableRepository<TEntity>
```

## Constructors

### InMemoryRepository

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Core/InMemoryRepository.cs#L23)

Constructor with initial items. Use it with the surrounding package APIs when composing application code.

```csharp
public InMemoryRepository(IEnumerable<TEntity>? initialItems, IEqualityComparer<TEntity>? comparer = null);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `initialItems` | `IEnumerable<TEntity>?` | `-` | The `initialItems` value passed to this member. |
| `comparer` | `IEqualityComparer<TEntity>?` | `null` | The `comparer` value passed to this member. |

### InMemoryRepository

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Core/InMemoryRepository.cs#L37)

Constructor with no parameter (generally used for dependency injection). Use it with the surrounding package APIs when composing application code.

```csharp
public InMemoryRepository() : this(initialItems: null, comparer: null);
```

## Parameters

This member does not declare parameters.

## Members

### Methods

| Member | Description |
| --- | --- |
| [Add](method-add-54.md) | Adds a new item in the repository. Use it with the surrounding package APIs when composing application code. |
| [AddAsync](method-addasync-92.md) | Runs the `AddAsync` operation on `InMemoryRepository<TEntity>`. Use it when your code needs this specific behavior from the package. |
| [Delete](method-delete-71.md) | Deletes an item from repository. Use it with the surrounding package APIs when composing application code. |
| [DeleteAsync](method-deleteasync-101.md) | Runs the `DeleteAsync` operation on `InMemoryRepository<TEntity>`. Use it when your code needs this specific behavior from the package. |
| [Find](method-find-89.md) | Finds an single item in the repository. Use it with the surrounding package APIs when composing application code. |
| [FindAsync](method-findasync-108.md) | Runs the `FindAsync` operation on `InMemoryRepository<TEntity>`. Use it when your code needs this specific behavior from the package. |
| [Update](method-update-64.md) | Update method, does nothing. Use it with the surrounding package APIs when composing application code. |
| [UpdateAsync](method-updateasync-99.md) | Runs the `UpdateAsync` operation on `InMemoryRepository<TEntity>`. Use it when your code needs this specific behavior from the package. |
| [Where](method-where-82.md) | Queries items in repository for the predicate specified. Use it with the surrounding package APIs when composing application code. |

