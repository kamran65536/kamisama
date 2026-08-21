# Getting Started

1. Inspect the generated solution and existing projects before adding code.
2. Build the current solution with `dotnet build`.
3. Add only the templates needed for the intended architecture.

## Templates

- `kamisama-solution`: solution shell, optional `props.xml`, and agent guidance.
- `kamisama-empty`: minimal class library.
- `kamisama-bounded-context`: independent Abstractions and provider-neutral Core projects. Use it when a domain boundary owns contracts and behavior.
- `kamisama-database-support`: one provider project for an existing bounded-context Core project.
- `kamisama-bootstrap`: reusable shared composition root for Identity and Ticketing modules.
- `kamisama-orchestration`: canonical Abstractions/Core platform source with optional client and server hosting.
- `kamisama-admin`: complete Blazor administration solution composed from orchestration and bootstrap sources.

Discover current options with `dotnet new <short-name> --help`. Prefer `kamisama-bounded-context` for business capabilities and `kamisama-bootstrap` when multiple hosts share module registration.

## Aspire

.NET Aspire is optional orchestration tooling, not a hidden template dependency. Install the official templates with `dotnet new install Aspire.ProjectTemplates`, inspect them with `dotnet new list aspire`, and use `dotnet new aspire` or `dotnet new aspire-starter` according to the installed template version. Keep AppHost and ServiceDefaults projects explicit in the solution.

Read `AGENTS.md`, `.agents/instructions/architecture.md`, and `.agents/skills/solution-scaffolding/SKILL.md` before restructuring the solution.
