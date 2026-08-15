---
last-checked-utc: 2026-08-15T00:26:43Z
root-version: 10.0.0
classes-without-examples:
  - KamiSama.Modules.Locations.LocationsPostgresqlDbContextBuilderExtensions
---

# Documentation Snapshot

The package description, complete public XML summaries, provider key, Core callback, context and migration behavior, publication mismatch, useful context example, migration exclusion, and exact extension exemption were reviewed against the source at the recorded root version.

## Description

PostgreSQL EF Core context and provider registration for KamiSama.Modules.Locations.Core, including Locations migrations and keyed context resolution.
Select it from the Core provider callback when the configured database provider is `postgresql`.

## How to use

**Publication mismatch:** `10.0.0` below is the current workspace/root documentation version and remains required in repository documentation. NuGet exposed `10.0.11` as the latest provider package when reviewed; `10.0.0` itself was not available.

```shell
dotnet add package KamiSama.Modules.Locations.Postgresql --version 10.0.0
```

Configure the Core database section with provider `postgresql` and pass `database => database.AddPostgresqlLocationsDbContext()` to `AddLocationsModule`. This registers `PostgresqlLocationsDbContext` under the exact keyed base-context service, enables lazy-loading proxies, and uses `__EFMigrationsHistory_Locations`. `BuildAsync` can apply this package's migrations during startup, requiring database connectivity and migration privileges.

## Example decisions

`PostgresqlLocationsDbContext` has an exact-full-name example through the supported Core callback. Static `LocationsPostgresqlDbContextBuilderExtensions` is exempt because the How-to and exact member example cover its only operation. EF migration and model-snapshot types are generated implementation artifacts, excluded from API generation, and exempt from class examples.
