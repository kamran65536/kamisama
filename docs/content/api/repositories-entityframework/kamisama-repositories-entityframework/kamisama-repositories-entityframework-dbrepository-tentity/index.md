# DbRepository<TEntity>

<a id="dbrepository-tentity"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Repositories.EntityFramework](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Repositories.EntityFramework/DbRepository.cs:15](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFramework/DbRepository.cs#L15)

Namespace: `KamiSama.Repositories.EntityFramework`

Kind: `Class`

## Description

Repository wrapper around an EF DbContext. Use it when you want the standard KamiSama repository methods over a DbSet without writing the same CRUD code in each repository.

## Declaration

```csharp
public class DbRepository<TEntity>(DbContext context) : IQueryableRepository<TEntity>, IAsyncQueryableRepository<TEntity>
	where TEntity : class
```

## Remarks

initiates an db repository

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFramework/DbRepository.cs#L15)

Database Repository for entity framework. Use it with the surrounding package APIs when composing application code.

```csharp
public class DbRepository<TEntity>(DbContext context) : IQueryableRepository<TEntity>, IAsyncQueryableRepository<TEntity>
	where TEntity : class
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `context` | `DbContext` | `-` | The `context` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [Add](method-add-32.md) | Runs the `Add` operation on `DbRepository<TEntity>`. Use it when your code needs this specific behavior from the package. |
| [AddAsync](method-addasync-26.md) | Runs the `AddAsync` operation on `DbRepository<TEntity>`. Use it when your code needs this specific behavior from the package. |
| [Any](method-any-94.md) | Checks if any entity exists in the repository. Use it with the surrounding package APIs when composing application code. |
| [AnyAsync](method-anyasync-100.md) | Checks if any entity exists in the repository. Use it with the surrounding package APIs when composing application code. |
| [AsQueryable](method-asqueryable-81.md) | Returns the db set as queryable. Use it with the surrounding package APIs when composing application code. |
| [Delete](method-delete-66.md) | Deletes an item from repository. Use it with the surrounding package APIs when composing application code. |
| [DeleteAsync](method-deleteasync-72.md) | Runs the `DeleteAsync` operation on `DbRepository<TEntity>`. Use it when your code needs this specific behavior from the package. |
| [Find](method-find-107.md) | Finds an item in the repository. Use it with the surrounding package APIs when composing application code. |
| [FindAsync](method-findasync-110.md) | Runs the `FindAsync` operation on `DbRepository<TEntity>`. Use it when your code needs this specific behavior from the package. |
| [Update](method-update-42.md) | Updates an item in the repository. Use it with the surrounding package APIs when composing application code. |
| [UpdateAsync](method-updateasync-52.md) | Runs the `UpdateAsync` operation on `DbRepository<TEntity>`. Use it when your code needs this specific behavior from the package. |
| [Where](method-where-88.md) | Queries items in repository for the predicate specified. Use it with the surrounding package APIs when composing application code. |

### Properties

| Member | Description |
| --- | --- |
| [Context](property-context-22.md) | Exposes the `Context` value on `DbRepository<TEntity>`. Read or set it as part of configuring or using the type. |

