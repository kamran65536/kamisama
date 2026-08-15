# XmlFileRepository<TEntity>

<a id="xmlfilerepository-tentity"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Repositories.Xml](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Repositories.Xml/XmlFileRepository.cs:26](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Xml/XmlFileRepository.cs#L26)

Namespace: `KamiSama.Repositories.Xml`

Kind: `Class`

## Description

Loads one XML entity per file from a directory for read-oriented access. In version 10.0.0 the default serializer cannot read the per-entity files and mutation writes to the directory path rather than mapped files, so pass a per-entity serializer and do not rely on add, update, or delete for persistence.

## Declaration

```csharp
public class XmlFileRepository<TEntity>(string filePath,
						   Func<TEntity, string> fileNameFunc,
						   XmlSerializer? serializer = null,
						   IEqualityComparer<TEntity>? equalityComparer = null) : IQueryableRepository<TEntity>, IAsyncQueryableRepository<TEntity>
```

## Remarks

In version 10.0.0, the default array serializer is incompatible with per-entity reads, so pass an `XmlSerializer` for &lt;typeparamref name=&quot;TEntity&quot;/&gt;. Mutation is not durable: the save path writes serialized entities to the directory path instead of mapped file paths, does not use the supplied serializer, and never deletes stale files. Add, update, and delete must not be used for XML persistence. Load and save failures are reported through events and otherwise suppressed. Duplicate semantics follow the configured comparer, and synchronization is limited to one repository instance.

## Example

```csharp
using System.Xml.Serialization;
using KamiSama.Repositories.Xml;

var serializer = new XmlSerializer(typeof(User));
using var fileRepository = new XmlFileRepository<User>(
    "data/users", user => $"{user.Id}.xml", serializer, UserIdComparer.Instance);

User? user = await fileRepository.FindAsync(x => x.Id == userId, cancellationToken);
// Read only: version 10.0.0 cannot durably add, update, or delete XML files.
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Xml/XmlFileRepository.cs#L26)

Provides read-oriented access to one XML entity per file in a directory. Use it with the surrounding package APIs when composing application code.

```csharp
public class XmlFileRepository<TEntity>(string filePath,
						   Func<TEntity, string> fileNameFunc,
						   XmlSerializer? serializer = null,
						   IEqualityComparer<TEntity>? equalityComparer = null) : IQueryableRepository<TEntity>, IAsyncQueryableRepository<TEntity>
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `filePath` | `string` | `-` | The directory containing one XML file per entity. |
| `fileNameFunc` | `Func<TEntity, string>` | `-` | A function that returns the exact file name expected for a deserialized entity. |
| `serializer` | `XmlSerializer?` | `null` | A serializer for one &lt;typeparamref name=&quot;TEntity&quot;/&gt;. The default serializer targets an array and cannot read the per-entity files. |
| `equalityComparer` | `IEqualityComparer<TEntity>?` | `null` | The comparer used to collapse equal entities loaded from different files, or to use the default comparer. |

## Members

### Events

| Member | Description |
| --- | --- |
| [LoadFailed](event-loadfailed-39.md) | Raised when directory enumeration, per-entity deserialization, or exact file-name validation fails. One bad file fails the complete load. |
| [SaveFailed](event-savefailed-44.md) | Raised after the broken mutation path attempts to write serialized entities to the directory path. In-memory changes are not rolled back. |

### Methods

| Member | Description |
| --- | --- |
| [Add](method-add-222.md) | Changes the in-memory set but cannot durably create a mapped XML entity file in version 10.0.0; the save path writes to the directory path. |
| [AddAsync](method-addasync-172.md) | Changes the in-memory set but cannot durably create a mapped XML entity file in version 10.0.0; the save path writes to the directory path. |
| [Delete](method-delete-228.md) | Changes the in-memory set but does not delete the mapped XML file in version 10.0.0, including when the final cached entity is removed. |
| [DeleteAsync](method-deleteasync-179.md) | Changes the in-memory set but does not delete the mapped XML file in version 10.0.0, including when the final cached entity is removed. |
| [Find](method-find-232.md) | Loads on demand and returns the first matching cached entity, or the default value after a load failure, a null predicate, or no match. |
| [FindAsync](method-findasync-192.md) | Loads on demand and returns the first matching cached entity, or the default value after a load failure, a null predicate, or no match. |
| [TryLoadFileAsync](method-tryloadfileasync-80.md) | Loads all `*.xml` files as individual entities and validates mapped names. The version 10.0.0 default array serializer cannot perform these per-entity reads, and equal entities are silently collapsed. |
| [Update](method-update-225.md) | Ignores the supplied entity and cannot durably update XML in version 10.0.0; saving also ignores the supplied serializer. |
| [UpdateAsync](method-updateasync-186.md) | Ignores the supplied entity and cannot durably update XML in version 10.0.0; saving also ignores the supplied serializer. |
| [Where](method-where-218.md) | Loads on demand and returns a live query over the cached set, or an empty query after load failure. Enumeration is not synchronized with mutations. |
| [WhereAsync](method-whereasync-206.md) | Loads on demand and returns a live query over the cached set, or an empty query after load failure. Enumeration is not synchronized with mutations. |

