# `KamiSama.Repositories`

## `KamiSama.Repositories`

### `IRepository<TEntity>`
Base synchronous repository contract.

### `Add(TEntity item)`
Adds an entity.

### `Update(TEntity item)`
Updates an entity.

### `Delete(TEntity item)`
Deletes an entity.

### `Find(Expression<Func<TEntity, bool>> predicate)`
Returns the first matching entity or `null`.

```csharp
using KamiSama.Repositories;

TEntity? entity = repository.Find(x => true);
```

## `KamiSama.Repositories`

### `IAsyncRepository<TEntity>`
Async counterpart to `IRepository<TEntity>`.

### `AddAsync`
Adds an entity asynchronously.

### `UpdateAsync`
Updates an entity asynchronously.

### `DeleteAsync`
Deletes an entity asynchronously.

### `FindAsync`
Finds an entity asynchronously.

```csharp
using KamiSama.Repositories;

await repository.AddAsync(entity, cancellationToken);
```

## `KamiSama.Repositories`

### `IQueryableRepository<TEntity>`
Repository that supports query predicates.

### `Where(Expression<Func<TEntity, bool>> predicate)`
Returns a queryable filtered by the predicate.

```csharp
using KamiSama.Repositories;

var query = repository.Where(x => x.IsActive);
```

## `KamiSama.Repositories`

### `IAsyncQueryableRepository<TEntity>`
Async marker over query-capable repositories. In current source it exposes `Where` like the sync interface.

### `Where(Expression<Func<TEntity, bool>> predicate)`
Returns a queryable filtered by the predicate.

```csharp
using KamiSama.Repositories;

var query = repository.Where(x => x.Id == id);
```

## `KamiSama.Repositories`

### `InMemoryRepository<TEntity>`
Thread-safe in-memory repository suitable for testing and lightweight scenarios.

### `Add`, `Update`, `Delete`, `Find`, `Where`
Implements the synchronous repository API over a `HashSet<TEntity>`.

### `AddAsync`, `UpdateAsync`, `DeleteAsync`, `FindAsync`
Async wrappers over the same in-memory store.

```csharp
using KamiSama.Repositories;

var repo = new InMemoryRepository<User>();
repo.Add(new User { Id = 1 });
```

## `KamiSama.Repositories`

### `RepositoriesExtensions`
Convenience helpers for `IQueryableRepository<TEntity>`.

### `FirstOrDefault<TEntity>(this IQueryableRepository<TEntity> repository, Expression<Func<TEntity, bool>> predicate)`
Returns the first item matching the predicate.

### `GetAll<TEntity>(this IQueryableRepository<TEntity> repository)`
Returns all items through `Where(x => true)`.

```csharp
using KamiSama.Repositories;

var all = repository.GetAll().ToList();
```

## `KamiSama.Repositories`

### `ConnectionStringOption`
DTO for binding connection string and provider settings from configuration.

No public methods.

```csharp
using KamiSama.Repositories;

var option = configuration.GetSection("database").Get<ConnectionStringOption>();
```

# `KamiSama.Repositories.Initialization`

## `KamiSama.Repositories.Initialization`

### `IDatabaseInitializer<TDbContext>`
Abstraction for migration and seed flows.

### `InitializeAsync(DataInitializationOptions options, CancellationToken cancellationToken)`
Runs database initialization logic based on the supplied options.

```csharp
using KamiSama.Repositories.Initialization;

await initializer.InitializeAsync(options, cancellationToken);
```

# `KamiSama.Repositories.EntityFramework`

## `KamiSama.Repositories.EntityFramework`

### `DbRepository<TEntity>`
Entity Framework 6 repository wrapper over `DbContext`.

### `Add`, `AddAsync`
Adds and persists an entity.

### `Update`, `UpdateAsync`
Marks the entity as modified and saves changes.

### `Delete`, `DeleteAsync`
Removes and persists an entity.

### `AsQueryable()`
Returns the underlying `DbSet<TEntity>`.

### `Where`, `Any`, `AnyAsync`, `Find`, `FindAsync`
Common query helpers.

```csharp
using KamiSama.Repositories.EntityFramework;

var repo = new DbRepository<User>(dbContext);
var exists = await repo.AnyAsync(x => x.Id == id, cancellationToken);
```

## `KamiSama.Repositories.EntityFramework`

### `DbRepository<TEntity, TDbContext>`
Typed-context version of the EF6 repository.

No additional public methods beyond the base repository.

```csharp
using KamiSama.Repositories.EntityFramework;

var repo = new DbRepository<User, MyDbContext>(dbContext);
```

## `KamiSama.Repositories.EntityFramework`

### `IOrderedQueryableExtensions`
Async paging helpers for ordered EF6 queries.

### `MakePagedAsync<T>(this IOrderedQueryable<T> query, SearchModel searchModel, CancellationToken cancellationToken)`
Builds a `PagedResult<T>` from an ordered query.

```csharp
using KamiSama.Extensions.Paging;
using KamiSama.Repositories.EntityFramework;

var page = await query.OrderBy(x => x.Id).MakePagedAsync(SearchModel.FromPage(1, 20), cancellationToken);
```

