# KamiSama.Templates

`KamiSama.Templates` provides seven composable .NET project and solution templates for KamiSama applications. It covers solution and agent guidance, minimal projects, bounded contexts, generic provider projects, reusable Bootstrap composition, optional client/server orchestration, and the complete Blazor administration layout.

Current documented version: `{{ version }}`

## Install

```shell
dotnet new install KamiSama.Templates::{{ version }}
```

List the installed templates:

```shell
dotnet new list kamisama
```

## Documentation

See [KamiSama template architecture and usage](../../topics/10-templates.md) for all seven short names and every public option. The guide documents opt-in `props.xml`, required Database Support project paths and provider-based naming, Bootstrap module providers and Ticketing's Identity infrastructure, Admin/Orchestration Create versus Existing behavior, generated `GETTING_STARTED.md`/`AGENTS.md` files, Aspire tooling, and Visual Studio limitations.

## Uninstall

```shell
dotnet new uninstall KamiSama.Templates
```

[Back to package index](../index.md) | [Documentation home](../../index.md)
