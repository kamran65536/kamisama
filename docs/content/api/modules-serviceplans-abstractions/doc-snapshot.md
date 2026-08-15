---
last-checked-utc: 2026-08-15T01:08:17Z
root-version: 10.0.0
classes-without-examples:
  - KamiSama.Modules.ServicePlans.Features.Plans.AddPlanRequest
  - KamiSama.Modules.ServicePlans.Features.Plans.PlanDto
  - KamiSama.Modules.ServicePlans.Features.Plans.PlanListItemDto
  - KamiSama.Modules.ServicePlans.Features.Plans.PlanSearchModel
  - KamiSama.Modules.ServicePlans.Features.Plans.UpdatePlanRequest
  - KamiSama.Modules.ServicePlans.Features.Subscribers.AddSubscriberRequest
  - KamiSama.Modules.ServicePlans.Features.Subscribers.SubscriberDto
  - KamiSama.Modules.ServicePlans.Features.Subscribers.SubscriberSearchModel
  - KamiSama.Modules.ServicePlans.Features.Subscribers.UpdateSubscriberRequest
  - KamiSama.Modules.ServicePlans.Features.Subscriptions.AddSubscriptionRequest
  - KamiSama.Modules.ServicePlans.Features.Subscriptions.SubscriptionDto
  - KamiSama.Modules.ServicePlans.Features.Subscriptions.SubscriptionSearchModel
  - KamiSama.Modules.ServicePlans.Features.Subscriptions.UpdateSubscriptionRequest
---

# Documentation Snapshot

The package description, complete public contract and data XML summaries, Core-compatible operation examples, filters, security and correctness limitations, publication status, and exact example exemptions were reviewed against current source at the recorded root version.

## Description

Provider-neutral ServicePlans feature contracts, requests, DTOs, search models, and subscription data types.
Reference this package from callers or alternative implementations that should not depend on EF Core, ASP.NET Core module setup, or a database provider.

## How to use

**Publication mismatch:** `10.0.0` below is the current workspace/root documentation version and remains required in repository documentation. NuGet returned no published package or version for this package ID when reviewed.

```shell
dotnet add package KamiSama.Modules.ServicePlans.Abstractions --version 10.0.0
```

Inject plan, subscriber, and subscription feature interfaces after an implementation has registered them. This package alone registers no services, persistence, offer-management contract, validation pipeline, controllers, endpoints, authentication, or authorization. Alternative implementations own query, transaction, validation, and cancellation behavior.

Current Core accepts externally managed user identifiers, subscriber identifiers, plan identifiers, subscription statuses, dates, allowances, and usage counters from requests. These values are data, not authenticated identity or authorization proof. Validate ownership, eligibility, enum values, transitions, date ranges, and non-negative counters at the host boundary.

## Example decisions

Every feature interface has an exact-full-name useful operation example. The exact full names in `classes-without-examples` are simple request, DTO, or search records whose constructor and member documentation completely describes their shape, so separate class examples are not useful.
