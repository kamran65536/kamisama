---
last-checked-utc: 2026-08-14T23:24:08Z
root-version: 10.0.0
classes-without-examples: []
---

# Documentation Snapshot

The package description, public API summaries, usage guidance, persistence and concurrency caveats, and class-level example coverage were reviewed against the source at the recorded root version.

## Description

Lazy-loading JSON file repository with synchronous and asynchronous query and mutation APIs.
It caches entities in memory and rewrites an existing JSON array file after each mutation, with important failure, atomicity, and concurrency limitations.

## How to use

```shell
dotnet add package KamiSama.Repositories.Json --version 10.0.0
```

Point `JsonRepository<TEntity>` at an existing valid JSON array file and subscribe to `LoadFailed` and `SaveFailed`. The repository cannot initialize a missing file. Mutations rewrite the complete file non-atomically, `Update` only persists changes already made to a cached object, and save failures leave the changed cache in memory while otherwise completing normally. Queries are live, locking is per instance, separate instances or processes can overwrite one another, and duplicate semantics follow the configured comparer.

## Example decisions

`KamiSama.Repositories.Json.JsonRepository<TEntity>` has a full-name-matched class example. No class exemptions are required, and repository examples are excluded from short-name test-snippet fallback to prevent cross-package contamination.
