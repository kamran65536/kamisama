---
last-checked-utc: 2026-08-14T23:07:51Z
root-version: 10.0.0
classes-without-examples: []
---

# Documentation Snapshot

The package description, public and protected API summaries, usage guidance, and class-level example coverage were reviewed against the source at the recorded root version.

## Description

Reusable feature and repository base classes for common CRUD-style application flows.
Use this package when building service-layer features around entities, DTOs, repositories, and paged results.

## How to use

```shell
dotnet add package KamiSama.Chassis.Commons --version 10.0.0
```

Derive one concrete feature per use case and implement only its validation, mapping, mutation, or result-shaping hooks. Create and update workflows mutate through repository contracts; find and delete workflows throw HTTP not-found exceptions for missing entities; existence workflows delegate directly. A delete guard that returns false silently skips deletion.

`GenericRepository` is EF Core based. It applies the same search hook before list and count operations, relies on the injected `DbContext` lifetime, and inherits actual CRUD and save behavior from `DbRepository`. Consumers remain responsible for dependency-injection registration, transaction boundaries, query design, and avoiding unsafe data exposure in DTO mappings.

## Example decisions

Every framework and pattern class, including both `GenericListFeature` and both `GenericRepository` overloads and all nested `FeatureDefinitionBase` classes, has a full-name-scoped class example. No class-level exemptions are required. The four previously missing Generic find/exists examples are present.
