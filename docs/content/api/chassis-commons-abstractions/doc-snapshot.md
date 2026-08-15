---
last-checked-utc: 2026-08-14T23:07:51Z
root-version: 10.0.0
classes-without-examples: []
---

# Documentation Snapshot

The package description, public API summaries, usage guidance, and type-level example coverage were reviewed against the source at the recorded root version.

## Description

Feature and repository contracts for the KamiSama chassis layer.
Reference this package from application or module projects that need to depend on abstractions instead of concrete implementations.

## How to use

```shell
dotnet add package KamiSama.Chassis.Commons.Abstractions --version 10.0.0
```

Depend on narrow feature interfaces from callers and compose repository capabilities on implementation contracts. This package contains no classes, service registrations, persistence implementation, transaction policy, or missing-entity policy. Implementations decide those behaviors.

The shorter `IListFeature<TEntityDto, TSearchModel>`, `IListingRepository<TEntity, TSearchModel>`, and `IGenericRepository<TEntity, TSearchModel>` interfaces are aliases that fix the result to `PagedResult<T>`. Their corresponding full-shape interfaces have type examples, so these three alias-interface type pages are exempt from duplicate examples. Other feature and repository interfaces have full-name-matched calling or composition examples.

## Example decisions

There are no public classes, so `classes-without-examples` is empty. Alias-interface exemptions are recorded in the body rather than the class-only snapshot field.