# `KamiSama.Repositories.EntityFrameworkCore`

## `KamiSama.Repositories.EntityFrameworkCore`

### `DbRepository<TEntity>`
Entity Framework Core repository wrapper over `DbContext`.

### `Add`, `AddAsync`, `Update`, `UpdateAsync`, `Delete`, `DeleteAsync`
Persisting CRUD methods.

### `AsQueryable`, `Where`, `Any`, `AnyAsync`, `Find`, `FindAsync`, `Dispose`
Query and lifetime helpers.

```csharp
using KamiSama.Repositories.EntityFrameworkCore;

var repo = new DbRepository<User>(dbContext);
var user = await repo.FindAsync(x => x.Id == id, cancellationToken);
```

## `KamiSama.Repositories.EntityFrameworkCore`

### `DbRepository<TEntity, TDbContext>`
Typed-context EF Core repository wrapper.

No additional public methods beyond the base repository.

```csharp
using KamiSama.Repositories.EntityFrameworkCore;

var repo = new DbRepository<User, MyDbContext>(dbContext);
```

## `KamiSama.Repositories.EntityFrameworkCore`

### `IQueryableExtensions`
Async paging helpers for EF Core queries.

### `MakePagedAsync<T>(this IQueryable<T> query, SearchModel searchModel, CancellationToken cancellationToken)`
Builds a `PagedResult<T>` from a query.

```csharp
using KamiSama.Extensions.Paging;
using KamiSama.Repositories.EntityFrameworkCore;

var page = await dbContext.Users.MakePagedAsync(SearchModel.FromPage(1, 10), cancellationToken);
```

## `KamiSama.Repositories.EntityFrameworkCore.Initialization`

### `DatabaseInitializerBase<TDbContext>`
Abstract EF Core database initializer with migration and seed hooks.

### `InitializeAsync(DataInitializationOptions options, CancellationToken cancellationToken)`
Runs migration, normal seed, and test seed steps conditionally.

Derived types must implement:

- `InitializeDataAsync`
- `InitializeTestDataAsync`

Protected helper:

- `TryAdd<TEntity>(Expression<Func<TEntity, bool>> predicate, TEntity entity, CancellationToken cancellationToken)`

```csharp
using KamiSama.Repositories.EntityFrameworkCore.Initialization;

public sealed class AppDbInitializer(AppDbContext context) : DatabaseInitializerBase<AppDbContext>(context)
{
    protected override Task InitializeDataAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    protected override Task InitializeTestDataAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
```

# `KamiSama.Repositories.Json`

## `KamiSama.Repositories.Json`

### `JsonRepository<TEntity>`
File-backed JSON repository that loads entities into an in-memory `HashSet<TEntity>`.

Events:

- `LoadFailed`
- `SaveFailed`

### `TryLoadFileAsync(bool forceReload, CancellationToken cancellationToken)`
Loads the JSON file on demand.

### `AddAsync`, `DeleteAsync`, `UpdateAsync`
Mutate the in-memory set and persist the file.

### `FindAsync`, `WhereAsync`
Load-on-demand query helpers.

### `Add`, `Update`, `Delete`, `Find`, `Where`
Synchronous wrappers.

```csharp
using KamiSama.Repositories.Json;

var repo = new JsonRepository<User>("users.json");
var user = await repo.FindAsync(x => x.Id == 1, cancellationToken);
```

# `KamiSama.Repositories.Xml`

## `KamiSama.Repositories.Xml`

### `XmlFileRepository<TEntity>`
XML-backed repository using a file-name mapping delegate and `XmlSerializer`.

Events:

- `LoadFailed`
- `SaveFailed`

### `TryLoadFileAsync(bool forceReload, CancellationToken cancellationToken)`
Loads entities from XML files on demand.

### `AddAsync`, `DeleteAsync`, `UpdateAsync`
Mutate the in-memory set and persist serialized XML.

### `FindAsync`, `WhereAsync`
Load-on-demand query helpers.

### `Add`, `Update`, `Delete`, `Find`, `Where`
Synchronous wrappers.

```csharp
using KamiSama.Repositories.Xml;
using System.Xml.Serialization;

var serializer = new XmlSerializer(typeof(User));
var repo = new XmlFileRepository<User>("users", u => $"{u.Id}.xml", serializer);
```

## `KamiSama.Repositories.Xml`

### `XmlDirectoryRepository<TEntity>`
Directory-based XML repository with the same public pattern as `XmlFileRepository<TEntity>`.

Events:

- `LoadFailed`
- `SaveFailed`

### `TryLoadFileAsync`, `AddAsync`, `DeleteAsync`, `UpdateAsync`, `FindAsync`, `WhereAsync`
Async load, mutate, and query methods.

### `Add`, `Update`, `Delete`, `Find`, `Where`
Synchronous wrappers.

```csharp
using KamiSama.Repositories.Xml;

var repo = new XmlDirectoryRepository<User>("users", u => $"{u.Id}.xml");
```
