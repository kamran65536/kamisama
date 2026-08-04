# DbRepository<TEntity>

<a id="dbrepository-tentity"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Repositories.EntityFrameworkCore](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Repositories.EntityFrameworkCore/DbRepository.cs:19](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFrameworkCore/DbRepository.cs#L19)

Namespace: `KamiSama.Repositories.EntityFrameworkCore`

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

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFrameworkCore/DbRepository.cs#L19)

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
| [Add](method-add-36.md) | Runs the `Add` operation on `DbRepository<TEntity>`. Use it when your code needs this specific behavior from the package. |
| [AddAsync](method-addasync-30.md) | Runs the `AddAsync` operation on `DbRepository<TEntity>`. Use it when your code needs this specific behavior from the package. |
| [Any](method-any-86.md) | Checks if any entity exists in the repository. Use it with the surrounding package APIs when composing application code. |
| [AnyAsync](method-anyasync-92.md) | Checks if any entity exists in the repository. Use it with the surrounding package APIs when composing application code. |
| [AsQueryable](method-asqueryable-77.md) | Returns the db set as queryable. Use it with the surrounding package APIs when composing application code. |
| [Delete](method-delete-62.md) | Runs the `Delete` operation on `DbRepository<TEntity>`. Use it when your code needs this specific behavior from the package. |
| [DeleteAsync](method-deleteasync-68.md) | Runs the `DeleteAsync` operation on `DbRepository<TEntity>`. Use it when your code needs this specific behavior from the package. |
| [Dispose](method-dispose-103.md) | Dispose method, does nothing. Use it with the surrounding package APIs when composing application code. |
| [Find](method-find-95.md) | Runs the `Find` operation on `DbRepository<TEntity>`. Use it when your code needs this specific behavior from the package. |
| [FindAsync](method-findasync-98.md) | Runs the `FindAsync` operation on `DbRepository<TEntity>`. Use it when your code needs this specific behavior from the package. |
| [Update](method-update-42.md) | Runs the `Update` operation on `DbRepository<TEntity>`. Use it when your code needs this specific behavior from the package. |
| [UpdateAsync](method-updateasync-52.md) | Runs the `UpdateAsync` operation on `DbRepository<TEntity>`. Use it when your code needs this specific behavior from the package. |
| [Where](method-where-80.md) | Runs the `Where` operation on `DbRepository<TEntity>`. Use it when your code needs this specific behavior from the package. |

### Properties

| Member | Description |
| --- | --- |
| [Context](property-context-26.md) | Exposes the `Context` value on `DbRepository<TEntity>`. Read or set it as part of configuring or using the type. |

