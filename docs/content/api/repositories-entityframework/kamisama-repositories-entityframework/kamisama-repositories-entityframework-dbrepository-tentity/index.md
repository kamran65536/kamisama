# DbRepository<TEntity>

<a id="dbrepository-tentity"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Repositories.EntityFramework](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Repositories.EntityFramework/DbRepository.cs:16](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFramework/DbRepository.cs#L16)

Namespace: `KamiSama.Repositories.EntityFramework`

Kind: `Class`

## Description

EF6 repository over a borrowed `DbContext`. Queries track by default, every mutation saves immediately, and repository disposal does not dispose the context.

## Declaration

```csharp
public class DbRepository<TEntity>(DbContext context) : IQueryableRepository<TEntity>, IAsyncQueryableRepository<TEntity>
	where TEntity : class
```

## Remarks

Every mutation immediately calls `DbContext.SaveChanges()` or `DbContext.SaveChangesAsync(CancellationToken)`. Queries use EF6&apos;s default tracking behavior. The repository borrows the supplied context and does not dispose it.

## Example

```csharp
using KamiSama.Repositories.EntityFramework;

var repository = new DbRepository<User>(dbContext);
await repository.AddAsync(new User { Name = "Ada" }, cancellationToken);
User? user = await repository.FindAsync(x => x.Id == userId, cancellationToken);
// The repository saves immediately and does not own dbContext.
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFramework/DbRepository.cs#L16)

Implements synchronous and asynchronous repository operations over an Entity Framework 6 `DbSet{TEntity}`. Use it with the surrounding package APIs when composing application code.

```csharp
public class DbRepository<TEntity>(DbContext context) : IQueryableRepository<TEntity>, IAsyncQueryableRepository<TEntity>
	where TEntity : class
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `context` | `DbContext` | `-` | The context that owns the entity set and its lifetime. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [Add](method-add-38.md) | Adds an entity to the set and immediately saves the context. Use it with the surrounding package APIs when composing application code. |
| [AddAsync](method-addasync-31.md) | Adds an entity to the set and immediately saves the context asynchronously. Use it with the surrounding package APIs when composing application code. |
| [Any](method-any-105.md) | Determines synchronously whether any entity matches a predicate. Use it with the surrounding package APIs when composing application code. |
| [AnyAsync](method-anyasync-113.md) | Determines asynchronously whether any entity matches a predicate. Use it with the surrounding package APIs when composing application code. |
| [AsQueryable](method-asqueryable-91.md) | Returns the tracked entity set as a deferred query. Use it with the surrounding package APIs when composing application code. |
| [Delete](method-delete-73.md) | Marks an entity for deletion and immediately saves the context. Use it with the surrounding package APIs when composing application code. |
| [DeleteAsync](method-deleteasync-82.md) | Marks an entity for deletion and immediately saves the context asynchronously. Use it with the surrounding package APIs when composing application code. |
| [Find](method-find-120.md) | Returns the first tracked entity matching a predicate. Use it with the surrounding package APIs when composing application code. |
| [FindAsync](method-findasync-126.md) | Asynchronously returns the first tracked entity matching a predicate. Use it with the surrounding package APIs when composing application code. |
| [Update](method-update-47.md) | Marks an entity as modified and immediately saves the context. Use it with the surrounding package APIs when composing application code. |
| [UpdateAsync](method-updateasync-60.md) | Marks an entity as modified and immediately saves the context asynchronously. Use it with the surrounding package APIs when composing application code. |
| [Where](method-where-98.md) | Creates a tracked, deferred query filtered by a predicate. Use it with the surrounding package APIs when composing application code. |

### Properties

| Member | Description |
| --- | --- |
| [Context](property-context-24.md) | Gets the borrowed context used for queries and persistence. Use it with the surrounding package APIs when composing application code. |

