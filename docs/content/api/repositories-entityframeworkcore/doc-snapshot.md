---
last-checked-utc: 2026-08-14T23:41:17Z
root-version: 10.0.0
classes-without-examples: []
---

# Documentation Snapshot

The package description, public and protected API documentation, persistence, tracking, initialization, paging, registration caveats, and example coverage were reviewed against the source at the recorded root version.

## Description

Entity Framework Core repositories, paging, database initialization, and multi-provider DbContext registration.
Use it for tracked repository access, migration and seed workflows, or configuration-selected provider contexts.

## How to use

```shell
dotnet add package KamiSama.Repositories.EntityFrameworkCore --version 10.0.0
```

Bind the `provider` and `connection-string` keys with `AddMultiProviderDbContext<TBaseContext>`, optionally call `WithMigrationHistoryTable`, then call each installed provider package's generic method with a concrete context derived from the base context. Provider lookup lowercases configuration values; PostgreSQL and SQLite register exact `postgresql` and `sqlite` keys. Contexts and keyed aliases are scoped, provider packages enable lazy-loading proxies, and the configured migration-history table is shared across provider registration calls.

Repositories borrow rather than own contexts, do not dispose them, track queries by default, and call `SaveChanges` immediately for every mutation. Paging requires caller-supplied deterministic ordering, counts synchronously without cancellation, and materializes asynchronously in a second query. Initializer stages run sequentially in migration, application-data, and test-data order without a transaction supplied by the base class; `TryAdd` has a race between lookup and immediate insert.

## Example decisions

Both repository classes, both initializer classes, `IQueryableExtensions`, and `ServiceCollectionExtensions` have full-name-matched class examples. Both multi-provider interfaces also have full-name-matched workflow examples, but interfaces are not class exemptions. The generic overloads for paging, migration-history setup, provider-neutral registration, initialization helpers, and repository operations use full-type-and-member-scoped examples. No public class requires an exemption.
