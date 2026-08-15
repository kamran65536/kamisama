# KamiSama.Modules.Ticketing.Core

[Back to package index](../index.md)

Version: `10.0.0`

## Description

ASP.NET Core Ticketing implementation with EF Core entities, validated ticket workflows, repositories, scoped features, modular registration, and startup database initialization. Install it with at least the selected PostgreSQL or SQLite provider and review the documented registration and authorization limitations before exposing its features.

## How to use

```shell
dotnet add package KamiSama.Modules.Ticketing.Core --version 10.0.0
```

**Publication mismatch:** `10.0.0` in the required install command is the current workspace/root documentation version. NuGet exposed `10.0.11` as the latest package when this surface was reviewed; `10.0.0` itself was not available.

Install Core plus at least the selected provider package. Configure one provider key and connection string, pass the matching provider callback, and finish through `BuildAsync` before resolving Ticketing features:

```json
{
  "Ticketing": {
    "initialization": {
      "migrate": true,
      "initialize": false,
      "test-data": false
    },
    "database": {
      "provider": "postgresql",
      "connection-string": "Host=localhost;Database=ticketing;Username=app;Password=..."
    }
  }
}
```

```csharp
using KamiSama.Modules;
using KamiSama.Modules.Ticketing;

var webBuilder = WebApplication.CreateBuilder(args);
IConfigurationSection ticketing = webBuilder.Configuration.GetSection("Ticketing");

ExtendedWebApplicationBuilder builder = webBuilder.Extend()
    .AddTicketingModule(
        ticketing,
        ticketing.GetSection("database"),
        database => database.AddPostgresqlTicketingDbContext());

WebApplication app = await builder.BuildAsync(CancellationToken.None);
```

`AddTicketingModule` only queues work. During `BuildAsync`, `ConfigureServices` binds named `ConnectionStringOption` and `DataInitializationOptions`, scans the Core assembly for attributed scoped services, creates `IMultiProviderDbContextBuilder<TicketingDbContext>`, selects `__EFMigrationsHistory_Ticketing`, and invokes the provider callback. The callback may register both installed providers, but the lowercased configured key selects one base-context alias. Although nullable in the signature, the callback is required in a normal host unless an equivalent keyed context registration already exists.

After the application is built, Ticketing creates a scope, resolves `IDatabaseInitializer<TicketingDbContext>` or a migration-only default initializer, reads the named initialization options, and runs selected stages. The default initializer migrates when `migrate` is true; `initialize` and `test-data` do no work unless the host registers a custom initializer. Startup therefore needs database connectivity, schema privileges, and compatible provider migrations. Core maps no controllers, endpoints, middleware, authentication, or authorization.

**Registration limitation:** `DeleteTicketCategory`, `ListTicketCategories`, and `ExistsTicketCategoryByName` carry scoped auto-registration attributes for specialized contracts they do not implement. These descriptors cannot create the requested service. Service-provider validation can therefore fail during `BuildAsync`; without validation, resolving `IDeleteTicketCategory`, `IListTicketCategories`, or `IExistsTicketCategoryByName` fails. The other attributed features and both repositories are assignable registrations.

**Query and mutation limitations:** ticket search applies text across title/comments, status, priority, and ticket-or-comment author filters but ignores `TicketCategoryId`. It recognizes `priority`, `status`, and `updatedat`; every other token orders by priority then update time. Category name lookup/filtering lowercases both operands, category names have no unique database index, and duplicate checks are separate read-before-write operations. Repository mutations save immediately with no cross-operation transaction supplied by these features.

`UpdateTicketComment.UpdateAsync` ignores its method key and targets `request.CommentId`. Comment and attachment additions trust caller-supplied author identifiers, and comment addition also trusts the requested user/operator side. Comment update and attachment addition compare only author identifiers; attachment removal and ticket-state update perform no ownership check. Ticket-state updates permit unchanged status, open or reopened to resolved, and resolved to reopened or closed; invalid transitions throw `ConflictException`. Other mutation features do not consistently call `Ticket.IsEditable`. Add authenticated endpoint authorization, ownership and side checks, and identifier-consistency validation before exposing these services.

Entities store external attachment content IDs only. Provider migrations create required category-to-ticket, ticket-to-comment, and comment-to-attachment relationships with cascading deletes, non-unique relationship indexes, 50/100/400 character limits, and integer enums. Provider registration enables lazy-loading proxies; list and lookup queries are tracked, so complete DTO mapping depends on navigations being available. No controllers exist in this package.

## Namespaces

- [KamiSama.Modules.Ticketing](kamisama-modules-ticketing/index.md) (1 types)
- [KamiSama.Modules.Ticketing.Entities](kamisama-modules-ticketing-entities/index.md) (4 types)
- [KamiSama.Modules.Ticketing.Repositories.Database](kamisama-modules-ticketing-repositories-database/index.md) (1 types)

## Types

- [KamiSama.Modules.Ticketing.ExtendedWebApplicationBuilderExtensions](kamisama-modules-ticketing/kamisama-modules-ticketing-extendedwebapplicationbuilderextensions/index.md) - Adds Ticketing service discovery, multi-provider context setup, and named database initialization to an extended builder. A matching provider callback is required in normal hosts; the module maps no controllers or endpoints.
- [KamiSama.Modules.Ticketing.Entities.Ticket](kamisama-modules-ticketing-entities/kamisama-modules-ticketing-entities-ticket/index.md) - EF Core ticket aggregate root with a required category, comments, attachment references, workflow state, priority, author, and timestamps. `CanTransitionTo` exposes Core's transition table, while `IsEditable` identifies open and reopened tickets.
- [KamiSama.Modules.Ticketing.Entities.TicketAttachment](kamisama-modules-ticketing-entities/kamisama-modules-ticketing-entities-ticketattachment/index.md) - EF Core reference from a ticket comment to an external content identifier. It stores no content bytes or metadata and is cascade-deleted with its comment.
- [KamiSama.Modules.Ticketing.Entities.TicketCategory](kamisama-modules-ticketing-entities/kamisama-modules-ticketing-entities-ticketcategory/index.md) - EF Core ticket category with a required 50-character name and timestamps. Duplicate checks occur in feature code, while provider migrations create no unique name index.
- [KamiSama.Modules.Ticketing.Entities.TicketComment](kamisama-modules-ticketing-entities/kamisama-modules-ticketing-entities-ticketcomment/index.md) - EF Core comment belonging to one ticket, with caller-attributed side and author, 400-character text, timestamps, and attachment references. Provider migrations cascade its deletion to attachments.
- [KamiSama.Modules.Ticketing.Repositories.Database.TicketingDbContext](kamisama-modules-ticketing-repositories-database/kamisama-modules-ticketing-repositories-database-ticketingdbcontext/index.md) - Provider-neutral EF Core context consumed by Ticketing repositories and startup initialization. It exposes tracked aggregate sets; a concrete provider must be registered under the configured keyed context for normal module use.
