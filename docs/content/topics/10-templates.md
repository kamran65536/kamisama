# 10. KamiSama.Templates

`KamiSama.Templates` is a NuGet template package for composing .NET 10 KamiSama solutions. The replacement architecture uses focused solution and project templates instead of the previous Core, Abstractions, Props, Database, and Blazor Admin template set.

## Install, Update, and Uninstall

Install the documented package version:

```shell
dotnet new install KamiSama.Templates::{{ version }}
```

List the installed templates or inspect one template's current command-line help:

```shell
dotnet new list kamisama
dotnet new kamisama-orchestration --help
```

Run `dotnet new install` again with the desired version to update the installed package. Uninstall the package and all templates supplied by it with:

```shell
dotnet new uninstall KamiSama.Templates
```

When testing a locally packed `.nupkg`, install by package path. Uninstall the source reported by `dotnet new uninstall` before switching between local and published packages.

## Template Catalog

The package exposes exactly these seven short names:

| Short name | Kind | Purpose |
| --- | --- | --- |
| `kamisama-solution` | Solution | Creates a solution root, agent guidance, and optional shared MSBuild props. |
| `kamisama-empty` | Project | Creates a minimal class library. |
| `kamisama-bounded-context` | Solution | Creates paired Abstractions and Core projects for one bounded context. |
| `kamisama-database-support` | Project | Adds one generic EF Core provider project to a Core project. |
| `kamisama-bootstrap` | Project | Creates the ASP.NET Core composition root and optional module registrations. |
| `kamisama-orchestration` | Solution | Creates Abstractions/Core plus optional Client and Server hosts. |
| `kamisama-admin` | Solution | Creates the administration variant of orchestration. |

Old short names and their options are not compatibility aliases. In particular, do not use `kamisama-props`, `kamisama-core`, `kamisama-abstractions`, `kamisama-database`, or `kamisama-blazor-admin` with the replacement package.

All templates also accept standard .NET template-engine arguments such as `-n|--name`, `-o|--output`, and `--force`. The tables below contain every additional public option defined by the KamiSama manifests; computed implementation symbols are not command-line options.

## Shared Props

Shared MSBuild settings are optional and use `props.xml`.

- `kamisama-solution --UseProps true` creates `props.xml` at the solution root.
- Project and composed-solution templates default `--UseProps` to `false` and emit local .NET 10 project properties.
- With `--UseProps true`, `--PropsPath` writes an import to an existing props file; it does not create that file.
- `--PropsPath` is enabled only when `--UseProps true`.

The generated `props.xml` sets `TargetFramework` to `net10.0`, enables implicit usings and nullable reference types, and derives `RootNamespace` from `MSBuildProjectName` after removing `.Abstractions`, `.Core`, `.Postgresql`, `.Sqlite`, `.SqlServer`, and `.Oracle` suffixes.

The default project import is `../props.xml`. Change it when project and props locations differ:

```shell
dotnet new kamisama-empty -n Store.Shared --UseProps true --PropsPath ../../props.xml
```

## Solution (`kamisama-solution`)

Creates `<name>.slnx`, repository-level `AGENTS.md`, and `.agents/`. The agent files are always created and are intended to be reviewed and extended with repository-specific build, test, architecture, and security guidance.

```shell
dotnet new kamisama-solution -n Store
dotnet new kamisama-solution -n Store --UseProps true
```

| Option | Type | Default | Behavior |
| --- | --- | --- | --- |
| `--UseProps` | bool | `false` | Includes `props.xml` when `true`. |

The solution also generates `GETTING_STARTED.md`. Read it with `AGENTS.md`, `.agents/instructions/architecture.md`, and `.agents/skills/solution-scaffolding/SKILL.md` before restructuring the solution. `AGENTS.md` is the repository entry point that coding agents discover; `.agents/` contains reusable instructions, prompts, commands, and skills. These files do not install or configure an AI tool.

## Empty Project (`kamisama-empty`)

Creates a minimal .NET 10 class library with a starter class. Use it for infrastructure or integration projects that do not need the bounded-context layout.

```shell
dotnet new kamisama-empty -n Store.Notifications
dotnet new kamisama-empty -n Store.Notifications --UseProps true
```

