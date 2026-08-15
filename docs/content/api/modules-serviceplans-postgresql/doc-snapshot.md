---
last-checked-utc: 2026-08-15T01:08:17Z
root-version: 10.0.0
classes-without-examples:
  - KamiSama.Modules.ServicePlans.ServicePlansPostgresqlDbContextBuilderExtensions
---

# Documentation Snapshot

The package description, complete public XML summaries, provider key and callback, context registration, migration absence, process-wide switches, publication status, useful context example, and exact extension exemption were reviewed against current source at the recorded root version.

## Description

PostgreSQL EF Core context registration for ServicePlans Core under the `postgresql` provider key.
It configures Npgsql and lazy loading but currently ships no ServicePlans migrations.

## How to use

**Publication mismatch:** `10.0.0` below is the current workspace/root documentation version and remains required in repository documentation. NuGet returned no published package or version for this package ID when reviewed.

```shell
dotnet add package KamiSama.Modules.ServicePlans.Postgresql --version 10.0.0
```

Pass `database => database.AddPostgresqlServicePlansDbContext()` to `AddServicePlansModule` and configure provider `postgresql`. Registration adds a scoped `PostgresqlServicePlansDbContext` and exact keyed `ServicePlansDbContext` alias, enables lazy-loading proxies, uses `__EFMigrationsHistory_ServicePlans`, and applies the shared PostgreSQL registration's process-wide legacy timestamp and disabled infinity-conversion switches.

This package contains no ServicePlans migrations. Core's post-build migration stage cannot create the module schema; provision a compatible PostgreSQL schema or supply migrations separately before using the repositories.

## Example decisions

`PostgresqlServicePlansDbContext` has an exact-full-name setup example. Static `ServicePlansPostgresqlDbContextBuilderExtensions` is exempt because the How-to and exact `AddPostgresqlServicePlansDbContext` member example cover its only operation. Migration files remain excluded from generated API pages; none exist in this package.
