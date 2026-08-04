# XmlFileRepository<TEntity>

<a id="xmlfilerepository-tentity"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Repositories.Xml](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Repositories.Xml/XmlFileRepository.cs:24](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Xml/XmlFileRepository.cs#L24)

Namespace: `KamiSama.Repositories.Xml`

Kind: `Class`

## Description

Repository implementation or contract for `XmlFileRepository<TEntity>`. Use it behind feature services to keep persistence access behind the KamiSama repository abstraction.

## Declaration

```csharp
public class XmlFileRepository<TEntity>(string filePath,
						   Func<TEntity, string> fileNameFunc,
						   XmlSerializer? serializer = null,
						   IEqualityComparer<TEntity>? equalityComparer = null) : IQueryableRepository<TEntity>, IAsyncQueryableRepository<TEntity>
```

## Remarks

constructor

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Xml/XmlFileRepository.cs#L24)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
public class XmlFileRepository<TEntity>(string filePath,
						   Func<TEntity, string> fileNameFunc,
						   XmlSerializer? serializer = null,
						   IEqualityComparer<TEntity>? equalityComparer = null) : IQueryableRepository<TEntity>, IAsyncQueryableRepository<TEntity>
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `filePath` | `string` | `-` | path to json file as repository |
| `fileNameFunc` | `Func<TEntity, string>` | `-` | function to map entity to file name |
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
| [Add](method-add-190.md) | Runs the `Add` operation on `XmlFileRepository<TEntity>`. Use it when your code needs this specific behavior from the package. |
| [AddAsync](method-addasync-158.md) | Runs the `AddAsync` operation on `XmlFileRepository<TEntity>`. Use it when your code needs this specific behavior from the package. |
| [Delete](method-delete-194.md) | Runs the `Delete` operation on `XmlFileRepository<TEntity>`. Use it when your code needs this specific behavior from the package. |
| [DeleteAsync](method-deleteasync-161.md) | Runs the `DeleteAsync` operation on `XmlFileRepository<TEntity>`. Use it when your code needs this specific behavior from the package. |
| [Find](method-find-196.md) | Runs the `Find` operation on `XmlFileRepository<TEntity>`. Use it when your code needs this specific behavior from the package. |
| [FindAsync](method-findasync-167.md) | Runs the `FindAsync` operation on `XmlFileRepository<TEntity>`. Use it when your code needs this specific behavior from the package. |
| [TryLoadFileAsync](method-tryloadfileasync-70.md) | loads the json file if not loaded already. Use it with the surrounding package APIs when composing application code. |
| [Update](method-update-192.md) | Runs the `Update` operation on `XmlFileRepository<TEntity>`. Use it when your code needs this specific behavior from the package. |
| [UpdateAsync](method-updateasync-164.md) | Runs the `UpdateAsync` operation on `XmlFileRepository<TEntity>`. Use it when your code needs this specific behavior from the package. |
| [Where](method-where-187.md) | Runs the `Where` operation on `XmlFileRepository<TEntity>`. Use it when your code needs this specific behavior from the package. |
| [WhereAsync](method-whereasync-177.md) | Runs the `WhereAsync` operation on `XmlFileRepository<TEntity>`. Use it when your code needs this specific behavior from the package. |

