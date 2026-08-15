---
last-checked-utc: 2026-08-15T00:19:39Z
root-version: 10.0.0
classes-without-examples:
  - KamiSama.Modules.Identity.IdentityPostgresqlDbContextBuilderExtensions
---

# Documentation Snapshot

The package description, public extension summary, provider key, mandatory Core callback, startup migration behavior, publication mismatch, and example exemption were reviewed against the source at the recorded root version.

## Description

PostgreSQL EF Core provider registration for KamiSama.Modules.Identity.Core.
Install it in an Identity host and select its provider callback so Core can resolve the database context and run startup migrations.

## How to use

**Publication mismatch:** version `10.0.0` below is the current workspace/root documentation version, but this provider version was not published at the time of review. Use an actually published version for NuGet installation.

```shell
dotnet add package KamiSama.Modules.Identity.Postgresql --version 10.0.0
```

Pass `database => database.AddPostgresqlIdentityDbContext()` to `AddKamiSamaIdentityModule` and configure the database provider as exact key `postgresql`. The callback registers an internal provider context derived from `KamiSamaIdentityDbContext`; Core runs configured migrations during `BuildAsync`, so startup requires a reachable database and migration privileges.

## Example decisions

Static `KamiSama.Modules.Identity.IdentityPostgresqlDbContextBuilderExtensions` is exempt from a separate class-level example because the package How-to and exact `AddPostgresqlIdentityDbContext` member example cover its only operation. The internal provider context is not public API and shares this setup path rather than receiving a generated type page.
