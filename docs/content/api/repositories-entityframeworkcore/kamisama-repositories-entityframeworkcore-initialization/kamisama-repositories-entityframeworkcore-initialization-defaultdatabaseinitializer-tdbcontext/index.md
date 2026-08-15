# DefaultDatabaseInitializer<TDbContext>

<a id="defaultdatabaseinitializer-tdbcontext"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Repositories.EntityFrameworkCore](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Repositories.EntityFrameworkCore/Initialization/DefaultDatabaseInitializer.cs:11](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFrameworkCore/Initialization/DefaultDatabaseInitializer.cs#L11)

Namespace: `KamiSama.Repositories.EntityFrameworkCore.Initialization`

Kind: `Class`

## Description

Migration-only EF Core initializer. Migration runs when selected, while application-data and test-data stages complete without performing work.

## Declaration

```csharp
public class DefaultDatabaseInitializer<TDbContext>(TDbContext context) : DatabaseInitializerBase<TDbContext>(context)
    where TDbContext : DbContext
```

## Remarks

Set `Migrate` to run migrations; the application-data and test-data options perform no work.

## Example

```csharp
using KamiSama.Repositories.EntityFrameworkCore.Initialization;
using KamiSama.Repositories.Initialization;

var initializer = new DefaultDatabaseInitializer<AppDbContext>(dbContext);
await initializer.InitializeAsync(
    new DataInitializationOptions { Migrate = true }, cancellationToken);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFrameworkCore/Initialization/DefaultDatabaseInitializer.cs#L11)

Provides migration-only initialization while treating both seed-data stages as completed no-ops. Use it with the surrounding package APIs when composing application code.

```csharp
public class DefaultDatabaseInitializer<TDbContext>(TDbContext context) : DatabaseInitializerBase<TDbContext>(context)
    where TDbContext : DbContext
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `context` | `TDbContext` | `-` | The scoped context used for migration. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [InitializeDataAsync](method-initializedataasync-17.md) | Completes without creating application data. Use it with the surrounding package APIs when composing application code. |
| [InitializeTestDataAsync](method-initializetestdataasync-24.md) | Completes without creating test data. Use it with the surrounding package APIs when composing application code. |

