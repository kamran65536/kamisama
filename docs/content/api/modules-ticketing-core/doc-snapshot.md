---
last-checked-utc: 2026-08-15T01:02:12Z
root-version: 10.0.0
classes-without-examples:
  - KamiSama.Modules.Ticketing.ExtendedWebApplicationBuilderExtensions
---

# Documentation Snapshot

The package description, complete public/protected XML summaries, module and provider lifecycle, entities and context, feature and repository behavior, registration and runtime limitations, publication mismatch, useful class examples, and exact extension exemption were reviewed against current source at the recorded root version.

## Description

ASP.NET Core Ticketing implementation with EF Core entities, validated ticket workflows, repositories, scoped features, modular registration, and startup database initialization.
Install it with at least the selected PostgreSQL or SQLite provider and review the limitations below before exposing its features.

## How to use

**Publication mismatch:** `10.0.0` below is the current workspace/root documentation version and remains required in repository documentation. NuGet exposed `10.0.11` as the latest package when reviewed; `10.0.0` itself was not available.

```shell
dotnet add package KamiSama.Modules.Ticketing.Core --version 10.0.0
```

Call `AddTicketingModule(moduleSection, databaseSection, providerCallback)` on an `ExtendedWebApplicationBuilder`, then call `BuildAsync`. `ConfigureServices` binds named connection and initialization options, scans Core for attributed scoped services, sets `__EFMigrationsHistory_Ticketing`, and invokes the callback. Configure `postgresql` with `AddPostgresqlTicketingDbContext` or `sqlite` with `AddSqliteTicketingDbContext`; the callback is nullable but required in normal setup unless the exact keyed base context is registered elsewhere.

After build, the module resolves a custom `IDatabaseInitializer<TicketingDbContext>` or the default migration-only initializer and executes stages selected by `migrate`, `initialize`, and `test-data`. Default initialize and test-data stages are no-ops. Startup migration needs connectivity, compatible provider migrations, and schema privileges. Core maps no controllers, endpoints, middleware, authentication, or authorization.

## Runtime audit

`DeleteTicketCategory`, `ListTicketCategories`, and `ExistsTicketCategoryByName` are attributed for specialized service contracts they do not implement. Service-provider validation can fail during `BuildAsync`; without validation, resolving those three interfaces fails. This is documented current behavior and was not changed.

Ticket search ignores `TicketCategoryId`; text searches titles and comments, author searches ticket and comment authors, and ordering recognizes `priority`, `status`, and `updatedat`. Category duplicate checks are read-before-write and migrations provide no unique name index. Mutations save immediately without a feature-level multi-operation transaction.

`UpdateTicketComment` ignores its method key and targets `request.CommentId`. Comment/attachment mutations trust claimed author IDs; comment addition also trusts the requested side. Attachment removal and ticket-state update have no ownership check. State updates permit unchanged status, open or reopened to resolved, and resolved to reopened or closed; invalid transitions produce HTTP 409. Other mutation paths do not consistently enforce `Ticket.IsEditable`. Add endpoint authentication, ownership and side authorization, and identifier consistency.

Attachments are external content identifiers only. Provider migrations enforce required cascading category-to-ticket-to-comment-to-attachment relationships and 50/100/400 character limits. Lazy-loading proxies are enabled by provider registration, while repository queries are tracked.

## Example decisions

`Ticket`, `TicketCategory`, `TicketComment`, `TicketAttachment`, and `TicketingDbContext` have exact-full-name useful class examples. The `Ticket` example and `CanTransitionTo` member page demonstrate workflow validation. Static `ExtendedWebApplicationBuilderExtensions` is exempt because the package How-to and exact `AddTicketingModule` member example cover its only public operation. Internal features, repositories, mappings, and `TicketingModule` are intentionally excluded from the public API generator but their current behavior is covered above. Migrations and generated model snapshots remain excluded from API pages.
