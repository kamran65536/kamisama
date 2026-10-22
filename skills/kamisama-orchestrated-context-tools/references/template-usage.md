# KamiSama Template Usage - Raw Content

## Architecture Transition

The `kamisama-bootstrap` template and Bootstrap project structure will be deprecated. Their options remain documented below for compatibility. The target structure uses `Solution.Initialization.Server` for one-time database initialization and each `XPanel.Server` for its own module initialization. See [orchestrated-context-tools.md](orchestrated-context-tools.md). No dedicated initialization template is documented; do not invent a replacement command or rename existing template parameters.

## Solution Template

- To create a new KamiSama solution, use `kamisama-solution`, which has these configurations:
  - `CreateSolutionDirectory`: Creates a directory named after the solution instead of generating directly in the selected location. Possible values: `true`, `false`. Default: `false`.
  - `UseProps`: Creates an opt-in shared `props.xml` file at the solution root. Possible values: `true`, `false`. Default: `false`.
  - `IncludeKamiSamaLibrariesSkill`: Packages the KamiSama public API guidance under `.agents/skills/kamisama-libraries/`. Possible values: `true`, `false`. Default: `true`.
  - `IncludeSolutionDesignerSkill`: Packages the modular YAML solution-design guidance under `.agents/skills/kamisama-solution-designer/`. Possible values: `true`, `false`. Default: `true`.

## Project Templates

- Compatibility only; this template and its Bootstrap project structure will be deprecated. To create a Bootstrap project, use `kamisama-bootstrap`, which has these configurations:
  - `UseProps`: Includes the shared props file in the generated project. Possible values: `true`, `false`. Default: `false`.
  - `PropsPath`: Path from the generated project to the shared props file. Possible values: any valid relative or absolute file path. Default: `../props.xml`.

- To create a bounded context's Abstractions and Core projects, use `kamisama-bc`, which has these configurations:
  - `Context`: Bounded-context name used in project names, namespaces, and generated files. Possible values: any valid bounded-context name. Required.
  - `UseProps`: Includes the shared props file in the generated projects. Possible values: `true`, `false`. Default: `false`.
  - `PropsPath`: Path from each generated project to the shared props file. Possible values: any valid relative or absolute file path. Default: `../props.xml`.

- To create a bounded context database-provider project, use `kamisama-provider`, which has these configurations:
  - `Context`: Bounded-context name used in the provider project, namespaces, and generated files. Possible values: any valid bounded-context name. Required.
  - `UseProps`: Includes the shared props file in the generated project. Possible values: `true`, `false`. Default: `false`.
  - `PropsPath`: Path from the generated project to the shared props file. Possible values: any valid relative or absolute file path. Default: `../props.xml`.
  - `Provider`: Selects the database provider. Possible values: `Postgresql`, `Sqlite`, `SqlServer`, `Oracle`. Default: `Postgresql`.
  - `CoreProject`: Path from the generated provider project to the bounded-context Core project. Possible values: any valid relative project path. Required.

- To create a Server or panel project set, use `kamisama-server`, which has these configurations:
  - `Server`: Server or panel name used in project names, namespaces, and generated files. Possible values: any valid server or panel name. Required.
  - `IncludeClient`: Adds a hosted Blazor WebAssembly client with Blazor Bootstrap. Possible values: `true`, `false`. Default: `false`.
  - `BootstrapProject`: Compatibility option for the Bootstrap structure scheduled for deprecation. Optional path from the generated Server project to the solution Bootstrap project. Possible values: an empty value or any valid relative project path. Default: empty.
  - `UseProps`: Includes the shared props file in the generated projects. Possible values: `true`, `false`. Default: `false`.
  - `PropsPath`: Path from each generated project to the shared props file. Possible values: any valid relative or absolute file path. Default: `../props.xml`.

## Item Templates

- To add Aspire local-development helpers to an existing AppHost, use `kamisama-aspire-local`, which has these configurations:
  - `Namespace`: C# namespace for the generated helpers. Possible values: any valid C# namespace. Required.

- To add CRUD contracts, repository code, and features to a bounded context, use `kamisama-crud`, which has these configurations:
  - `Solution`: Solution name used in namespaces and generated files. Possible values: any valid solution name. Required.
  - `Context`: Bounded-context name used in namespaces and generated files. Possible values: any valid bounded-context name. Required.
  - `ServiceCategory`: Service-category name used in namespaces, folders, and generated files. Possible values: any valid service-category name. Required.
  - `KeyType`: C# type used for entity keys. Possible values: any valid C# type name. Default: `Guid`.

- To add a Blazor Bootstrap delete button, use `kamisama-delete-button`, which has these configurations:
  - `Namespace`: C# namespace for the generated component. Possible values: any valid C# namespace. Required.

- To add a single feature operation, use `kamisama-feature`, which has these configurations:
  - `Operation`: Selects the feature operation to generate. Possible values: `Add`, `Update`, `Delete`, `FindById`, `List`. Default: `FindById`.
  - `Namespace`: C# namespace for the generated operation. Possible values: any valid C# namespace. Required.
  - `ServiceCategory`: Service-category name used in namespaces, folders, and generated files. Possible values: any valid service-category name. Required.
  - `KeyType`: C# type used for entity keys. Possible values: any valid C# type name. Default: `Guid`.

- To add CRUD contracts, orchestration, client integration, API, and pages to a panel, use `kamisama-panel-crud`, which has these configurations:
  - `Solution`: Solution name used in namespaces and generated files. Possible values: any valid solution name. Required.
  - `Panel`: Panel name used in namespaces, folders, and generated files. Possible values: any valid panel name. Required.
  - `ServiceCategory`: Service-category name used in namespaces, folders, and generated files. Possible values: any valid service-category name. Required.
  - `PageCategory`: Page-category name used in client folders, routes, and generated files. Possible values: any valid page-category name. Required.
  - `KeyType`: C# type used for entity keys. Possible values: any valid C# type name. Default: `Guid`.

- To add an entity or shared data type, use `kamisama-type`, which has these configurations:
  - `Type`: Selects the kind of type to generate. Possible values: `Entity`, `DataType`. Default: `Entity`.
  - `Namespace`: C# namespace for the generated type. Possible values: any valid C# namespace. Required.
  - `KeyType`: C# type used for an entity key. Possible values: any valid C# type name. Default: `Guid`.
