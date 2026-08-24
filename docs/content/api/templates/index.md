# KamiSama.Templates

`KamiSama.Templates` supplies 11 template-first .NET 10 solution, project, and item templates. Install it to turn a modular YAML solution design into explicitly named bounded contexts, providers, composition roots, servers, domain operations, panel CRUD, and local Aspire helpers.

Current documented version: `{{ version }}`

## Install

```shell
dotnet new install KamiSama.Templates::{{ version }}
dotnet new list kamisama
```

## Developer guide

See [KamiSama template design and usage](../../topics/10-templates.md) for the exact 11-template catalog, current options, generated structures, selectable solution skills, shared props behavior, naming conventions, composition workflow, and item-template placement and completion caveats.

The old `kamisama-admin`, `kamisama-empty`, `kamisama-bounded-context`, `kamisama-database-support`, and `kamisama-orchestration` commands are breaking-retired. `kamisama-solution` and `kamisama-bootstrap` remain with redesigned behavior; use current `--help` output rather than old command assumptions.

## Uninstall

```shell
dotnet new uninstall KamiSama.Templates
```

[Back to package index](../index.md) | [Documentation home](../../index.md)
