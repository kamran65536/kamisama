---
last-checked-utc: 2026-08-14T23:41:17Z
root-version: 10.0.0
classes-without-examples:
  - KamiSama.Repositories.EntityFrameworkCore.Postgresql.MultiProviderDbContextBuilderPostgresqlExtensions
---

# Documentation Snapshot

The package description, public API documentation, provider registration behavior, process-wide effects, publication status, and example coverage were reviewed against the source at the recorded root version.

## Description

PostgreSQL registration for KamiSama multi-provider Entity Framework Core DbContexts.
It adds scoped keyed context resolution, lazy-loading proxies, migration-history configuration, and process-wide Npgsql compatibility switches.

## How to use

**Warning:** the workspace root version is `10.0.0`, but a matching provider package may not be published. Keep the required workspace-version command:

```shell
dotnet add package KamiSama.Repositories.EntityFrameworkCore.Postgresql --version 10.0.0
```

After `AddMultiProviderDbContext<TBaseContext>`, call `AddPostgresql<TInheritedContext>` with a concrete context derived from the base context. It registers scoped services under the exact `postgresql` key, enables lazy-loading proxies, and applies the builder's migration-history table. Registration also sets `Npgsql.EnableLegacyTimestampBehavior` and `Npgsql.DisableDateTimeInfinityConversions` process-wide, affecting every Npgsql consumer in the process.

## Example decisions

Static `KamiSama.Repositories.EntityFrameworkCore.Postgresql.MultiProviderDbContextBuilderPostgresqlExtensions` is exempt from a separate class-level example because the package How-to and its sole full-name-and-member-scoped generic `AddPostgresql<TInheritedContext>` example fully demonstrate its use.
