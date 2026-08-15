# PostgresqlLocationsDbContext

<a id="postgresqllocationsdbcontext"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Locations.Postgresql](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Locations.Postgresql/Repositories/Database/Postgresql/PostgresqlLocationsDbContext.cs:10](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Postgresql/Repositories/Database/Postgresql/PostgresqlLocationsDbContext.cs#L10)

Namespace: `KamiSama.Modules.Locations.Repositories.Database.Postgresql`

Kind: `Class`

## Description

Concrete PostgreSQL Locations context targeted by this provider package's migrations. Normal hosts register it through `AddPostgresqlLocationsDbContext` rather than constructing it directly.

## Declaration

```csharp
public class PostgresqlLocationsDbContext(DbContextOptions<PostgresqlLocationsDbContext> options) : LocationsDbContext(options)
```

## Example

```csharp
ExtendedWebApplicationBuilder builder = webBuilder.Extend().AddLocationsModule(
    locationsSection, databaseSection,
    database => database.AddPostgresqlLocationsDbContext());
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Postgresql/Repositories/Database/Postgresql/PostgresqlLocationsDbContext.cs#L10)

Provides the PostgreSQL EF Core context targeted by the Locations PostgreSQL migrations. Use it with the surrounding package APIs when composing application code.

```csharp
public class PostgresqlLocationsDbContext(DbContextOptions<PostgresqlLocationsDbContext> options) : LocationsDbContext(options)
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `options` | `DbContextOptions<PostgresqlLocationsDbContext>` | `-` | The PostgreSQL options configured by `AddPostgresqlLocationsDbContext`. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

