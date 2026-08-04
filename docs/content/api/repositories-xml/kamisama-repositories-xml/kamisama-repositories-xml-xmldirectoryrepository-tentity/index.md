# XmlDirectoryRepository<TEntity>

<a id="xmldirectoryrepository-tentity"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Repositories.Xml](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Repositories.Xml/XmlDirectoryRepository.cs:24](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Xml/XmlDirectoryRepository.cs#L24)

Namespace: `KamiSama.Repositories.Xml`

Kind: `Class`

## Description

Repository implementation or contract for `XmlDirectoryRepository<TEntity>`. Use it behind feature services to keep persistence access behind the KamiSama repository abstraction.

## Declaration

```csharp
public class XmlDirectoryRepository<TEntity>(string filePath,
							Func<TEntity, string> fileNameFunc,
							XmlSerializer? serializer = null,
							IEqualityComparer<TEntity>? equalityComparer = null) : IQueryableRepository<TEntity>, IAsyncQueryableRepository<TEntity>
```

## Remarks

constructor

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Xml/XmlDirectoryRepository.cs#L24)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
public class XmlDirectoryRepository<TEntity>(string filePath,
							Func<TEntity, string> fileNameFunc,
							XmlSerializer? serializer = null,
							IEqualityComparer<TEntity>? equalityComparer = null) : IQueryableRepository<TEntity>, IAsyncQueryableRepository<TEntity>
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `filePath` | `string` | `-` | path to json file as repository |
| `fileNameFunc` | `Func<TEntity, string>` | `-` | The `fileNameFunc` value passed to this member. |
| `serializer` | `XmlSerializer?` | `null` | The `serializer` value passed to this member. |
| `equalityComparer` | `IEqualityComparer<TEntity>?` | `null` | The `equalityComparer` value passed to this member. |

## Members

### Events

| Member | Description |
| --- | --- |
| [LoadFailed](event-loadfailed-36.md) | raised when loading items from file fails. Use it with the surrounding package APIs when composing application code. |
| [SaveFailed](event-savefailed-40.md) | raised when saving items to file fails. Use it with the surrounding package APIs when composing application code. |

### Fields

| Member | Description |
| --- | --- |
| [entities](field-entities-48.md) | internal entities collection. Use it with the surrounding package APIs when composing application code. |

### Methods

| Member | Description |
| --- | --- |
| [Add](method-add-191.md) | Runs the `Add` operation on `XmlDirectoryRepository<TEntity>`. Use it when your code needs this specific behavior from the package. |
| [AddAsync](method-addasync-159.md) | Runs the `AddAsync` operation on `XmlDirectoryRepository<TEntity>`. Use it when your code needs this specific behavior from the package. |
| [Delete](method-delete-195.md) | Runs the `Delete` operation on `XmlDirectoryRepository<TEntity>`. Use it when your code needs this specific behavior from the package. |
| [DeleteAsync](method-deleteasync-162.md) | Runs the `DeleteAsync` operation on `XmlDirectoryRepository<TEntity>`. Use it when your code needs this specific behavior from the package. |
| [Find](method-find-197.md) | Runs the `Find` operation on `XmlDirectoryRepository<TEntity>`. Use it when your code needs this specific behavior from the package. |
| [FindAsync](method-findasync-168.md) | Runs the `FindAsync` operation on `XmlDirectoryRepository<TEntity>`. Use it when your code needs this specific behavior from the package. |
| [TryLoadFileAsync](method-tryloadfileasync-70.md) | loads the json file if not loaded already. Use it with the surrounding package APIs when composing application code. |
| [Update](method-update-193.md) | Runs the `Update` operation on `XmlDirectoryRepository<TEntity>`. Use it when your code needs this specific behavior from the package. |
| [UpdateAsync](method-updateasync-165.md) | Runs the `UpdateAsync` operation on `XmlDirectoryRepository<TEntity>`. Use it when your code needs this specific behavior from the package. |
| [Where](method-where-188.md) | Runs the `Where` operation on `XmlDirectoryRepository<TEntity>`. Use it when your code needs this specific behavior from the package. |
| [WhereAsync](method-whereasync-178.md) | Runs the `WhereAsync` operation on `XmlDirectoryRepository<TEntity>`. Use it when your code needs this specific behavior from the package. |

