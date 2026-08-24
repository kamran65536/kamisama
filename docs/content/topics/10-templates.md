# 10. KamiSama.Templates

`KamiSama.Templates` provides 11 focused .NET 10 templates for a template-first solution-design workflow. The package creates an inspectable solution shell, composes projects with explicit boundaries and references, and scaffolds domain or panel work without pretending generated TODOs are completed business behavior.

## Install and inspect

```shell
dotnet new install KamiSama.Templates::{{ version }}
dotnet new list kamisama
dotnet new kamisama-solution --help
dotnet new kamisama-server --help
```

Install a local `.nupkg` by path when validating an unpublished package. Uninstall its reported source before switching back to the published package:

```shell
dotnet new uninstall KamiSama.Templates
```

The CLI help generated from each installed manifest is authoritative. All templates also accept standard template-engine options such as `-n|--name`, `-o|--output`, and `--force`.

## Catalog and migration

The package exposes exactly these short names:

| Short name | Kind | Purpose |
| --- | --- | --- |
| `kamisama-solution` | Solution | Creates the design-enabled solution root, optional shared props, and selectable agent skills. |
| `kamisama-bc` | Project group | Creates a bounded context's Abstractions and provider-neutral Core projects. |
| `kamisama-provider` | Project | Adds one EF Core provider project to an existing bounded context. |
| `kamisama-bootstrap` | Project | Creates a reusable web composition root. |
| `kamisama-server` | Project group | Creates server contracts, Core, and host projects, with optional hosted Blazor client and Bootstrap reference. |
| `kamisama-type` | Item | Creates an Entity or DataType. |
| `kamisama-crud` | Item group | Scaffolds a bounded-context CRUD vertical slice. |
| `kamisama-feature` | Item | Scaffolds one Add, Update, Delete, FindById, or List operation. |
| `kamisama-panel-crud` | Item group | Scaffolds panel-owned CRUD contracts, orchestration, API, clients, and pages. |
| `kamisama-aspire-local` | Item | Adds local Aspire database/migration helpers. |
| `kamisama-delete-button` | Item | Adds a Blazor Bootstrap confirmation/delete component. |

The old seven-template package is not preserved through aliases. `kamisama-admin`, `kamisama-empty`, `kamisama-bounded-context`, `kamisama-database-support`, and `kamisama-orchestration` are breaking-retired. `kamisama-solution` and `kamisama-bootstrap` retain their names but use redesigned manifests and generated content, so old options must not be assumed.

## Template-first solution design

Create the shell before generating application projects:

```shell
dotnet new kamisama-solution -n Shop -o Shop --UseProps true
cd Shop
dotnet build Shop.slnx
```

The shell is deliberately empty. Its generated structure is:

```text
Shop/
|-- Shop.slnx
|-- props.xml                         # only with --UseProps true
|-- GETTING_STARTED.md
|-- AGENTS.md
|-- agent/
|   |-- solution-map.yaml             # maintained implemented state
|   `-- design/
|       |-- solution.yaml             # reusable design entry point
|       |-- bounded-contexts.yaml
|       `-- panels.yaml
`-- .agents/
    |-- instructions/
    |-- prompts/
    |-- commands/
    `-- skills/
        |-- solution-scaffolding/
        |-- kamisama-libraries/        # selectable
        `-- kamisama-solution-designer/# selectable