| Option | Type | Default | Behavior |
| --- | --- | --- | --- |
| `--UseProps` | bool | `false` | Imports shared MSBuild properties when `true`. |
| `--PropsPath` | string | `../props.xml` | Import path, enabled only when `--UseProps true`. |

## Bounded Context (`kamisama-bounded-context`)

Creates `<name>.Abstractions`, `<name>.Core`, and a solution file. Abstractions owns contracts and DTOs; Core owns the implementation and provider-neutral persistence types. Add concrete persistence separately with `kamisama-database-support`.

```shell
dotnet new kamisama-bounded-context -n Catalog
dotnet new kamisama-bounded-context -n Catalog --UseProps true --PropsPath ../props.xml
```

| Option | Type | Default | Behavior |
| --- | --- | --- | --- |
| `--UseProps` | bool | `false` | Configures both projects to import shared MSBuild properties. |
| `--PropsPath` | string | `../props.xml` | Import path, enabled only when `--UseProps true`. |
| `--IncludeExample` | bool | `false` | Includes a sample contract and attributed implementation. |

## Database Support (`kamisama-database-support`)

Creates one provider-specific project that references an explicit Core project. It uses the generic `KamiSama.Repositories.EntityFrameworkCore.<Provider>` packages and is not restricted to module-specific database packages.

```shell
dotnet new kamisama-database-support \
  -n Catalog \
  --Provider Postgresql \
  --CoreProject ../Catalog.Core/Catalog.Core.csproj

dotnet new kamisama-database-support \
  -n Catalog \
  --Provider SqlServer \
  --CoreProject ../Catalog.Core/Catalog.Core.csproj
```

| Option | Type | Default | Behavior |
| --- | --- | --- | --- |
| `--UseProps` | bool | `false` | Imports shared MSBuild properties when `true`. |
| `--PropsPath` | string | `../props.xml` | Import path, enabled only when `--UseProps true`. |
| `--Provider` | choice | `Postgresql` | Selects `Postgresql`, `Sqlite`, `SqlServer`, or `Oracle`. |
| `--CoreProject` | string | Required; no default | Explicit path from the generated provider project to the Core project it references. |

Pass the bounded-context name without a provider suffix. `-n Catalog --Provider Postgresql` generates the `Catalog.Postgresql` provider project; `Sqlite`, `SqlServer`, and `Oracle` produce the corresponding suffix. The provider controls generated type/file names and the generic `KamiSama.Repositories.EntityFrameworkCore.<Provider>` package. `--CoreProject` is required because the template does not discover or verify a Core project during generation.

## Bootstrap (`kamisama-bootstrap`)

Creates the ASP.NET Core bootstrap project and composition root. User Management and Ticketing are independent switches; each selected module has its own provider choice.

```shell
dotnet new kamisama-bootstrap -n Store.Bootstrap

dotnet new kamisama-bootstrap \
  -n Support.Bootstrap \
  --UserManagement true \
  --UserManagementProvider Sqlite \
  --Ticketing true \
  --TicketingProvider Postgresql
```

| Option | Type | Default | Behavior |
| --- | --- | --- | --- |
| `--UseProps` | bool | `false` | Imports shared MSBuild properties when `true`. |
| `--PropsPath` | string | `../props.xml` | Import path, enabled only when `--UseProps true`. |
| `--UserManagement` | bool | `false` | Adds User Management registration and package references. |
| `--Ticketing` | bool | `false` | Adds Ticketing registration and package references. |
| `--UserManagementProvider` | choice | `Postgresql` | Selects `Postgresql` or `Sqlite`; enabled with User Management or Ticketing. |
| `--TicketingProvider` | choice | `Postgresql` | Selects `Postgresql` or `Sqlite`; enabled only with Ticketing. |

### Module and Provider Matrix

| Bootstrap feature | PostgreSQL | SQLite | SQL Server | Oracle |
| --- | --- | --- | --- | --- |
| Bootstrap without either module | No module provider required | No module provider required | No module provider required | No module provider required |
| User Management | Supported | Supported | Not available | Not available |
| Ticketing | Supported | Supported | Not available | Not available |

User Management and Ticketing currently publish only PostgreSQL and SQLite module providers. SQL Server and Oracle remain available to application-owned bounded contexts through `kamisama-database-support`; they are not valid values for either Bootstrap module-provider option.

