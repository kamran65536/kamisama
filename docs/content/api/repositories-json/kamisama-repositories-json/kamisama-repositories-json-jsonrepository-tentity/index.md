# JsonRepository<TEntity>

<a id="jsonrepository-tentity"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Repositories.Json](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Repositories.Json/JsonRepository.cs:23](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Json/JsonRepository.cs#L23)

Namespace: `KamiSama.Repositories.Json`

Kind: `Class`

## Description

Lazily reads an existing JSON array into a `HashSet<TEntity>` and rewrites the complete file after mutations. Writes are non-atomic, update only persists prior in-memory changes, failures are event-reported and suppressed, and locking does not coordinate live queries or other instances.

## Declaration

```csharp
public class JsonRepository<TEntity>(string filePath,
					IEqualityComparer<TEntity>? equalityComparer = null) : IQueryableRepository<TEntity>, IAsyncQueryableRepository<TEntity>
```

## Remarks

The file must already exist and contain valid JSON before queries or mutations can succeed. Duplicate semantics follow the configured comparer. Writes are non-atomic, update only rewrites the current set, and load or save failures are reported through events instead of being returned or rethrown. Synchronization is per instance and protects loading and mutation only; returned queries are live and multiple instances or processes can overwrite each other&apos;s changes.

## Example

```csharp
using KamiSama.Repositories.Json;

using var repository = new JsonRepository<User>("data/users.json", UserIdComparer.Instance);
repository.LoadFailed += (_, error) => logger.LogError(error, "Could not load users");
repository.SaveFailed += (_, error) => logger.LogError(error, "Could not save users");

User? user = await repository.FindAsync(x => x.Id == userId, cancellationToken);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Json/JsonRepository.cs#L23)

Lazily loads a JSON array into an in-memory set and rewrites the complete file after mutations. Use it with the surrounding package APIs when composing application code.

```csharp
public class JsonRepository<TEntity>(string filePath,
					IEqualityComparer<TEntity>? equalityComparer = null) : IQueryableRepository<TEntity>, IAsyncQueryableRepository<TEntity>
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `filePath` | `string` | `-` | The path to an existing JSON file containing an array of entities. |
| `equalityComparer` | `IEqualityComparer<TEntity>?` | `null` | The comparer that controls duplicate and removal semantics, or to use the default comparer. |

## Members

### Events

| Member | Description |
| --- | --- |
| [LoadFailed](event-loadfailed-34.md) | Raised after reading or deserializing the JSON file fails. The load otherwise returns `false` and query methods return default or empty results. |
| [SaveFailed](event-savefailed-39.md) | Raised after an in-memory mutation or non-atomic full-file write fails. The changed cache is not rolled back and the operation otherwise completes normally. |

### Methods

| Member | Description |
| --- | --- |
| [Add](method-add-196.md) | Adds according to `HashSet<TEntity>` equality and rewrites the complete JSON file. Equal duplicates are ignored, and failed writes do not roll back memory. |
| [AddAsync](method-addasync-144.md) | Adds according to `HashSet<TEntity>` equality and rewrites the complete JSON file. Equal duplicates are ignored, and failed writes do not roll back memory. |
| [Delete](method-delete-206.md) | Removes according to `HashSet<TEntity>` equality and rewrites the complete JSON file. Failed writes do not restore the removed entity. |
| [DeleteAsync](method-deleteasync-151.md) | Removes according to `HashSet<TEntity>` equality and rewrites the complete JSON file. Failed writes do not restore the removed entity. |
| [Find](method-find-212.md) | Loads on demand and returns the first matching cached entity, or the default value after a load failure, a null predicate, or no match. |
| [FindAsync](method-findasync-164.md) | Loads on demand and returns the first matching cached entity, or the default value after a load failure, a null predicate, or no match. |
| [TryLoadFileAsync](method-tryloadfileasync-64.md) | Loads an existing JSON array unless already cached, optionally discarding the cache first. Failures raise `LoadFailed` and return `false`. |
| [Update](method-update-201.md) | Ignores the supplied entity and rewrites the current set, so it only persists prior changes made to an object already cached by the repository. |
| [UpdateAsync](method-updateasync-158.md) | Ignores the supplied entity and rewrites the current set, so it only persists prior changes made to an object already cached by the repository. |
| [Where](method-where-190.md) | Loads on demand and returns a live query over the cached set, or an empty query after load failure. Enumeration is not synchronized with mutations. |
| [WhereAsync](method-whereasync-178.md) | Loads on demand and returns a live query over the cached set, or an empty query after load failure. Enumeration is not synchronized with mutations. |

