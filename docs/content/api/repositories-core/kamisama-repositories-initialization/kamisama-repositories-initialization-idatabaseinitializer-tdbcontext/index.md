# IDatabaseInitializer<TDbContext>

<a id="idatabaseinitializer-tdbcontext"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Repositories.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Repositories.Core/Initialization/IDatabaseInitializer.cs:10](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Core/Initialization/IDatabaseInitializer.cs#L10)

Namespace: `KamiSama.Repositories.Initialization`

Kind: `Interface`

## Description

Defines migration and seed-data initialization for one database context type. Implementations interpret `DataInitializationOptions` and own ordering, idempotency, persistence, and failure behavior.

## Declaration

```csharp
public interface IDatabaseInitializer<TDbContext>
```

## Example

```csharp
using KamiSama.Repositories.Initialization;

public sealed class StartupDatabase(AppDbContext context) : IDatabaseInitializer<AppDbContext>
{
    public Task InitializeAsync(DataInitializationOptions options, CancellationToken cancellationToken)
        => options.InitializeData ? SeedAsync(context, cancellationToken) : Task.CompletedTask;
}
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [InitializeAsync](method-initializeasync-18.md) | Runs the migration and seed stages selected by `DataInitializationOptions`; the implementation owns ordering, idempotency, persistence, and failure behavior. |

