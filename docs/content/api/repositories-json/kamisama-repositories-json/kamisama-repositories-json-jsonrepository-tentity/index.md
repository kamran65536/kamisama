# JsonRepository<TEntity>

<a id="jsonrepository-tentity"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Repositories.Json](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Repositories.Json/JsonRepository.cs:21](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Json/JsonRepository.cs#L21)

Namespace: `KamiSama.Repositories.Json`

Kind: `Class`

## Description

Repository implementation or contract for `JsonRepository<TEntity>`. Use it behind feature services to keep persistence access behind the KamiSama repository abstraction.

## Declaration

```csharp
public class JsonRepository<TEntity>(string filePath,
					IEqualityComparer<TEntity>? equalityComparer = null) : IQueryableRepository<TEntity>, IAsyncQueryableRepository<TEntity>
```

## Remarks

constructor

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Json/JsonRepository.cs#L21)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
public class JsonRepository<TEntity>(string filePath,
					IEqualityComparer<TEntity>? equalityComparer = null) : IQueryableRepository<TEntity>, IAsyncQueryableRepository<TEntity>
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `filePath` | `string` | `-` | path to json file as repository |
| `equalityComparer` | `IEqualityComparer<TEntity>?` | `null` | The `equalityComparer` value passed to this member. |

## Members

### Events

| Member | Description |
| --- | --- |
| [LoadFailed](event-loadfailed-31.md) | raised when loading items from file fails. Use it with the surrounding package APIs when composing application code. |
| [SaveFailed](event-savefailed-35.md) | raised when saving items to file fails. Use it with the surrounding package APIs when composing application code. |

### Fields

| Member | Description |
| --- | --- |
| [entities](field-entities-43.md) | internal entities collection. Use it with the surrounding package APIs when composing application code. |

### Methods

| Member | Description |
| --- | --- |
| [Add](method-add-168.md) | Adds a new item in the repository; Modify to json repository is not recommended for performance issues. Use it with the surrounding package APIs when composing application code. |
| [AddAsync](method-addasync-133.md) | Runs the `AddAsync` operation on `JsonRepository<TEntity>`. Use it when your code needs this specific behavior from the package. |
| [Delete](method-delete-178.md) | Deletes an item from repository; Modify to json repository is not recommended for performance issues. Use it with the surrounding package APIs when composing application code. |
| [DeleteAsync](method-deleteasync-136.md) | Runs the `DeleteAsync` operation on `JsonRepository<TEntity>`. Use it when your code needs this specific behavior from the package. |
| [Find](method-find-184.md) | Finds an single item in the repository. Use it with the surrounding package APIs when composing application code. |
| [FindAsync](method-findasync-142.md) | Runs the `FindAsync` operation on `JsonRepository<TEntity>`. Use it when your code needs this specific behavior from the package. |
| [TryLoadFileAsync](method-tryloadfileasync-57.md) | loads the json file if not loaded already. Use it with the surrounding package APIs when composing application code. |
| [Update](method-update-173.md) | Update method, updates the json file; Modify to json repository is not recommended for performance issues. Use it with the surrounding package APIs when composing application code. |
| [UpdateAsync](method-updateasync-139.md) | Runs the `UpdateAsync` operation on `JsonRepository<TEntity>`. Use it when your code needs this specific behavior from the package. |
| [Where](method-where-162.md) | Runs the `Where` operation on `JsonRepository<TEntity>`. Use it when your code needs this specific behavior from the package. |
| [WhereAsync](method-whereasync-152.md) | Runs the `WhereAsync` operation on `JsonRepository<TEntity>`. Use it when your code needs this specific behavior from the package. |

