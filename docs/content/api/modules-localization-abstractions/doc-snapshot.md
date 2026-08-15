---
last-checked-utc: 2026-08-14T23:59:09Z
root-version: 10.0.0
classes-without-examples:
  - KamiSama.Modules.Localization.Features.CultureInfoDto
---

# Documentation Snapshot

The package description, public API summaries, implementation-neutral contract semantics, and example coverage were reviewed against the source at the recorded root version.

## Description

Provider-neutral localization feature contracts and culture metadata for listing, reading, and selecting application cultures.
Reference this package when callers or implementations should not depend on the ASP.NET Core localization module.

## How to use

```shell
dotnet add package KamiSama.Modules.Localization.Abstractions --version 10.0.0
```

Inject the three feature interfaces into application code or implement them in another provider. The contracts do not define storage, request integration, cancellation guarantees, validation, or whether returned arrays are snapshots.

## Example decisions

All three interfaces have full-name-scoped usage examples and exact full-name-and-member examples. The simple positional `CultureInfoDto` record is exempt from a class-level example because its documented constructor parameters completely describe its data shape.
