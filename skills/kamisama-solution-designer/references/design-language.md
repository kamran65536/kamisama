# KamiSama Design Language

Use YAML for readable authoring and the JSON Schema at `../schema/kamisama-design.schema.json` for validation. A design file is creation input. `agent/solution-map.yaml` is the maintained inventory of verified implementation. Neither replaces C# as the source of domain behavior.

## Document Model

Every file uses `version: 1` and may contain any subset of:

| Key | Purpose | Merge identity |
| --- | --- | --- |
| `includes` | Relative YAML files to load first | Normalized path |
| `hints` | Non-binding generator preferences | Property name |
| `solution` | Solution name, root, props, and solution file | Single object |
| `modules` | Bounded contexts, panels, infrastructure, or libraries | `name` |
| `bootstrap` | Composition project and module registrations | Single object; registrations by `module` |
| `external-services` | Remote/runtime dependencies | `name` |
| `servers` | Executable, daemon, panel, worker, or AppHost utilities | `name` |

Paths are relative to the file that declares them unless a field explicitly says it is relative to the solution root. Names are stable merge identities and should be valid C#-friendly identifiers or dotted project names as appropriate.

## Includes and Merge

1. Resolve includes depth-first and relative to the including file.
2. Detect normalized-path cycles and report the include chain.
3. Merge included documents before the including document.
4. Merge objects by property and named arrays by the identities above. Nested named arrays use `name`; services use `name`; properties and parameters use `name`; APIs use `name`; endpoints use `operation`; pages use `name`; content nodes use `id` when present.
5. Coalesce identical values and additive named children.
6. Treat unequal scalar values, incompatible kinds, duplicate unnamed content, and conflicting type/route/ownership definitions as structural conflicts. Show both source locations and ask which is intended.
7. Preserve the modular source files. The effective merged design is an in-memory preview/input, not a new generated YAML file.

## Hints

`hints` affect generation but do not declare architecture or behavior. Supported hints cover namespaces, folders, nullable/implicit-usings preferences, template use, preview detail, and arbitrary string annotations. A hint cannot override an explicit design field or verified solution convention.

## Types and Inference

Data types can be `enum`, `value-object`, or `record`. Entities belong to bounded-context modules. A property declares a C#-level type string and may describe nullability, collection shape, key/search/display/edit behavior, defaults, and hints. Keep type expressions high-level in YAML; resolve exact namespaces and implementation using the `KamiSama Libraries` skill and existing code.

An item may carry `inferred: true` when directly derived from stronger declarations:

- CRUD on an entity may infer add/update/delete/find/list contracts, repository shape, DTOs, requests, and search model.
- A page action or API may infer a panel-owned orchestration service and client adapter.
- A form/grid field may infer a panel DTO property, not a domain entity property, unless the entity is also explicit.
- A server module reference may infer a project reference, not registration API syntax.

Preview all inferences. Ask when type, ownership, input/output, transaction boundary, authorization, or called bounded contexts cannot be determined structurally. Once accepted and implemented, record the concrete result in `agent/solution-map.yaml`.

## Services and Schedules

Services are operation-specific. `kind` distinguishes command, query, CRUD, orchestration, hosted service, and external client. `input`, `output`, `key-type`, `calls`, and `transaction` describe high-level contracts. Put domain behavior in C#.

A hosted service may declare one or more schedule windows. Each window uses a time zone, start/end local times, optional weekdays, interval, and overlap policy. A window is scheduling topology, not retry/error/domain behavior. Confirm overnight interpretation when `end` is earlier than `start`; do not invent it.

## APIs

An API belongs to a module or server and contains operation-specific endpoints. Each endpoint declares method, route, service, optional request/response types, authorization, and paging. `authorization: inherited` is allowed only when a verified enclosing policy exists. UI authorization does not secure an endpoint.

## Pages and Formal Content

A page declares a stable name, route, page kind, optional entity/service, authorization, parameters, actions, and a formal `content` tree. Content is not free-form Razor. Each node has a `kind` and optional stable `id`, binding, fields, columns, actions, and child content.

Supported content kinds are `section`, `text`, `field`, `form`, `grid`, `search`, `actions`, `component`, `tabs`, `tab`, `details`, `empty-state`, and `validation-summary`. Fields distinguish `visible` from `editable`; columns and fields can omit technical metadata by default. Actions identify service/route, confirmation, list refresh, and explicit capability requirements.

For panel CRUD, use list/detail/save pages only for supported operations. The save page uses an optional ID for add/edit modes. Keep delete on the list through `kamisama-delete-button` unless explicitly requested elsewhere. Reload DTO state after updates or mutation commands.

## Solution Map

Use the same schema for `agent/solution-map.yaml`, but omit `includes` and planned-only entries. Keep it concise enough for discovery while recording:

- solution and projects/modules with references
- bounded contexts, providers, entities, data types, contracts, services, and repositories
- Bootstrap registrations and external services
- servers, hosted schedules, APIs, pages, orchestration, and Aspire resources
- important ownership/call relationships and whether a recorded element originated as an accepted inference

Verify the map against `.slnx`, project files, and focused C# before relying on it for implementation.
