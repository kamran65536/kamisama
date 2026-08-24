# Getting Started

1. Restart OpenCode so `opencode.json` discovers the selected project skills.
2. Inspect the generated `.slnx`, `AGENTS.md`, `agent/design/*.yaml`, and `agent/solution-map.yaml`.
3. Inspect current options with `dotnet new <short-name> --help`, scaffold only required projects/items, complete `TODO(ai)` markers, and build the narrowest affected target.

## Project Scaffolds

- `kamisama-solution`: AI-enabled solution shell with optional solution folder, `props.xml`, and packaged skills.
- `kamisama-bc`: solution-prefixed Abstractions and provider-neutral Core projects for one bounded context.
- `kamisama-provider`: one PostgreSQL, SQLite, SQL Server, or Oracle project for a bounded context.
- `kamisama-bootstrap`: ordered shared composition and initialization project.
- `kamisama-server`: solution-prefixed Abstractions/Core/Server projects with an optional Blazor Client.

## Item Scaffolds

- `kamisama-type`: entity or data type.
- `kamisama-crud`: bounded-context CRUD contracts, repository, mappings, and feature services.
- `kamisama-feature`: one Add, Update, Delete, FindById, or List operation.
- `kamisama-panel-crud`: panel DTOs, orchestration, API, client adapters, and List/Details/Save pages.
- `kamisama-aspire-local`: local AppHost database and initialization environment helpers; it does not create Aspire projects.
- `kamisama-delete-button`: confirmed asynchronous deletion with Blazor Bootstrap success/failure toasts.

Templates create deterministic scaffolds, not arbitrary domain fields or business behavior. Keep bounded contexts independent, implement cross-context workflows in panel Core, update `agent/solution-map.yaml` after verified changes, and use only packaged skill folders present in the generated shell.
