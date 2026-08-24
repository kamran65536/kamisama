---
name: kamisama-solution-designer
description: Use when designing, previewing, scaffolding, or synchronizing a KamiSama solution from modular YAML design files or agent/solution-map.yaml, including bounded contexts, providers, hosts, APIs, services, and Blazor panels. Do not use for isolated implementation work that does not change or consume the solution design.
---

# KamiSama Solution Designer

Turn modular YAML designs into the smallest correct KamiSama solution changes. Keep the design and map high-level; C# remains authoritative for domain behavior and implementation details.

## Load First

1. Load the `KamiSama Libraries` skill before selecting namespaces, generic parameters, attributes, modules, repository bases, or feature APIs.
2. Read every requested design file and resolve its `includes` recursively relative to the including file.
3. Read `agent/solution-map.yaml` when it exists, then inspect the `.slnx`, affected project files, references, and focused source files. Create the map only when implementation begins and no map exists.
4. Read [references/design-language.md](references/design-language.md) and validate each source design against [schema/kamisama-design.schema.json](schema/kamisama-design.schema.json).
5. Read [references/template-catalog.md](references/template-catalog.md) before invoking templates. Confirm installed options with `dotnet new <short-name> --help` rather than guessing.

## Workflow

1. **Resolve and merge.** Expand includes depth-first, reject include cycles, and merge `solution`, `modules`, `bootstrap`, `external-services`, and `servers` by the identities documented in the design-language reference. Preserve source files; do not flatten or rewrite the user's modular design unless requested.
2. **Clarify structure.** Ask one focused question for contradictory definitions or ambiguity in names, ownership, project boundaries, references, routes, contracts, inputs, outputs, provider selection, transaction ownership, or generated artifacts. During design, do not ask for domain validation, state transitions, or operation internals unless those details are necessary to determine structure.
3. **Infer conservatively.** Infer entities, properties, services, APIs, and panel orchestration only where pages, actions, types, and conventional CRUD provide direct evidence. Mark inferred items with `inferred: true`. Ask before implementation when ownership, contract shape, bounded-context calls, authorization boundary, or transaction behavior remains ambiguous.
4. **Preview.** Show only the effective high-level change: project/folder tree, type names and signatures, routes, pages/content, APIs, inferred services, template invocations, and map changes. Do not dump generated files. Obtain confirmation when the user is still designing; proceed directly when the user has explicitly asked to implement an unambiguous design.
5. **Scaffold.** Invoke the narrowest templates from the catalog. Use explicit output paths, inspect template help, pass layout-correct `PropsPath`, keep `props.xml` opt-in, and avoid speculative projects. Do not generate an Aspire AppHost; Visual Studio owns that project.
6. **Implement.** Replace all template placeholders, remove irrelevant artifacts, and implement behavior in C#. Keep contracts in Abstractions, provider-neutral domain and persistence in Core, providers in provider projects, composition in Bootstrap, and executable hosting in Server/AppHost projects. Keep bounded contexts independent and panel contracts, DTOs, orchestration, client adapters, pages, and APIs isolated per panel.
7. **Verify.** Inspect `.slnx`, project/package references, namespaces, provider configuration, secrets/placeholders, API authorization, cancellation-token flow, `PagedResult<T>` use, routes, direct API access, and hosted-service schedules. Format touched code and build/test the narrowest affected project or solution.
8. **Sync the map.** Update `agent/solution-map.yaml` from verified implementation after every create, discover, rename, removal, or behavioral capability change. Record accepted inferences. The map describes implemented structure, not planned work, and must agree with `.slnx`, project references, and focused C# source.

## Non-Negotiable Rules

- C# is authoritative for behavior. YAML records intent and high-level topology; the solution map records verified implemented topology.
- Never silently choose a winner for conflicting includes or duplicate identities.
- Never infer credentials, package versions, registration APIs, domain rules, authorization policy, or migration/initialization behavior.
- Use one contract and implementation per operation. Prefer KamiSama CRUD feature contracts and bases when their verified signatures fit.
- Return `PagedResult<T>` for multi-item operations and pass cancellation tokens through Client, Server, panel Core, and bounded-context services.
- Keep repositories limited to persistence/query logic. Keep domain rules in bounded-context services and cross-context workflows in panel Core orchestration.
- Do not expose persistence metadata or editable controls without explicit user value and capability. UI flags never replace Server/Core authorization.
- Keep secrets out of tracked configuration. A fixed PostgreSQL password is allowed only in an explicitly local/development Aspire design.
- Aspire support is limited to requested local AppHost functions, resource references, flags, schedule/startup relationships, and dependencies.

## Design Assets

- [Design language](references/design-language.md)
- [Template invocation catalog](references/template-catalog.md)
- [JSON Schema](schema/kamisama-design.schema.json)
- [Composed example](examples/solution.yaml)
- [Financial bounded context](examples/financial.yaml)
- [Daemon host](examples/daemon.yaml)
- [UserPanel](examples/user-panel.yaml)
- [AdminPanel](examples/admin-panel.yaml)
