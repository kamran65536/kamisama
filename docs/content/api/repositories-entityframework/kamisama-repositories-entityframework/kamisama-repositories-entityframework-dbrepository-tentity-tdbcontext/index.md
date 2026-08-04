# DbRepository<TEntity, TDbContext>

<a id="dbrepository-tentity-tdbcontext"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Repositories.EntityFramework](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Repositories.EntityFramework/DbRepository.cs:130](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFramework/DbRepository.cs#L130)

Namespace: `KamiSama.Repositories.EntityFramework`

Kind: `Class`

## Description

Repository wrapper around an EF DbContext. Use it when you want the standard KamiSama repository methods over a DbSet without writing the same CRUD code in each repository.

## Declaration

```csharp
public class DbRepository<TEntity, TDbContext>(TDbContext context) : DbRepository<TEntity>(context)
	where TDbContext : DbContext
	where TEntity : class
```

## Remarks

constructor

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFramework/DbRepository.cs#L130)

Database Repository with context type. Use it with the surrounding package APIs when composing application code.

```csharp
public class DbRepository<TEntity, TDbContext>(TDbContext context) : DbRepository<TEntity>(context)
	where TDbContext : DbContext
	where TEntity : class
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `context` | `TDbContext` | `-` | The `context` value passed to this member. |

## Members

### Properties

| Member | Description |
| --- | --- |
| [Context](property-context-138.md) | Exposes the `Context` value on `DbRepository<TEntity, TDbContext>`. Read or set it as part of configuring or using the type. |

