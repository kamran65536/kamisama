# KamiSama Templates

`KamiSama.Templates` is a template-first toolkit for designing and composing .NET 10 KamiSama solutions. It creates a solution shell with optional agent skills, focused bounded-context and hosting projects, and item-level scaffolds for common domain and panel work.

## Install and inspect

```console
dotnet new install KamiSama.Templates
dotnet new list kamisama
dotnet new kamisama-server --help
```

The package exposes exactly 11 short names:

| Short name | Creates |
| --- | --- |
| `kamisama-solution` | A `.slnx`, design/map YAML, agent guidance, selectable skills, and optional `props.xml` |
| `kamisama-bc` | `<Solution>.<Context>.Abstractions` and `<Solution>.<Context>.Core` projects |
| `kamisama-provider` | One `<Solution>.<Context>.<Provider>` EF Core project |
| `kamisama-bootstrap` | A reusable `<Solution>.Bootstrap` composition project |
| `kamisama-server` | `<Solution>.<Server>.Abstractions`, `.Core`, and `.Server`, with an optional `.Client` |
| `kamisama-type` | An Entity or DataType item |
| `kamisama-crud` | A bounded-context CRUD vertical slice |
| `kamisama-feature` | One Add, Update, Delete, FindById, or List operation |
| `kamisama-panel-crud` | Panel contracts, orchestration, API, clients, and Blazor pages for CRUD |
| `kamisama-aspire-local` | Local Aspire database and initialization-environment helper methods |
| `kamisama-delete-button` | A Blazor Bootstrap confirmation/delete component |

The old `kamisama-admin`, `kamisama-empty`, `kamisama-bounded-context`, `kamisama-database-support`, and `kamisama-orchestration` commands are breaking-retired, not aliases. `kamisama-solution` and `kamisama-bootstrap` remain, but follow the redesigned manifests; inspect their current help before reusing old automation.

## Design first, generate second

Start at the solution root, then describe intent before adding projects:

```console
dotnet new kamisama-solution -n Shop -o Shop --UseProps true
cd Shop
```

1. Read `GETTING_STARTED.md`, `AGENTS.md`, and `agent/solution-map.yaml`.
2. Describe reusable intent in `agent/design/solution.yaml` and its included YAML files.
3. Use `.agents/skills/kamisama-solution-designer/` to resolve the design and preview the smallest change.
4. Inspect `dotnet new <short-name> --help`, generate only the required projects/items, and add projects to `Shop.slnx`.
5. Build, then update `agent/solution-map.yaml` to match implemented state.

The solution shell includes both `kamisama-libraries` and `kamisama-solution-designer` skills by default. Select them independently with `--IncludeKamiSamaLibrariesSkill false` or `--IncludeSolutionDesignerSkill false`; the surrounding guidance remains usable when either skill is omitted.

## Compose projects

Use the project naming convention `<Solution>.<Context/Server>.<Role>` and generate into the solution root:

```console
dotnet new kamisama-bc -n Shop --Context Catalog -o . --UseProps true
dotnet new kamisama-provider -n Shop --Context Catalog -o . --Provider Postgresql --CoreProject ../Shop.Catalog.Core/Shop.Catalog.Core.csproj --UseProps true
dotnet new kamisama-bootstrap -n Shop.Bootstrap -o . --UseProps true
dotnet new kamisama-server -n Shop --Server Admin -o . --IncludeClient true --BootstrapProject ../Shop.Bootstrap/Shop.Bootstrap.csproj --UseProps true

dotnet sln Shop.slnx add Shop.Catalog.Abstractions/Shop.Catalog.Abstractions.csproj
dotnet sln Shop.slnx add Shop.Catalog.Core/Shop.Catalog.Core.csproj
dotnet sln Shop.slnx add Shop.Catalog.Postgresql/Shop.Catalog.Postgresql.csproj
dotnet sln Shop.slnx add Shop.Bootstrap/Shop.Bootstrap.csproj
dotnet sln Shop.slnx add Shop.Admin.Abstractions/Shop.Admin.Abstractions.csproj
dotnet sln Shop.slnx add Shop.Admin.Core/Shop.Admin.Core.csproj
dotnet sln Shop.slnx add Shop.Admin.Client/Shop.Admin.Client.csproj
dotnet sln Shop.slnx add Shop.Admin.Server/Shop.Admin.Server.csproj
dotnet build Shop.slnx
```

`--UseProps false` is the default and emits local `net10.0`, nullable, and implicit-usings settings. `kamisama-solution --UseProps true` creates root `props.xml`; other project templates only import an existing file. Their default `--PropsPath ../props.xml` is relative to each generated project, so override it when placing projects deeper.

## Place item templates deliberately

Item templates write relative to `--output`; run them from the solution root (or set `-o` to it), not from an arbitrary project directory:

```console
dotnet new kamisama-type -n Product -o . --Type Entity --Namespace Shop.Catalog
dotnet new kamisama-crud -n Product -o . --Solution Shop --Context Catalog --ServiceCategory Products
dotnet new kamisama-feature -n Product -o Shop.Catalog.Core --Operation FindById --Namespace Shop.Catalog --ServiceCategory Products
dotnet new kamisama-panel-crud -n Product -o . --Solution Shop --Panel Admin --ServiceCategory Products --PageCategory Catalog
dotnet new kamisama-aspire-local -n AspireLocalExtensions -o Shop.AppHost --Namespace Shop.AppHost
dotnet new kamisama-delete-button -n DeleteButton -o Shop.Admin.Client --Namespace Shop.Admin
```

`kamisama-type` and `kamisama-feature` place files under `Entities`/`DataTypes` and `Services/<ServiceCategory>` beneath the chosen output. CRUD templates encode their target project paths and must be generated at the common solution root. Aspire Local and DeleteButton place files in the chosen output's root and `Components` folder respectively.

These items are intentional scaffolds, not finished domain behavior. Generated `TODO(ai)` markers and `NotImplementedException` bodies identify domain properties, mappings, filtering, authorization, validation, UI fields, and persistence behavior that must be completed before treating the capability as production-ready.

For every parameter and generated path, see the [template guide](https://gitlab.com/kamran65536/KamiSama/-/tree/master/docs/content/topics/10-templates.md).
