# DatabaseInitializerBase<TDbContext>

<a id="databaseinitializerbase-tdbcontext"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Repositories.EntityFrameworkCore](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Repositories.EntityFrameworkCore/Initialization/DatabaseInitializerBase.cs:11](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFrameworkCore/Initialization/DatabaseInitializerBase.cs#L11)

Namespace: `KamiSama.Repositories.EntityFrameworkCore.Initialization`

Kind: `Class`

## Description

Base EF Core database initializer with migration and seed hooks. Derive from it to centralize production seed data and optional test seed data for one DbContext.

## Declaration

```csharp
public abstract class DatabaseInitializerBase<TDbContext>(TDbContext context) : IDatabaseInitializer<TDbContext>
    where TDbContext : DbContext
```

## Example

```csharp
using KamiSama.Repositories.EntityFrameworkCore.Initialization;

public sealed class AppDbInitializer(AppDbContext context) : DatabaseInitializerBase<AppDbContext>(context)
{
    protected override Task InitializeDataAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    protected override Task InitializeTestDataAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFrameworkCore/Initialization/DatabaseInitializerBase.cs#L11)

Data initializer for Entity Framework Core. Use it with the surrounding package APIs when composing application code.

```csharp
public abstract class DatabaseInitializerBase<TDbContext>(TDbContext context) : IDatabaseInitializer<TDbContext>
    where TDbContext : DbContext
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `context` | `TDbContext` | `-` | The `context` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [InitializeAsync](method-initializeasync-35.md) | Runs the `InitializeAsync` operation on `DatabaseInitializerBase<TDbContext>`. Use it when your code needs this specific behavior from the package. |
| [InitializeDataAsync](method-initializedataasync-27.md) | Initialize necessary data for the database. Use it with the surrounding package APIs when composing application code. |
| [InitializeTestDataAsync](method-initializetestdataasync-33.md) | Initialize test data for the database. Use it with the surrounding package APIs when composing application code. |
| [MigrateAsync](method-migrateasync-20.md) | Migrates database to the latest version. Use it with the surrounding package APIs when composing application code. |
| [TryAdd<TEntity>](method-tryadd-tentity-52.md) | Safely adds an entity if it is not already exist. Use it with the surrounding package APIs when composing application code. |

