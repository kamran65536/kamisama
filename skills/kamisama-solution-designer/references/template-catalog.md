# Template Invocation Catalog

These are the agreed planned short names for solution-designer workflows. Availability and options may evolve. Before invocation, run `dotnet new list kamisama` and `dotnet new <short-name> --help`; never substitute an older template name or invent an option.

| Planned short name | Use for | Expected design input |
| --- | --- | --- |
| `kamisama-solution` | Solution shell, `.slnx`, agent guidance, optional props | `solution` |
| `kamisama-bc` | Bounded-context Abstractions/Core pair | `modules[kind=bounded-context]` |
| `kamisama-provider` | Provider project for a bounded-context Core | `module.providers[]` |
| `kamisama-bootstrap` | Reusable composition root | `bootstrap` |
| `kamisama-server` | Executable ASP.NET Core or worker host | `servers[kind=web|worker|daemon]` |
| `kamisama-type` | Enum, value object, record, entity, or DTO skeleton | `data-types[]`, `entities[]` |
| `kamisama-crud` | Bounded-context CRUD contracts/repository/features | `entities[].crud` |
| `kamisama-feature` | One operation-specific service/feature | `services[]` |
| `kamisama-panel-crud` | Panel-isolated contracts, orchestration, client, API, pages | panel `pages[]`/`apis[]` and target entity |
| `kamisama-aspire-local` | Local AppHost utility functions/resources only | `servers[kind=apphost].resources` |
| `kamisama-delete-button` | Confirmed panel delete action/component | page content/action with delete semantics |

## Invocation Rules

1. Preview commands with resolved names and paths before scaffolding when operating from a design discussion.
2. Use `-n` and `-o` explicitly. Pass only options confirmed by template help.
3. Keep shared `props.xml` opt-in. When selected, calculate `PropsPath` from each generated project directory.
4. Generate only the narrowest structural artifact. Use `kamisama-feature` instead of regenerating CRUD; use `kamisama-type` instead of regenerating a bounded context.
5. Do not run a template over implemented files without inspecting collision behavior and obtaining confirmation for replacements.
6. Add generated projects to `.slnx` only if the template did not. Remove unused starter artifacts and unresolved placeholders.
7. `kamisama-aspire-local` updates utilities in an existing Visual Studio-created AppHost; it never creates AppHost.

## Architecture Mapping

| Artifact | Owner |
| --- | --- |
| contracts, DTOs, shared domain data types | bounded-context or panel Abstractions |
| entities, domain features, provider-neutral repository contracts/implementations | bounded-context Core |
| migrations and concrete database integration | provider project |
| cross-context panel orchestration and mappings | panel Core |
| HTTP adapters and Razor pages | panel Client |
| controllers and executable hosting | panel/server project |
| reusable module composition | Bootstrap |
| local resource wiring | existing AppHost |
