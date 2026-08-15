# InMemoryRepository<TEntity>

<a id="inmemoryrepository-tentity"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Repositories.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Repositories.Core/InMemoryRepository.cs:14](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Core/InMemoryRepository.cs#L14)

Namespace: `KamiSama.Repositories`

Kind: `Class`

## Description

Stores entities in an in-process `HashSet<TEntity>` for tests and transient scenarios. Add and delete are serialized per instance, update is a no-op, duplicate semantics follow the comparer, and reads or live queries are not synchronized with mutations.

## Declaration

```csharp
public class InMemoryRepository<TEntity> : IQueryableRepository<TEntity>, IAsyncQueryableRepository<TEntity>
```

## Remarks

Add and delete operations are serialized per repository instance, but reads and returned queries are not locked. Do not enumerate a query while another operation mutates the repository. Duplicate and removal matching follow the configured equality comparer, and update operations intentionally do nothing.

## Example

```csharp
using KamiSama.Repositories;

using var repository = new InMemoryRepository<User>(users, UserIdComparer.Instance);
repository.Add(new User { Id = 42, Name = "Ada" });

User? user = repository.Find(x => x.Id == 42);
List<User> allUsers = repository.GetAll().ToList();
```

## Constructors

### InMemoryRepository

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Core/InMemoryRepository.cs#L26)

Initializes the repository with optional entities and an optional equality comparer. Use it with the surrounding package APIs when composing application code.

```csharp
public InMemoryRepository(IEnumerable<TEntity>? initialItems, IEqualityComparer<TEntity>? comparer = null);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `initialItems` | `IEnumerable<TEntity>?` | `-` | The entities copied into the internal set, or for an empty repository. |
| `comparer` | `IEqualityComparer<TEntity>?` | `null` | The comparer that controls duplicate and removal semantics, or to use the default comparer. |

### InMemoryRepository

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Core/InMemoryRepository.cs#L40)

Initializes an empty repository using the default equality comparer. Use it with the surrounding package APIs when composing application code.

```csharp
public InMemoryRepository() : this(initialItems: null, comparer: null);
```

## Parameters

This member does not declare parameters.

## Members

### Methods

| Member | Description |
| --- | --- |
| [Add](method-add-57.md) | Adds the entity to the in-memory set unless an equal entity already exists. Mutation is serialized per instance, but concurrent reads are not locked. |
| [AddAsync](method-addasync-101.md) | Adds the entity to the in-memory set unless an equal entity already exists. Mutation is serialized per instance, but concurrent reads are not locked. |
| [Delete](method-delete-74.md) | Removes an equal entity from the in-memory set when present. Mutation is serialized per instance, but concurrent reads are not locked. |
| [DeleteAsync](method-deleteasync-120.md) | Removes an equal entity from the in-memory set when present. Mutation is serialized per instance, but concurrent reads are not locked. |
| [Find](method-find-93.md) | Returns the first in-memory entity matching the compiled predicate, or the default value when no predicate or match is available. |
| [FindAsync](method-findasync-132.md) | Returns the first in-memory entity matching the compiled predicate, or the default value when no predicate or match is available. |
| [Update](method-update-67.md) | Performs no operation; this repository does not replace or merge entities. |
| [UpdateAsync](method-updateasync-113.md) | Performs no operation; this repository does not replace or merge entities. |
| [Where](method-where-86.md) | Returns a live, unsynchronized query over the in-memory set. Do not enumerate it concurrently with add, delete, or disposal. |

