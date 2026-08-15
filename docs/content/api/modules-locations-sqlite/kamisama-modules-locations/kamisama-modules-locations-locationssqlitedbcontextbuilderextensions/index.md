# LocationsSqliteDbContextBuilderExtensions

<a id="locationssqlitedbcontextbuilderextensions"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Locations.Sqlite](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Locations.Sqlite/LocationsSqliteDbContextBuilderExtensions.cs:11](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Sqlite/LocationsSqliteDbContextBuilderExtensions.cs#L11)

Namespace: `KamiSama.Modules.Locations`

Kind: `Class`

## Description

Registers the SQLite Locations context under the exact `sqlite` keyed base-context service. Use it from the callback passed to `AddLocationsModule`.

## Declaration

```csharp
public static class LocationsSqliteDbContextBuilderExtensions
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [AddSqliteLocationsDbContext](method-addsqlitelocationsdbcontext-19.md) | Registers `SqliteLocationsDbContext` and its exact `sqlite` keyed `LocationsDbContext` alias, using the configured connection string, lazy-loading proxies, and Locations migration-history table. |

