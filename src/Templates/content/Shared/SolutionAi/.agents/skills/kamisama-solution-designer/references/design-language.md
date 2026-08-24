# Design Language Reference

Design files support solution, bounded-context, and panel scopes. Split concerns into included YAML files and keep paths relative to the including file.

- Solution design declares projects, optional shared props, Bootstrap composition, and local Aspire utilities. Do not generate an AppHost unless explicitly requested; Visual Studio may own it.
- Bounded-context design declares entities, data types, contracts, operation services, repositories, and providers. Each element must map to a template or explicit implementation.
- Panel design declares panel-owned pages, fields, actions, APIs, client adapters, DTOs, and Core orchestration. Infer missing orchestration only when ownership and behavior are unambiguous.
- Ambiguous ownership, transaction behavior, inputs, outputs, or conflicting duplicate definitions require one focused question before implementation.
- Accepted implementation details belong in `agent/solution-map.yaml`; update it whenever projects, relationships, providers, capabilities, pages, or APIs change.

The schema is intentionally high-level. Extend a design with clear lower-level mappings only when a concrete generator or implementation workflow consumes them.
