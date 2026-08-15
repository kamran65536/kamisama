# AddPostgresqlLocationsDbContext

[Back to LocationsPostgresqlDbContextBuilderExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Locations.Postgresql](../../index.md)

Source: [src/KamiSama.Modules.Locations.Postgresql/LocationsPostgresqlDbContextBuilderExtensions.cs:19](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Postgresql/LocationsPostgresqlDbContextBuilderExtensions.cs#L19)

Type: `KamiSama.Modules.Locations.LocationsPostgresqlDbContextBuilderExtensions`

Kind: `Method`

## Description

Registers `PostgresqlLocationsDbContext` and its exact `postgresql` keyed `LocationsDbContext` alias, using the configured connection string, lazy-loading proxies, and Locations migration-history table.

## Declaration

```csharp
public static IMultiProviderDbContextBuilder<LocationsDbContext> AddPostgresqlLocationsDbContext(this IMultiProviderDbContextBuilder<LocationsDbContext> builder);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `builder (extension receiver)` | `IMultiProviderDbContextBuilder<LocationsDbContext>` | `-` | The Locations context builder created during `AddLocationsModule` service configuration. |

## Returns

| Type | Description |
| --- | --- |
| `IMultiProviderDbContextBuilder<LocationsDbContext>` | The same builder for fluent registration. |

## Remarks

The underlying provider enables lazy-loading proxies, applies the Locations migration-history table, and uses the configured connection string.

## Example

```csharp
database.AddPostgresqlLocationsDbContext(); // Registers the exact postgresql provider key.
```

