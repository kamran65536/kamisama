---
name: kamisama-solution-designer
description: Use when designing, generating, or reconciling a KamiSama solution from modular YAML definitions under agent/design.
---

# KamiSama Solution Designer

1. Read `agent/design/solution.yaml` and resolve its includes recursively.
2. Merge non-conflicting definitions; report contradictory duplicates instead of choosing silently.
3. Preview the smallest concrete project, contract, operation, or page change before implementation.
4. Prefer installed `kamisama-*` templates and inspect template help before hand-building a project.
5. Keep bounded contexts provider-neutral and mutually unaware; keep every panel's contracts, DTOs, orchestration, APIs, and UI isolated.
6. Use the KamiSama libraries skill for exact API names when it is installed.
7. Treat design YAML as reusable creation input and `agent/solution-map.yaml` as the authoritative maintained map of implemented state.
8. Verify the map against `.slnx`, project references, and focused source files after every implementation change.

Read `references/design-language.md` for semantics and `references/design-schema.yaml` for the supported high-level shape.