```

Use the generated workflow in this order:

1. Inspect the `.slnx`, `AGENTS.md`, and `agent/solution-map.yaml`.
2. Describe reusable intent in `agent/design/solution.yaml` and resolve its includes recursively.
3. Use the solution-designer skill to merge non-conflicting definitions and preview the smallest concrete change.
4. Prefer an installed `kamisama-*` template, inspect its current help, and generate only projects/items required by the design.
5. Add projects explicitly to the root `.slnx`, build the narrowest target, and update `agent/solution-map.yaml` to verified implemented state.

Design YAML is creation input, while `agent/solution-map.yaml` tracks what actually exists. Neither replaces verification against the solution, project references, and source.

### Solution options

| Option | Type | Default | Behavior |
| --- | --- | --- | --- |
| `--CreateSolutionDirectory` | bool | `false` | Places all output in a new solution-named directory. |
| `--UseProps` | bool | `false` | Creates root `props.xml`. |
| `--IncludeKamiSamaLibrariesSkill` | bool | `true` | Includes exact KamiSama public-API guidance. |
| `--IncludeSolutionDesignerSkill` | bool | `true` | Includes modular YAML solution-design guidance. |

The two skills are independent. All four include/exclude combinations are valid; `AGENTS.md`, design YAML, solution scaffolding guidance, prompts, and commands remain when either optional skill is excluded.

## Naming and shared props

Use `<Solution>.<Context/Server>.<Role>` consistently:

```text
Shop.Catalog.Abstractions
Shop.Catalog.Core
Shop.Catalog.Postgresql
Shop.Admin.Abstractions
Shop.Admin.Core
Shop.Admin.Client
Shop.Admin.Server
Shop.Bootstrap
```

For `kamisama-bc`, `kamisama-provider`, and `kamisama-server`, pass the solution prefix through `--name` and the middle segment through `--Context` or `--Server`. For Bootstrap, pass the complete project name, such as `Shop.Bootstrap`.

Shared MSBuild properties are opt-in:

- `kamisama-solution --UseProps true` creates `props.xml` at the solution root.
- BC, Provider, Bootstrap, and Server default to local `net10.0`, implicit-usings, and nullable settings.
- Their `--UseProps true` mode imports an existing file; it never creates one.
- `--PropsPath` is enabled only with `--UseProps true` and defaults to `../props.xml`, relative to each generated project file.

The generated root props sets `TargetFramework`, implicit usings, nullable, and a fallback `RootNamespace` that removes `.Abstractions`, `.Core`, `.Postgresql`, `.Sqlite`, `.SqlServer`, and `.Oracle`. Generated projects also set the intended shared namespace explicitly. Override the path for deeper layouts:

```shell
dotnet new kamisama-server -n Shop --Server Admin -o src \
  --UseProps true --PropsPath ../../props.xml
```

## Project templates

### Bounded context (`kamisama-bc`)

```shell
dotnet new kamisama-bc -n Shop -o . --Context Catalog --UseProps true
```

Generated projects:

```text
Shop.Catalog.Abstractions/Shop.Catalog.Abstractions.csproj
Shop.Catalog.Core/Shop.Catalog.Core.csproj
```

Abstractions owns contracts and DTOs. Core references Abstractions and owns provider-neutral entities, repositories, services, mappings, and module registration. Keep bounded contexts mutually unaware and add concrete persistence with `kamisama-provider`.

| Option | Type | Default | Behavior |
| --- | --- | --- | --- |
| `--Context` | string | Required | Bounded-context segment. |
| `--UseProps` | bool | `false` | Imports shared props in both projects. |
| `--PropsPath` | string | `../props.xml` | Import path, enabled only with `--UseProps true`. |

### Database provider (`kamisama-provider`)

```shell
dotnet new kamisama-provider -n Shop -o . \
  --Context Catalog \
  --Provider Postgresql \
  --CoreProject ../Shop.Catalog.Core/Shop.Catalog.Core.csproj \
  --UseProps true
```

This creates `Shop.Catalog.Postgresql/Shop.Catalog.Postgresql.csproj`. The provider project references the explicit Core path and one `KamiSama.Repositories.EntityFrameworkCore.<Provider>` package.

| Option | Type | Default | Behavior |
| --- | --- | --- | --- |
| `--Context` | string | Required | Bounded-context segment. |
| `--Provider` | choice | `Postgresql` | Selects `Postgresql`, `Sqlite`, `SqlServer`, or `Oracle`. |
| `--CoreProject` | string | Required | Path from the generated provider project to its Core project. |
| `--UseProps` | bool | `false` | Imports shared props. |
| `--PropsPath` | string | `../props.xml` | Import path, enabled only with `--UseProps true`. |

The template does not discover or validate the Core project during generation. Supply a path that will be valid from the generated provider directory.

### Bootstrap (`kamisama-bootstrap`)

```shell
dotnet new kamisama-bootstrap -n Shop.Bootstrap -o . --UseProps true
```

This creates `Shop.Bootstrap/Shop.Bootstrap.csproj` and `BootstrapModule.cs`, a reusable composition root based on `KamiSama.Modules`. Add application/module registration deliberately after generation.

| Option | Type | Default | Behavior |
| --- | --- | --- | --- |
| `--UseProps` | bool | `false` | Imports shared props. |
| `--PropsPath` | string | `../props.xml` | Import path, enabled only with `--UseProps true`. |

### Server (`kamisama-server`)

```shell
dotnet new kamisama-server -n Shop -o . --Server PublicApi --UseProps true

