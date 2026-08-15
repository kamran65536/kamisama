# KamiSama.Modules.Locations.Core

[Back to package index](../index.md)

Version: `10.0.0`

## Description

ASP.NET Core Locations implementation with EF Core province and city persistence, scoped feature services, modular registration, and startup database initialization. Install it with at least the selected PostgreSQL or SQLite provider and complete setup through the extended builder.

## How to use

```shell
dotnet add package KamiSama.Modules.Locations.Core --version 10.0.0
```

**Publication mismatch:** `10.0.0` in the required install command is the current workspace/root documentation version. NuGet exposed `10.0.11` as the latest package when this surface was reviewed; `10.0.0` itself was not available.

Install Core plus at least the selected provider package. Configure one provider key and connection string, pass a callback that registers that key, and finish through `BuildAsync` before resolving or using Locations features:

```json
{
  "Locations": {
    "initialization": {
      "migrate": true,
      "initialize": false,
      "test-data": false
    },
    "database": {
      "provider": "postgresql",
      "connection-string": "Host=localhost;Database=locations;Username=app;Password=..."
    }
  }
}
```

```csharp
using KamiSama.Modules;
using KamiSama.Modules.Locations;

var webBuilder = WebApplication.CreateBuilder(args);
IConfigurationSection locations = webBuilder.Configuration.GetSection("Locations");

ExtendedWebApplicationBuilder builder = webBuilder.Extend()
    .AddLocationsModule(
        locations,
        locations.GetSection("database"),
        database => database.AddPostgresqlLocationsDbContext());

WebApplication app = await builder.BuildAsync(CancellationToken.None);
```

The callback receives `IMultiProviderDbContextBuilder<LocationsDbContext>`. Use `AddPostgresqlLocationsDbContext` for configured key `postgresql` or `AddSqliteLocationsDbContext` for `sqlite`; keys are lowercased before resolution. A callback may register both installed providers, but configuration selects exactly one keyed context for a running host. The nullable callback is mandatory in a normal setup: without a matching keyed registration, post-build context resolution fails.

`BuildAsync` first runs module service registration, then builds the app, then initializes Locations. Initialization options are read from `Locations:initialization` under the named `Locations` options instance. The default fallback initializer runs EF migrations only when `migrate` is true; its `initialize` and `test-data` stages are no-ops. A registered `IDatabaseInitializer<LocationsDbContext>` can implement those seed stages. Migration therefore happens during startup and requires database connectivity, schema privileges, and a provider package containing compatible migrations.

Core discovers scoped feature and repository implementations and adds memory caching, but it maps no controllers or endpoints. Inject abstraction interfaces after build. Adds and updates do not perform duplicate-name checks. Adding or moving a city requires an existing province and otherwise throws `NotFoundException<Province>`. Province deletion is restricted by the relationship and can fail at save time while cities reference it. Repository mutations save immediately; list/find queries are tracked, and provider registrations enable lazy-loading proxies.

City name and province-name filters call `ToLower().Contains(...)` in the translated database query; matching and index use therefore depend on provider translation and collation. City order token `province` sorts by province then city, all other values sort by city, and province ordering always uses name. `IListCitiesByProvinceName` starts from `CitySearchModel.All`, so it returns all matching rows in a page-shaped result rather than applying a finite page. `City` represents its parent through a required `Province` navigation and exposes no separate public `ProvinceId` property.

## Namespaces

- [KamiSama.Modules.Locations](kamisama-modules-locations/index.md) (1 types)
- [KamiSama.Modules.Locations.Entities](kamisama-modules-locations-entities/index.md) (2 types)
- [KamiSama.Modules.Locations.Repositories.Database](kamisama-modules-locations-repositories-database/index.md) (1 types)

## Types

- [KamiSama.Modules.Locations.ExtendedWebApplicationBuilderExtensions](kamisama-modules-locations/kamisama-modules-locations-extendedwebapplicationbuilderextensions/index.md) - Adds the Locations web module, which discovers scoped features and repositories, configures a keyed provider-neutral context, and performs named database initialization after build. A matching provider callback is required in a normal host, and the module maps no controllers or endpoints.
- [KamiSama.Modules.Locations.Entities.City](kamisama-modules-locations-entities/kamisama-modules-locations-entities-city/index.md) - EF Core city entity with a required name and required virtual parent-province navigation. It exposes no separate public province-id property.
- [KamiSama.Modules.Locations.Entities.Province](kamisama-modules-locations-entities/kamisama-modules-locations-entities-province/index.md) - EF Core province entity with a required 100-character name and a virtual city collection. The model restricts deletion while related cities remain.
- [KamiSama.Modules.Locations.Repositories.Database.LocationsDbContext](kamisama-modules-locations-repositories-database/kamisama-modules-locations-repositories-database-locationsdbcontext/index.md) - Provider-neutral EF Core context consumed by Locations repositories. It exposes tracked province and city sets and configures restricted city-to-province deletion; a concrete provider context must be registered for runtime resolution.
