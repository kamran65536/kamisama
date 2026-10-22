---
name: kamisama-orchestrated-context-tools
description: Use when Codex needs to translate plain-language KamiSama solution, bounded-context, provider, server, CRUD, feature, panel, entity, or template requests into brief questions and previewed dotnet new kamisama-* commands without executing them unless explicitly authorized.
---

# KamiSama Orchestrated Context Tools

Translate the user's plain request into KamiSama template usage and architecture-aware guidance.

## Required References

Before answering a KamiSama template or orchestration request, read:

- [references/orchestrated-context-tools.md](references/orchestrated-context-tools.md) for solution structure and architectural boundaries.
- [references/template-usage.md](references/template-usage.md) for template names, parameters, required values, and defaults.

Treat those references as the source of truth. Do not invent templates, parameters, project dependency rules, or architectural exceptions beyond what they state.

## Default Behavior

For ordinary requests, do not create files, edit files, or run commands. Instead:

1. Identify the matching `dotnet new kamisama-*` template or templates.
2. Infer obvious names from the conversation, using PascalCase for C# solution, context, server, panel, category, and type names.
3. Ask only for missing required values and important options that affect generated structure.
4. Include defaults inline when the reference defines them.
5. Show the exact command or commands that would be run.
6. Stop and wait.

Execute commands only when the user explicitly authorizes execution in the current turn.

## Question Style

Keep questions brief and bounded. Prefer a numbered list with one property per line.

Ask for optional properties only when they materially affect the output, such as `UseProps`, `PropsPath`, provider choice, client project generation, or included skills. Bootstrap wiring is a compatibility option for the structure scheduled for deprecation.

Do not overexplain architecture. Mention a boundary only when it changes the command choice or prevents a requested dependency, such as:

- Bounded contexts must not interact with or reference each other, including Abstractions projects.
- Cross-BC orchestration belongs in `XPanel.Core`; panel contracts must map all BC types, even when identical.
- Each `XPanel.Server` owns its module initialization; `Solution.Initialization.Server` runs database initializers once.
- The `kamisama-bootstrap` template and Bootstrap project structure will be deprecated; retain their documentation for compatibility.
- Repository abstractions and implementations stay internal to `BC.Core`.

## Command Preview

Render command previews as PowerShell blocks.

Use template names from the reference:

- `kamisama-solution`
- `kamisama-bootstrap` (will be deprecated, together with the Bootstrap project structure)
- `kamisama-bc`
- `kamisama-provider`
- `kamisama-server`
- `kamisama-aspire-local`
- `kamisama-crud`
- `kamisama-delete-button`
- `kamisama-feature`
- `kamisama-panel-crud`
- `kamisama-type`

No dedicated initialization template is documented. Do not invent a template or parameter for `Solution.Initialization.Server`. If architecture and template output conflict, ask the user before resolving the conflict.

If several templates are needed, show them in the likely execution order. Do not imply they have been run.

## Examples

For "I want a solution named mahestan", ask for:

1. `CreateSolutionDirectory`? default `false`
2. Use `props.xml`? default `false`
3. Include `kamisama-libraries` skill? default `true`
4. Include `kamisama-solution-designer` skill? default `true`

Then preview:

```powershell
dotnet new kamisama-solution -n Mahestan --CreateSolutionDirectory <true|false> --UseProps <true|false> --IncludeKamiSamaLibrariesSkill <true|false> --IncludeSolutionDesignerSkill <true|false>
```

For "add PostgreSQL support for notifications", ask for:

1. Use `props.xml`? default `false`
2. `PropsPath`? default `../props.xml`
3. `CoreProject` path? for example `../Notifications.Core/Notifications.Core.csproj`

Then preview:

```powershell
dotnet new kamisama-provider --Context Notifications --Provider Postgresql --CoreProject "../Notifications.Core/Notifications.Core.csproj" --UseProps <true|false> --PropsPath "../props.xml"
```
