# KamiSama Solution Structure and Orchestration

## Target Solution Structure

`Solution` and `XPanel` are naming placeholders. Repeat the bounded-context projects for each BC and the panel projects for each panel.

```text
Solution.slnx
props.xml                              Shared project configuration
BoundedContext.Abstractions/
  DataTypes/                           BC enums and value types
  Services/<service-category>/
    Features.cs                        BC service interfaces
    Dtos.cs                            DTOs used by those interfaces
  Globals.cs                           Reusable global usings
BoundedContext.Core/
  Entities/                            BC entities
  Services/<service-category>/         BC service implementations
  Repositories/
    Abstractions/                      Internal repository interfaces
    Configuration/                     EF Core configurations, when needed
    Implementations/                   Internal repository implementations
    Database/BoundedContextDbContext.cs Provider-neutral context
  BoundedContextModule.cs              WebModule and builder extension
  BoundedContextOptions.cs             Options from IConfigurationSection
  Globals.cs
BoundedContext.<database-provider>/
  Repositories/                        Provider-specific context and migrations
XPanel.Abstractions/
  DataTypes/                           Panel-owned enums and value types
  Services/<service-category>/
    Features.cs                        Exposed orchestration service interfaces
    Dtos.cs                            Panel-owned DTOs
  Globals.cs
XPanel.Core/
  Services/<service-category>/         Cross-BC orchestration and type mapping
  XPanelModule.cs                      Panel orchestration module
  XPanelOptions.cs                     Optional orchestration options
  Globals.cs
XPanel.Server/
  Controllers/                         Client proxy endpoints calling orchestration
  Components/                          Server-side UI and account pages
  Program.cs                           Panel-owned module initialization
XPanel.Client/
  Pages/                               Client pages
  Components/                          UI components and design elements
  Layout/                              UI layouts/layers
  Services/<service-category>/         Client-side service proxies
Solution.Initialization.Server/
  Initializers/                        Database initialization implementations
  Program.cs                           One-time database initialization entry point
Solution.AppHost/                      Aspire configuration
Solution.ServiceDefaults/              Aspire service defaults
```

Folder names illustrate responsibilities; retain established project conventions when applying the structure.

## How Services Are Provided

Client pages/components call client-side service proxies. Proxies call API controllers in `XPanel.Server`. Controllers delegate to services exposed through `XPanel.Abstractions` and implemented in `XPanel.Core`. Orchestration calls BC services through `BoundedContext.Abstractions` and maps all exposed results back to panel-owned contracts.

### XPanel.Client

Contains design elements, pages, components, UI layers/layouts, and client-side service proxies. Uses `XPanel.Abstractions` for contracts. Some design elements may live in `XPanel.Server`.

### XPanel.Server

Hosts service API controllers as the endpoints for client proxies. Owns account management and exclusive server-side pages such as change password. Each panel initializes its own modules here, including BC Core and database-provider registrations needed by that panel. Registration references do not permit controllers to bypass orchestration or expose BC contracts.

### XPanel.Core

Owns orchestration across bounded contexts and usually has no custom database. May reference multiple BC Abstractions projects and call their services in one orchestration feature. Business-service dependencies use BC abstractions; references to BC Core/provider implementations are an architectural smell and should normally be refactored away.

Connections between independent BC concepts belong here. For example, an orchestration service connects Board Management's `Person`, Notifications' `NotificationRecipient`, and KamiSama Identities' `ApplicationUser`. Do not add a BC-to-BC reference to implement that connection.

### XPanel.Abstractions

Contains exposed orchestration data types, DTOs, and service contracts. Used by `XPanel.Core`, `XPanel.Client`, and `XPanel.Server`. Must define its own contracts and must not reference or expose BC data types, DTOs, or services. Map all BC types, even when panel types have exactly the same structure. Duplication is acceptable and required to preserve these boundaries.

### Bounded-Context Projects

`BoundedContext.Abstractions` exposes BC contracts to orchestration. `BoundedContext.Core` owns entities, business services, and internal repository interfaces and implementations. `BoundedContext.<database-provider>` owns provider-specific database integration.

No BC may interact with or reference another BC, including the other BC's Abstractions project. Cross-BC coordination must go through `XPanel.Core`. Repository interfaces and implementations remain internal to `BC.Core`; external orchestration uses BC services. BC Core remains unaware of provider implementations.

## Solution.Initialization.Server

This is the solution's one-time database initialization service. It contains database initializers and runs them to initialize the databases, then completes. It is a separate executable responsibility from panels and their request-serving services.

Database initializers previously placed in `Solution.Bootstrap` belong here. Existing KamiSama database initializer implementations may use `DatabaseInitializerBase<T>`. Register the dependencies needed to run those initializers in this service. Each panel still owns its own runtime module initialization in `XPanel.Server`; the initialization service is not a shared panel composition module.

The project name is `Solution.Initialization.Server`, not `Solution.Initializer`. No dedicated initialization template or new template parameter is established by this document. Do not invent one or claim that an existing template already generates this structure.

## Bootstrap Deprecation

The `kamisama-bootstrap` template and the `Solution.Bootstrap` project structure will be deprecated. Keep the existing template and `BootstrapProject` parameter documented for compatibility; their presence does not make Bootstrap part of the target architecture.

The existing Bootstrap structure combines database initializers with shared module configuration. Its replacement separates those responsibilities:

- Database initialization belongs in `Solution.Initialization.Server`.
- Panel module initialization belongs in each `XPanel.Server`.

Documenting this transition does not remove the template, change its available parameters, or authorize refactoring an existing solution. If template output conflicts with the requested structure, explain the mismatch and ask the user instead of inventing a replacement command.

## Additional Boundaries

- `*.Abstractions` contains contracts, DTOs, enums/value types, annotations, and metadata, with almost no behavior. Validation annotations are allowed.
- Cross-BC transactions are discouraged; if unavoidable, orchestration owns them.
- `Globals.cs` contains reusable global usings.
- Do not resolve significant architectural conflicts by guessing; ask the user.

## Template Catalog

Actual template names, parameters, and defaults are documented in [template-usage.md](template-usage.md). That catalog includes the Bootstrap template scheduled for deprecation. The target architecture above does not rename or add CLI templates.
