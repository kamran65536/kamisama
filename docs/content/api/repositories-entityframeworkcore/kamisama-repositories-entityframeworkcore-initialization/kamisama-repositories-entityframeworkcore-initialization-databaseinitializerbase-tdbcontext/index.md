# DatabaseInitializerBase<TDbContext>

<a id="databaseinitializerbase-tdbcontext"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Repositories.EntityFrameworkCore](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Repositories.EntityFrameworkCore/Initialization/DatabaseInitializerBase.cs:14](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFrameworkCore/Initialization/DatabaseInitializerBase.cs#L14)

Namespace: `KamiSama.Repositories.EntityFrameworkCore.Initialization`

Kind: `Class`

## Description

Runs selected migration, application-data, and test-data stages sequentially for an EF Core context. Derived initializers implement both seed hooks and can use `TryAdd` for immediate conditional persistence.

## Declaration

```csharp
public abstract class DatabaseInitializerBase<TDbContext>(TDbContext context) : IDatabaseInitializer<TDbContext>
    where TDbContext : DbContext
```

## Remarks

Selected stages run sequentially in migration, application-data, then test-data order.

## Example

```csharp
using KamiSama.Repositories.EntityFrameworkCore.Initialization;

public sealed class AppDatabaseInitializer(AppDbContext context)
    : DatabaseInitializerBase<AppDbContext>(context)
{
    protected override async Task InitializeDataAsync(CancellationToken cancellationToken)
    {
        await TryAdd(user => user.Name == "Admin", new User { Name = "Admin" }, cancellationToken);
    }

    protected override Task InitializeTestDataAsync(CancellationToken cancellationToken)
        => Task.CompletedTask;
}
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFrameworkCore/Initialization/DatabaseInitializerBase.cs#L14)

Coordinates optional EF Core migration, application-data seeding, and test-data seeding for one context. Use it with the surrounding package APIs when composing application code.

```csharp
public abstract class DatabaseInitializerBase<TDbContext>(TDbContext context) : IDatabaseInitializer<TDbContext>
    where TDbContext : DbContext
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `context` | `TDbContext` | `-` | The scoped context used by migration and seed operations. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [InitializeAsync](method-initializeasync-43.md) | Runs each migration or seed stage enabled by the supplied options. Use it with the surrounding package APIs when composing application code. |
| [InitializeDataAsync](method-initializedataasync-31.md) | Creates required application data when selected by the initialization options. Use it with the surrounding package APIs when composing application code. |
| [InitializeTestDataAsync](method-initializetestdataasync-37.md) | Creates test data when selected by the initialization options. Use it with the surrounding package APIs when composing application code. |
| [MigrateAsync](method-migrateasync-24.md) | Applies all pending EF Core migrations. Use it with the surrounding package APIs when composing application code. |
| [TryAdd<TEntity>](method-tryadd-tentity-61.md) | Returns an existing matching entity or adds and immediately saves a new entity. Use it with the surrounding package APIs when composing application code. |