dotnet new kamisama-server -n Shop -o . \
  --Server Admin \
  --IncludeClient true \
  --BootstrapProject ../Shop.Bootstrap/Shop.Bootstrap.csproj \
  --UseProps true
```

Base output:

```text
Shop.Admin.Abstractions/Shop.Admin.Abstractions.csproj
Shop.Admin.Core/Shop.Admin.Core.csproj
Shop.Admin.Server/Shop.Admin.Server.csproj
Shop.Admin.Client/Shop.Admin.Client.csproj       # only with --IncludeClient true
```

The Server host references Abstractions and Core. `--IncludeClient true` adds a hosted Blazor WebAssembly client and Blazor Bootstrap wiring. A non-empty `--BootstrapProject` adds that project reference and calls its `BootstrapModule`; an empty value generates no Bootstrap dependency. Client and Bootstrap choices are independent, so Server supports all four combinations.

| Option | Type | Default | Behavior |
| --- | --- | --- | --- |
| `--Server` | string | Required | Server or panel segment. |
| `--IncludeClient` | bool | `false` | Includes the hosted Blazor WebAssembly Client project. |
| `--BootstrapProject` | string | Empty | Optional path from the generated Server project to a Bootstrap project. |
| `--UseProps` | bool | `false` | Imports shared props in all generated projects. |
| `--PropsPath` | string | `../props.xml` | Import path, enabled only with `--UseProps true`. |

## Item templates

Item templates place files relative to `--output`; they do not locate a solution or project automatically. Generate `kamisama-crud` and `kamisama-panel-crud` at the common solution root because their source paths include target project names. Generate Type and Feature into the intended project root, and Aspire Local/DeleteButton into their intended AppHost/Client root.

### Type (`kamisama-type`)

```shell
dotnet new kamisama-type -n Product -o Shop.Catalog.Core \
  --Type Entity --Namespace Shop.Catalog --KeyType Guid
```

| Option | Type | Default | Behavior |
| --- | --- | --- | --- |
| `--Type` | choice | `Entity` | Selects `Entity` or `DataType`. |
| `--Namespace` | string | Required | Base namespace written to the generated type. |
| `--KeyType` | string | `Guid` | Entity key type; also replaces the token in the selected scaffold. |

Entity output is `Entities/<name>.cs`; DataType output is `DataTypes/<name>.cs`.

### Single feature (`kamisama-feature`)

```shell
dotnet new kamisama-feature -n Product -o Shop.Catalog.Core \
  --Operation FindById --Namespace Shop.Catalog \
  --ServiceCategory Products --KeyType Guid
```

| Option | Type | Default | Behavior |
| --- | --- | --- | --- |
| `--Operation` | choice | `FindById` | Selects `Add`, `Update`, `Delete`, `FindById`, or `List`. |
| `--Namespace` | string | Required | Base namespace. |
| `--ServiceCategory` | string | Required | Folder and namespace category below `Services`. |
| `--KeyType` | string | `Guid` | Replaces the operation's key token. |

Output is `Services/<ServiceCategory>/<Operation><name>.cs` (`List` pluralizes the generated filename as `List<name>s.cs`). Each operation body throws `NotImplementedException` until its domain-specific load/map/validate/persist logic is implemented.

### Bounded-context CRUD (`kamisama-crud`)

```shell
dotnet new kamisama-crud -n Product -o . \
  --Solution Shop --Context Catalog --ServiceCategory Products --KeyType Guid
