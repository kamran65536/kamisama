# DataInitializationOptions

<a id="datainitializationoptions"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Repositories.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Repositories.Core/Initialization/DataInitializationOptions.cs:8](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Core/Initialization/DataInitializationOptions.cs#L8)

Namespace: `KamiSama.Repositories.Initialization`

Kind: `Class`

## Description

Options object that controls database initialization work. Use it to turn migration, normal seed data, and test seed data on or off.

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
| [InitializeData](property-initializedata-18.md) | Initialize necessary data to the database. Use it with the surrounding package APIs when composing application code. |
| [InitializeTestData](property-initializetestdata-23.md) | Adds test data (for test purposes). Use it with the surrounding package APIs when composing application code. |
| [Migrate](property-migrate-13.md) | Migrate database to the latest version. Use it with the surrounding package APIs when composing application code. |

