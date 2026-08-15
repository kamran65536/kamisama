# DbRepository<TEntity, TDbContext>

<a id="dbrepository-tentity-tdbcontext"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Repositories.EntityFramework](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Repositories.EntityFramework/DbRepository.cs:145](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFramework/DbRepository.cs#L145)

Namespace: `KamiSama.Repositories.EntityFramework`

Kind: `Class`

## Description

EF6 repository over a borrowed `DbContext`. Queries track by default, every mutation saves immediately, and repository disposal does not dispose the context.

## Declaration

```csharp
public class DbRepository<TEntity, TDbContext>(TDbContext context) : DbRepository<TEntity>(context)
	where TDbContext : DbContext
	where TEntity : class
```

## Remarks

Mutations save immediately, queries track by default, and disposal does not dispose the supplied context.

## Example

```csharp
using KamiSama.Repositories.EntityFramework;

public sealed class UserRepository(AppDbContext context)
    : DbRepository<User, AppDbContext>(context)
{
    public IQueryable<User> Active() => Context.Users.Where(user => user.IsActive);
}
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFramework/DbRepository.cs#L145)

Exposes a strongly typed protected context while retaining the EF6 repository behavior. Use it with the surrounding package APIs when composing application code.

```csharp
public class DbRepository<TEntity, TDbContext>(TDbContext context) : DbRepository<TEntity>(context)
	where TDbContext : DbContext
	where TEntity : class
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `context` | `TDbContext` | `-` | The concrete context that owns the entity set and its lifetime. |

## Members

### Properties

| Member | Description |
| --- | --- |
| [Context](property-context-154.md) | Gets the borrowed context as &lt;typeparamref name=&quot;TDbContext&quot;/&gt; for derived repositories. Use it with the surrounding package APIs when composing application code. |

