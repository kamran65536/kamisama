# DataInitializationOptions

<a id="datainitializationoptions"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Repositories.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Repositories.Core/Initialization/DataInitializationOptions.cs:8](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Core/Initialization/DataInitializationOptions.cs#L8)

Namespace: `KamiSama.Repositories.Initialization`

Kind: `Class`

## Description

Selects whether a database initializer should migrate, create required application data, or create test data. The `IDatabaseInitializer<TDbContext>` implementation defines the actual work and ordering.

## Declaration

```csharp
public class DataInitializationOptions
```

## Example

```csharp
using KamiSama.Repositories.Initialization;

await initializer.InitializeAsync(new DataInitializationOptions
{
    Migrate = true,
    InitializeData = true,
    InitializeTestData = false
}, cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Properties

| Member | Description |
| --- | --- |
| [InitializeData](property-initializedata-18.md) | Gets or sets whether the initializer should create required application data. |
| [InitializeTestData](property-initializetestdata-23.md) | Gets or sets whether the initializer should create test data; production callers normally leave this disabled. |
| [Migrate](property-migrate-13.md) | Gets or sets whether the initializer should run its database migration stage. |

