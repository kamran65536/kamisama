# DefaultDatabaseInitializer<TDbContext>

<a id="defaultdatabaseinitializer-tdbcontext"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Repositories.EntityFrameworkCore](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Repositories.EntityFrameworkCore/Initialization/DefaultDatabaseInitializer.cs:8](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFrameworkCore/Initialization/DefaultDatabaseInitializer.cs#L8)

Namespace: `KamiSama.Repositories.EntityFrameworkCore.Initialization`

Kind: `Class`

## Description

Default Initializer, applies migration based on options. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public class DefaultDatabaseInitializer<TDbContext>(TDbContext context) : DatabaseInitializerBase<TDbContext>(context)
    where TDbContext : DbContext
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFrameworkCore/Initialization/DefaultDatabaseInitializer.cs#L8)

Default Initializer, applies migration based on options. Use it with the surrounding package APIs when composing application code.

```csharp
public class DefaultDatabaseInitializer<TDbContext>(TDbContext context) : DatabaseInitializerBase<TDbContext>(context)
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
| [InitializeDataAsync](method-initializedataasync-12.md) | Runs the `InitializeDataAsync` operation on `DefaultDatabaseInitializer<TDbContext>`. Use it when your code needs this specific behavior from the package. |
| [InitializeTestDataAsync](method-initializetestdataasync-17.md) | Runs the `InitializeTestDataAsync` operation on `DefaultDatabaseInitializer<TDbContext>`. Use it when your code needs this specific behavior from the package. |

