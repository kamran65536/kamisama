---
last-checked-utc: 2026-08-15T00:26:43Z
root-version: 10.0.0
classes-without-examples:
  - KamiSama.Modules.Locations.Entities.City
  - KamiSama.Modules.Locations.Entities.Province
  - KamiSama.Modules.Locations.ExtendedWebApplicationBuilderExtensions
---

# Documentation Snapshot

The package description, complete public/protected XML summaries, provider and initialization lifecycle, query behavior, data limitations, publication mismatch, context example, and exact example exemptions were reviewed against the source at the recorded root version.

## Description

ASP.NET Core Locations implementation with EF Core province and city persistence, scoped feature services, modular registration, and startup database initialization.
Install it with at least the selected PostgreSQL or SQLite provider and complete setup through the extended builder.

## How to use

**Publication mismatch:** `10.0.0` below is the current workspace/root documentation version and remains required in repository documentation. NuGet exposed `10.0.11` as the latest package when reviewed; `10.0.0` itself was not available.

```shell
dotnet add package KamiSama.Modules.Locations.Core --version 10.0.0
```

Call `AddLocationsModule` with the module section, a database section containing `provider` and `connection-string`, and a callback over `IMultiProviderDbContextBuilder<LocationsDbContext>`. Register `AddPostgresqlLocationsDbContext` for `postgresql` or `AddSqliteLocationsDbContext` for `sqlite`. The callback is nullable in the signature but mandatory in a normal setup because startup resolves the configured keyed context. A callback can register both installed providers, but configuration selects one key for the host.

Finish with `BuildAsync` before resolving Locations features. Its post-build phase reads named initialization settings from the module section's `initialization` child. The fallback initializer migrates only when `migrate` is true; `initialize` and `test-data` are no-ops unless a custom `IDatabaseInitializer<LocationsDbContext>` is registered. Startup migration requires a reachable database, schema privileges, and compatible provider migrations.

Core registers scoped feature/repository implementations and memory caching but no controllers, endpoints, authentication, or authorization. Mutations save immediately and do not check duplicate names. A city requires an existing parent province; province deletion is restricted while cities reference it. Provider contexts enable lazy loading, list/find queries track entities, and translated lowercase substring matching depends on provider collation and translation. `IListCitiesByProvinceName` is unpaged despite returning a page-shaped result, and `City` exposes its parent through the required `Province` navigation rather than a public `ProvinceId` property.

## Example decisions

`LocationsDbContext` has an exact-full-name scoped resolution/query example. The simple EF entity models are exempt because their member documentation fully explains their shape and relationship. Static `ExtendedWebApplicationBuilderExtensions` is exempt because the package How-to and exact `AddLocationsModule` member example cover its only operation.