Ticketing requires Identity infrastructure. Therefore `--Ticketing true` includes Identity Core plus the provider selected by `--UserManagementProvider`, even when `--UserManagement false`. This hidden infrastructure dependency does not enable User Management contracts, endpoints, pages, or administration UI; those remain controlled by `--UserManagement`.

## Orchestration (`kamisama-orchestration`)

Creates Abstractions and Core projects, with optional Blazor Client and ASP.NET Core Server projects. A generated Server can create its own Bootstrap code or reference an existing Bootstrap project.

```shell
dotnet new kamisama-orchestration -n Store

dotnet new kamisama-orchestration \
  -n Store \
  --IncludeClient true \
  --IncludeServer true \
  --UserManagement true \
  --Ticketing true
```

| Option | Type | Default | Behavior |
| --- | --- | --- | --- |
| `--UseProps` | bool | `false` | Configures generated projects to import shared MSBuild properties. |
| `--PropsPath` | string | `../props.xml` | Import path, enabled only when `--UseProps true`. |
| `--IncludeClient` | bool | `false` | Includes the Blazor client project. |
| `--IncludeServer` | bool | `false` | Includes an ASP.NET Core Server project. |
| `--UserManagement` | bool | `false` | Includes user contracts, services, endpoints, and client features where applicable. |
| `--Ticketing` | bool | `false` | Includes ticket contracts, services, endpoints, and client features where applicable. |
| `--BootstrapMode` | choice | `Create` | Selects `Create` or `Existing`; enabled only with `--IncludeServer true`. |
| `--BootstrapProject` | string | `Example.Bootstrap/Example.Bootstrap.csproj` | Existing Bootstrap project path relative to the generated solution root; enabled only for a Server in `Existing` mode. |
| `--UserManagementProvider` | choice | `Postgresql` | Selects `Postgresql` or `Sqlite`; enabled when Server and User Management or Ticketing are selected. |
| `--TicketingProvider` | choice | `Postgresql` | Selects `Postgresql` or `Sqlite`; enabled when Server and Ticketing are selected. |

With `--IncludeServer true`, both modes generate the Server. `Create` additionally generates `<name>.Bootstrap` and references it from Server. `Existing` does not generate Bootstrap; Server references `--BootstrapProject`, and the existing project is added to the generated `.slnx`. Use a real path relative to the generated solution root because dynamic project discovery is not performed. Provider options configure generated Server settings and, in `Create` mode, the generated Bootstrap source.

## Admin (`kamisama-admin`)

Creates the administration-oriented orchestration layout. Client and Server participation are fixed on, while User Management, Ticketing, and Bootstrap ownership remain selectable.

```shell
dotnet new kamisama-admin -n Store.Admin

dotnet new kamisama-admin \
  -n Store.Admin \
  --UserManagement true \
  --Ticketing false \
  --BootstrapMode Existing \
  --BootstrapProject ../Store.Bootstrap/Store.Bootstrap.csproj
```

| Option | Type | Default | Behavior |
| --- | --- | --- | --- |
| `--UseProps` | bool | `false` | Configures generated projects to import shared MSBuild properties. |
| `--PropsPath` | string | `../props.xml` | Import path, enabled only when `--UseProps true`. |
| `--UserManagement` | bool | `true` | Includes authorized user-administration endpoints and UI. |
| `--Ticketing` | bool | `true` | Includes authorized ticket endpoints and UI. |
| `--UserManagementProvider` | choice | `Postgresql` | Selects `Postgresql` or `Sqlite`; enabled with User Management or Ticketing. |
| `--TicketingProvider` | choice | `Postgresql` | Selects `Postgresql` or `Sqlite`; enabled with Ticketing. |
| `--BootstrapMode` | choice | `Create` | Selects `Create` or `Existing`. |
| `--BootstrapProject` | string | `Example.Bootstrap/Example.Bootstrap.csproj` | Existing Bootstrap project path relative to the generated solution root, enabled only in `Existing` mode. |

### Existing Bootstrap Usage

Admin always generates Client and Server. In the default `Create` mode it additionally generates `<name>.Bootstrap`. Use `BootstrapMode Existing` when a reusable Bootstrap project already exists: Admin still generates Server, but Server references the supplied Bootstrap project instead of generating a new one. Admin also generates `GETTING_STARTED.md`, `AGENTS.md`, and `.agents/` at its solution root.

