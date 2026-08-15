---
last-checked-utc: 2026-08-15T01:02:12Z
root-version: 10.0.0
classes-without-examples:
  - KamiSama.Modules.Ticketing.Features.TicketCategories.AddTicketCategoryRequest
  - KamiSama.Modules.Ticketing.Features.TicketCategories.TicketCategoryDto
  - KamiSama.Modules.Ticketing.Features.TicketCategories.TicketCategoryListItemDto
  - KamiSama.Modules.Ticketing.Features.TicketCategories.TicketCategorySearchModel
  - KamiSama.Modules.Ticketing.Features.TicketCategories.UpdateTicketCategoryRequest
  - KamiSama.Modules.Ticketing.Features.Tickets.AddAttachmentToTicketCommentRequest
  - KamiSama.Modules.Ticketing.Features.Tickets.AddTicketCommentRequest
  - KamiSama.Modules.Ticketing.Features.Tickets.AddTicketRequest
  - KamiSama.Modules.Ticketing.Features.Tickets.TicketAttachmentDto
  - KamiSama.Modules.Ticketing.Features.Tickets.TicketCommentDto
  - KamiSama.Modules.Ticketing.Features.Tickets.TicketDto
  - KamiSama.Modules.Ticketing.Features.Tickets.TicketListItemDto
  - KamiSama.Modules.Ticketing.Features.Tickets.TicketSearchModel
  - KamiSama.Modules.Ticketing.Features.Tickets.UpdateTicketCommentRequest
  - KamiSama.Modules.Ticketing.Features.Tickets.UpdateTicketStateRequest
---

# Documentation Snapshot

The package description, complete public contract and data summaries, Core-compatible feature examples, identifier and query caveats, publication mismatch, and exact example exemptions were reviewed against current source at the recorded root version.

## Description

Provider-neutral Ticketing feature contracts, requests, DTOs, search models, statuses, priorities, and comment sides.
Reference this package from callers or alternative implementations that should not depend on EF Core, ASP.NET Core module setup, or a database provider.

## How to use

**Publication mismatch:** `10.0.0` below is the current workspace/root documentation version and remains required in repository documentation. NuGet exposed `10.0.11` as the latest package when reviewed; `10.0.0` itself was not available.

```shell
dotnet add package KamiSama.Modules.Ticketing.Abstractions --version 10.0.0
```

Inject feature interfaces into application services or controllers after a concrete implementation has registered them. This package alone registers no services, controllers, endpoints, persistence, content storage, validation pipeline, authentication, or authorization. Alternative implementations own query, authorization, transaction, and cancellation semantics.

Current Core permits unchanged ticket status, open or reopened to resolved, and resolved to reopened or closed; invalid transitions produce HTTP 409. Core ignores `TicketSearchModel.TicketCategoryId`. `IUpdateTicketComment` exposes a method key while `UpdateTicketCommentRequest` contains another comment identifier; current Core ignores the method key and uses the request identifier. Request author identifiers and comment sides are input data, not authenticated identity or authorization proof.

## Example decisions

Every feature interface has an exact-full-name class example showing its operation shape, including a legal open-to-resolved ticket transition and warnings on the three contracts that current Core cannot resolve. The exact full names listed in `classes-without-examples` are simple request, DTO, or search records whose constructor and member documentation describes their complete shape, so separate class examples are not useful.
