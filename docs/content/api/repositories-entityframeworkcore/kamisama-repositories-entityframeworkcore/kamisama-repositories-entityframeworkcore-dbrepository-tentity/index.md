# DbRepository<TEntity>

<a id="dbrepository-tentity"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Repositories.EntityFrameworkCore](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Repositories.EntityFrameworkCore/DbRepository.cs:20](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFrameworkCore/DbRepository.cs#L20)

Namespace: `KamiSama.Repositories.EntityFrameworkCore`

Kind: `Class`

## Description

EF Core repository over a borrowed `DbContext`. Queries track by default, every mutation saves immediately, and repository disposal does not dispose the context.

## Declaration

```csharp
public class DbRepository<TEntity>(DbContext context) : IQueryableRepository<TEntity>, IAsyncQueryableRepository<TEntity>
		where TEntity : class
```

## Remarks

Every mutation immediately calls `DbContext.SaveChanges()` or `DbContext.SaveChangesAsync(CancellationToken)`. Queries use EF Core&apos;s default tracking behavior. The repository borrows the supplied context and does not dispose it.

## Example

```csharp
using KamiSama.Repositories.EntityFrameworkCore;

var repository = new DbRepository<User>(dbContext);
await repository.AddAsync(new User { Name = "Ada" }, cancellationToken);
User? user = await repository.FindAsync(x => x.Id == userId, cancellationToken);
// The repository saves immediately and does not own dbContext.
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFrameworkCore/DbRepository.cs#L20)

Implements synchronous and asynchronous repository operations over an EF Core `DbSet{TEntity}`. Use it with the surrounding package APIs when composing application code.

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
| [Add](method-add-42.md) | Adds an entity to the set and immediately saves the context. Use it with the surrounding package APIs when composing application code. |
| [AddAsync](method-addasync-35.md) | Adds an entity to the set and immediately saves the context asynchronously. Use it with the surrounding package APIs when composing application code. |
| [Any](method-any-103.md) | Determines synchronously whether any entity matches a predicate. Use it with the surrounding package APIs when composing application code. |
| [AnyAsync](method-anyasync-111.md) | Determines asynchronously whether any entity matches a predicate. Use it with the surrounding package APIs when composing application code. |
| [AsQueryable](method-asqueryable-91.md) | Returns the tracked entity set as a deferred query. Use it with the surrounding package APIs when composing application code. |
| [Delete](method-delete-73.md) | Marks an entity for deletion and immediately saves the context. Use it with the surrounding package APIs when composing application code. |
| [DeleteAsync](method-deleteasync-82.md) | Marks an entity for deletion and immediately saves the context asynchronously. Use it with the surrounding package APIs when composing application code. |
| [Dispose](method-dispose-128.md) | Releases no resources because the repository does not own the injected context. Use it with the surrounding package APIs when composing application code. |
| [Find](method-find-116.md) | Returns the first tracked entity matching a predicate. Use it with the surrounding package APIs when composing application code. |
| [FindAsync](method-findasync-122.md) | Asynchronously returns the first tracked entity matching a predicate. Use it with the surrounding package APIs when composing application code. |
| [Update](method-update-49.md) | Marks an entity as modified and immediately saves the context. Use it with the surrounding package APIs when composing application code. |
| [UpdateAsync](method-updateasync-62.md) | Marks an entity as modified and immediately saves the context asynchronously. Use it with the surrounding package APIs when composing application code. |
| [Where](method-where-96.md) | Creates a tracked, deferred query filtered by a predicate. Use it with the surrounding package APIs when composing application code. |

### Properties

| Member | Description |
| --- | --- |
| [Context](property-context-28.md) | Gets the borrowed context used for queries and persistence. Use it with the surrounding package APIs when composing application code. |

