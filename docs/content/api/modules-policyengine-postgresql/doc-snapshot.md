---
last-checked-utc: 2026-08-15T01:00:03Z
root-version: 10.0.0
classes-without-examples:
  - KamiSama.Modules.PolicyEngine.PolicyEnginePostgresqlDbContextBuilderExtensions
---

# Documentation Snapshot

The package description, complete public XML summaries and parameters/returns, provider callback setup, keyed context behavior, schema provisioning limitation, publication state, exact-full-name context example, and static-extension exemption were reviewed against current source at the recorded root version.

## Description

PostgreSQL EF Core context registration for PolicyEngine Core under the exact `postgresql` provider key.
It configures Npgsql and lazy loading but currently ships no PolicyEngine migrations.

## How to use

**Publication mismatch:** `10.0.0` below is the current workspace/root documentation version and remains required in repository documentation. NuGet returned no published package or version for any of the four current PolicyEngine package IDs when reviewed.

```shell
dotnet add package KamiSama.Modules.PolicyEngine.Postgresql --version 10.0.0
```

Set the Core database section's provider to `postgresql`, then pass `database => database.AddPostgresqlPolicyEngineDbContext()` to `AddPolicyEngineModule`. Registration creates a scoped `PostgresqlPolicyEngineDbContext`, exposes it as the keyed base `PolicyEngineDbContext`, enables lazy-loading proxies, uses `__EFMigrationsHistory_PolicyEngine`, and sets `Npgsql.EnableLegacyTimestampBehavior` and `Npgsql.DisableDateTimeInfinityConversions` process-wide.

This package contains no migrations. `BuildAsync` can run Core's default migration stage, but that stage cannot create the PolicyEngine schema without migration operations. Provision a compatible PostgreSQL schema or supply migrations/custom initialization separately.

## Example decisions

`PostgresqlPolicyEngineDbContext` has an exact-full-name provider-callback example. Static `PolicyEnginePostgresqlDbContextBuilderExtensions` is exempt because the package How-to and exact `AddPostgresqlPolicyEngineDbContext` member documentation cover its only public operation. Migrations are absent rather than merely excluded from generated API pages.
