# AddLocationsModule

[Back to ExtendedWebApplicationBuilderExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Locations.Core](../../index.md)

Source: [src/KamiSama.Modules.Locations.Core/LocationsModule.cs:63](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Core/LocationsModule.cs#L63)

Type: `KamiSama.Modules.Locations.ExtendedWebApplicationBuilderExtensions`

Kind: `Method`

## Description

Queues Locations service registration and post-build initialization. The callback must register a provider matching the database section's lowercased key; call `BuildAsync` before resolving feature services so registration, context resolution, and selected migration or seed stages complete.

## Declaration

```csharp
public static ExtendedWebApplicationBuilder AddLocationsModule(this ExtendedWebApplicationBuilder builder, IConfigurationSection moduleSection, IConfigurationSection databaseSection, Action<IMultiProviderDbContextBuilder<LocationsDbContext>>? configureDbContext = null);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `builder (extension receiver)` | `ExtendedWebApplicationBuilder` | `-` | The extended application builder that queues the Locations module. |
| `moduleSection` | `IConfigurationSection` | `-` | The Locations module section; its `initialization` child binds the named migration and seed options. |
| `databaseSection` | `IConfigurationSection` | `-` | The section containing required `provider` and `connection-string` values. |
| `configureDbContext` | `Action<IMultiProviderDbContextBuilder<LocationsDbContext>>?` | `null` | The provider-registration callback. Although nullable for API compatibility, it is required in a normal host so the configured keyed `LocationsDbContext` can be resolved. |

## Returns

| Type | Description |
| --- | --- |
| `ExtendedWebApplicationBuilder` | The same extended builder for fluent module composition. |

## Remarks

Register the PostgreSQL or SQLite provider matching the configured provider key, then call `BuildAsync` before resolving Locations features. During the post-build phase the module resolves a custom named `IDatabaseInitializer&amp;amp;lt;LocationsDbContext&amp;amp;gt;`, or falls back to migration-only initialization. This module registers services only; it does not add controllers, endpoints, or authorization.

## Example

```csharp
ExtendedWebApplicationBuilder builder = webBuilder.Extend().AddLocationsModule(
    locationsSection, databaseSection,
    database => database.AddPostgresqlLocationsDbContext());
WebApplication app = await builder.BuildAsync(cancellationToken);
```

