---
last-checked-utc: 2026-08-15T01:08:17Z
root-version: 10.0.0
classes-without-examples:
  - KamiSama.Modules.ServicePlans.ExtendedWebApplicationBuilderExtensions
  - KamiSama.Modules.ServicePlans.ServicePlansOptions
---

# Documentation Snapshot

The package description, complete public/protected XML summaries, setup and initialization lifecycle, DI assignability, entities, feature and filter behavior, schema and security limitations, publication status, useful exact-full-name class examples, and exact exemptions were reviewed against current source at the recorded root version.

## Description

ASP.NET Core ServicePlans implementation with EF Core plan, offer, subscriber, and subscription entities, scoped CRUD features, modular registration, and startup initialization.
Install one provider, provision the schema separately, and enforce authorization and domain validation in the host.

## How to use

**Publication mismatch:** `10.0.0` below is the current workspace/root documentation version and remains required in repository documentation. NuGet returned no published package or version for this package ID when reviewed.

```shell
dotnet add package KamiSama.Modules.ServicePlans.Core --version 10.0.0
```

Call `AddServicePlansModule(moduleSection, databaseSection, providerCallback)` on an `ExtendedWebApplicationBuilder`. Register `AddPostgresqlServicePlansDbContext` for provider `postgresql` or `AddSqliteServicePlansDbContext` for `sqlite`, then call `BuildAsync`. The callback is nullable in the signature but required in normal setup unless the host separately registers the exact configured keyed `ServicePlansDbContext`.

During build, Core binds the empty `ServicePlansOptions`, named connection and initialization options, scans Core for attributed scoped repositories and features, and selects `__EFMigrationsHistory_ServicePlans`. After build it resolves a custom `IDatabaseInitializer<ServicePlansDbContext>` or the migration-only default. The default migrates only when requested; initialize and test-data stages are no-ops.

## Runtime audit

Neither provider contains ServicePlans migrations. `BuildAsync` therefore cannot provision module tables from this checkout even when `migrate` is enabled; provision a compatible schema or supply migrations/custom initialization separately. Core models plans, offers, country and payment restrictions, subscribers, and subscriptions, but public feature services cover only plans, subscribers, and subscriptions. There are no offer features, controllers, endpoints, middleware, authentication, or authorization.

All 18 attributed feature implementations and all three attributed repositories are assignable to their declared service contracts. Plan-name and external-user duplicate checks are separate reads without model-level unique indexes, so concurrent writes can create duplicates. Mutations save immediately without a feature-level transaction. Plan name matching lowercases both sides; plan, subscriber, and subscription ordering accepts only the source-defined tokens documented on their search contracts.

Subscription add/update verifies only that referenced subscriber and plan rows exist. It does not enforce enabled state, ownership, valid status transitions, valid enum values, date ordering, duration consistency, or non-negative rates, allowances, balances, usage, and traffic. Update can reassign both relationships and replace metering counters. Hosts must enforce authorization and domain invariants before invoking these features.

## Example decisions

`ServicePlansWebModule`, all six EF entities, and `ServicePlansDbContext` have exact-full-name useful class examples. Static `ExtendedWebApplicationBuilderExtensions` is exempt because the detailed How-to and exact `AddServicePlansModule` member example cover its only operation. Empty `ServicePlansOptions` is exempt because it has no configurable members. Internal features, repositories, and mappings are excluded from generated public API pages but audited above.
