---
last-checked-utc: 2026-08-14T23:24:08Z
root-version: 10.0.0
classes-without-examples: []
---

# Documentation Snapshot

The package description, public API summaries, usage guidance, persistence and concurrency caveats, and class-level example coverage were reviewed against the source at the recorded root version.

## Description

Read-oriented XML directory repositories that load one entity per file into memory.
Version 10.0.0 has an incompatible default serializer and a broken mutation path, so use these types only for reads with an explicit per-entity serializer.

## How to use

```shell
dotnet add package KamiSama.Repositories.Xml --version 10.0.0
```

Treat both repository classes as read-only. Pass an `XmlSerializer` for one entity because the default serializer targets `TEntity[]` while loading each file as `TEntity`, and return each exact file name from the mapping function. Never claim or rely on durable XML mutation: add, update, and delete write to the directory path rather than mapped files, ignore the supplied serializer for output, never remove stale files, suppress save failures after raising `SaveFailed`, and do not roll back in-memory changes. One invalid or misnamed file fails the whole load, equal entities from separate files are silently collapsed, queries are live, and locking is per instance only.

## Example decisions

`KamiSama.Repositories.Xml.XmlFileRepository<TEntity>` and `KamiSama.Repositories.Xml.XmlDirectoryRepository<TEntity>` each have a separate full-name-matched, read-only class example. No class exemptions are required, and no example demonstrates XML mutation as working.
