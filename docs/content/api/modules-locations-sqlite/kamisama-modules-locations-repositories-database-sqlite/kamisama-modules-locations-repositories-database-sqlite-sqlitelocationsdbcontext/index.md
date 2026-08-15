# SqliteLocationsDbContext

<a id="sqlitelocationsdbcontext"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Locations.Sqlite](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Locations.Sqlite/Repositories/Database/Sqlite/SqliteLocationsDbContext.cs:10](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Sqlite/Repositories/Database/Sqlite/SqliteLocationsDbContext.cs#L10)

Namespace: `KamiSama.Modules.Locations.Repositories.Database.Sqlite`

Kind: `Class`

## Description

Concrete SQLite Locations context targeted by this provider package's migrations. Normal hosts register it through `AddSqliteLocationsDbContext` rather than constructing it directly.

## Declaration

```csharp
public class SqliteLocationsDbContext(DbContextOptions<SqliteLocationsDbContext> options) : LocationsDbContext(options)
```

## Example

```csharp
ExtendedWebApplicationBuilder builder = webBuilder.Extend().AddLocationsModule(
    locationsSection, databaseSection,
    database => database.AddSqliteLocationsDbContext());
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Sqlite/Repositories/Database/Sqlite/SqliteLocationsDbContext.cs#L10)

Provides the SQLite EF Core context targeted by the Locations SQLite migrations. Use it with the surrounding package APIs when composing application code.

```csharp
public class SqliteLocationsDbContext(DbContextOptions<SqliteLocationsDbContext> options) : LocationsDbContext(options)
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `options` | `DbContextOptions<SqliteLocationsDbContext>` | `-` | The SQLite options configured by `AddSqliteLocationsDbContext`. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

