# LocationsPostgresqlDbContextBuilderExtensions

<a id="locationspostgresqldbcontextbuilderextensions"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Locations.Postgresql](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Locations.Postgresql/LocationsPostgresqlDbContextBuilderExtensions.cs:11](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Postgresql/LocationsPostgresqlDbContextBuilderExtensions.cs#L11)

Namespace: `KamiSama.Modules.Locations`

Kind: `Class`

## Description

Registers the PostgreSQL Locations context under the exact `postgresql` keyed base-context service. Use it from the callback passed to `AddLocationsModule`.

## Declaration

```csharp
public static class LocationsPostgresqlDbContextBuilderExtensions
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [AddPostgresqlLocationsDbContext](method-addpostgresqllocationsdbcontext-19.md) | Registers `PostgresqlLocationsDbContext` and its exact `postgresql` keyed `LocationsDbContext` alias, using the configured connection string, lazy-loading proxies, and Locations migration-history table. |