```shell
dotnet new kamisama-bootstrap \
  -n Store.Bootstrap \
  --UserManagement true \
  --UserManagementProvider Postgresql \
  --Ticketing true \
  --TicketingProvider Postgresql

dotnet new kamisama-admin \
  -n Store.Admin \
  --BootstrapMode Existing \
  --BootstrapProject ../Store.Bootstrap/Store.Bootstrap.csproj \
  --UserManagementProvider Postgresql \
  --TicketingProvider Postgresql
```

The Admin switches control Admin contracts, endpoints, and UI. Configure matching module registrations and providers in the existing Bootstrap project; Admin does not rewrite it.

## Compose a Solution

The focused templates can be combined without hidden defaults:

```shell
mkdir Store
cd Store

dotnet new kamisama-solution -n Store -o . --UseProps true
dotnet new kamisama-bounded-context -n Catalog -o . --UseProps true
dotnet new kamisama-database-support -n Catalog -o . --UseProps true --Provider Postgresql --CoreProject ../Catalog.Core/Catalog.Core.csproj
dotnet new kamisama-bootstrap -n Store.Bootstrap -o Store.Bootstrap --UseProps true --UserManagement true --UserManagementProvider Postgresql
dotnet new kamisama-admin -n Store.Admin -o Store.Admin --UseProps true --PropsPath ../../props.xml --BootstrapMode Existing --BootstrapProject ../Store.Bootstrap/Store.Bootstrap.csproj
```

Add generated projects to the root `.slnx` as needed. The replacement templates do not infer an arbitrary existing solution's desired folders or project ordering.

## Aspire Tooling

There is no KamiSama Aspire template and Aspire is not a hidden dependency. The generated `GETTING_STARTED.md` directs you to install and inspect the official templates:

```shell
dotnet new install Aspire.ProjectTemplates
dotnet new list aspire
dotnet new aspire-starter -n Store.AppHost
```

Template names vary by installed Aspire version, so inspect `dotnet new list aspire` and use `dotnet new aspire` or `dotnet new aspire-starter` as available. Current official guidance uses the Aspire CLI, which can install its templates when needed:

```shell
aspire new aspire-starter -n Store.AppHost -o Store.AppHost
aspire run
```

Follow the current official [.NET Aspire prerequisites](https://learn.microsoft.com/dotnet/aspire/get-started/prerequisites/), [Aspire CLI installation](https://learn.microsoft.com/dotnet/aspire/get-started/install-cli/), and [first application](https://learn.microsoft.com/dotnet/aspire/get-started/build-your-first-aspire-app) guidance for the installed version. Keep AppHost and ServiceDefaults projects explicit in the solution. `KamiSama.Templates` does not install Aspire, create those projects, or modify IDE workloads.

## Visual Studio and Post-Actions

The .NET CLI is the authoritative interface for the replacement architecture. Visual Studio's template UI does not consistently expose item/solution templates, conditional parameters, or dynamically enabled choices such as `PropsPath`, provider options, and existing-Bootstrap paths.

Template post-actions also cannot dynamically select and invoke arbitrary templates based on every Visual Studio choice. The Solution template's post-action is informational: it tells the user to open `GETTING_STARTED.md`; it does not generate the other six templates. The package therefore exposes focused templates rather than pretending that one wizard can safely compose every layout. If an IDE reports that a post-action was skipped, follow its printed manual instruction; for deterministic composition, generate with `dotnet new` and then open the resulting `.slnx` in Visual Studio.

Visual Studio does not make unsupported combinations valid. User Management and Ticketing still require PostgreSQL or SQLite, and existing Bootstrap paths still need to identify a real project.

## See Also

- [KamiSama.Templates package page](../api/templates/index.md)
- [KamiSama.Repositories.EntityFrameworkCore](../api/repositories-entityframeworkcore/index.md)
- [KamiSama.Modules](../api/modules/index.md)
- [KamiSama.Modules.Identity.Core](../api/modules-identity-core/index.md)
- [KamiSama.Modules.Ticketing.Core](../api/modules-ticketing-core/index.md)