```

| Option | Type | Default | Behavior |
| --- | --- | --- | --- |
| `--Solution` | string | Required | Solution prefix used in target project paths and namespaces. |
| `--Context` | string | Required | Bounded-context segment. |
| `--ServiceCategory` | string | Required | Service folder/category. |
| `--KeyType` | string | `Guid` | Entity and DTO key type. |

The scaffold spans `Shop.Catalog.Abstractions` and `Shop.Catalog.Core`: DTOs/contracts, entity, repository abstraction/implementation, feature definition, mappings, and five CRUD services. It expects those BC projects to exist.

### Panel CRUD (`kamisama-panel-crud`)

```shell
dotnet new kamisama-panel-crud -n Product -o . \
  --Solution Shop --Panel Admin \
  --ServiceCategory Products --PageCategory Catalog --KeyType Guid
```

| Option | Type | Default | Behavior |
| --- | --- | --- | --- |
| `--Solution` | string | Required | Solution prefix. |
| `--Panel` | string | Required | Server/panel segment. |
| `--ServiceCategory` | string | Required | Contract, service, client, and controller category. |
| `--PageCategory` | string | Required | Blazor page folder/category. |
| `--KeyType` | string | `Guid` | Panel DTO key type. |

The scaffold spans the panel's Abstractions, Core, Server, and Client projects. It creates panel-owned DTOs/contracts, orchestration stubs, controller, HTTP clients, and List/Details/Save pages without leaking bounded-context DTOs into the panel boundary.

### Aspire Local (`kamisama-aspire-local`)

```shell
dotnet new kamisama-aspire-local -n AspireLocalExtensions \
  -o Shop.AppHost --Namespace Shop.AppHost
```

`--Namespace` is required. The default item name is `AspireLocalExtensions`; output is `<name>.cs` at the selected AppHost root. It adds `AddDatabaseTo`, `AddMigration`, and `AddMigrationForAll` helpers and expects the host project to reference Aspire hosting APIs.

### DeleteButton (`kamisama-delete-button`)

```shell
dotnet new kamisama-delete-button -n DeleteButton \
  -o Shop.Admin.Client --Namespace Shop.Admin
```

`--Namespace` is required. The default item name is `DeleteButton`; output is `Components/<name>.razor`. The component uses Blazor Bootstrap `ConfirmDialog` and `ToastService`, so generate it only in a project with those dependencies and registrations.

## Item completion caveats

Item output is a structural starting point. Search generated files for `TODO(ai)` and `NotImplementedException` before declaring a capability complete. Typical required work includes:

- Domain properties, invariants, validation, and editable/searchable DTO fields.
- Request/entity/DTO mapping, filtering, ordering, paging, and persistence behavior.
- Panel-to-bounded-context orchestration and independent API authorization.
- Blazor controls, display fields, search/grid wiring, navigation, and error behavior.
- Concrete module names, environment mappings, resource references, and project/package references where needed.

Templates cannot infer arbitrary domain fields or safely authorize an application. Generated code may compile while still containing placeholder behavior, and single-feature/panel orchestration stubs intentionally throw until completed.

## Compose and build a root solution

```shell
mkdir Shop
cd Shop

dotnet new kamisama-solution -n Shop -o . --UseProps true
dotnet new kamisama-bc -n Shop -o . --Context Catalog --UseProps true
dotnet new kamisama-provider -n Shop -o . --Context Catalog --Provider Postgresql --CoreProject ../Shop.Catalog.Core/Shop.Catalog.Core.csproj --UseProps true
dotnet new kamisama-bootstrap -n Shop.Bootstrap -o . --UseProps true
dotnet new kamisama-server -n Shop -o . --Server Admin --IncludeClient true --BootstrapProject ../Shop.Bootstrap/Shop.Bootstrap.csproj --UseProps true

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

The templates do not infer solution folders, ordering, cross-boundary references, or an existing Bootstrap project. Keeping those steps explicit makes the generated architecture reviewable.

## See also

- [KamiSama.Templates package page](../api/templates/index.md)
- [KamiSama.Repositories.EntityFrameworkCore](../api/repositories-entityframeworkcore/index.md)
- [KamiSama.Modules](../api/modules/index.md)
