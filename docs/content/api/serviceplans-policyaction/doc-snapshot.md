---
last-checked-utc: 2026-08-15T01:14:17Z
root-version: 10.0.0
classes-without-examples:
  - KamiSama.ServicePlans.PolicyAction.ServicePlansPolicyActionWebApplicationBuilderExtensions
---

# Documentation Snapshot

The package description, complete public/protected XML summaries, module and DI lifecycle, actual PolicyEngine and ServicePlans coupling, package dependencies, runtime defect, publication status, exact-full-name examples, and exact exemption were reviewed against current source at the recorded root version.

## Description

ASP.NET Core registration and contracts for a ServicePlans-oriented handler over PolicyEngine contexts.
The registered handler is currently unimplemented, and the package does not dispatch resolved actions or call ServicePlans features.

## How to use

**Publication mismatch:** `10.0.0` below is the current workspace/root documentation version and remains required in repository documentation. NuGet's exact-ID search and flat-container endpoint returned no published package or version when reviewed.

```shell
dotnet add package KamiSama.ServicePlans.PolicyAction --version 10.0.0
```

Call `AddServicePlansPolicyActionModule` on an `ExtendedWebApplicationBuilder` and finish setup with `BuildAsync`. The module scans its assembly and registers the internal `ServicePlansPolicyActionHandler` as scoped `IServicePlansPolicyActionHandler`; its post-build phase is a no-op. Resolve the interface from a scope if handler identity is needed. Do not invoke the included `ExecuteAsync` in version 10.0.0 because it throws `NotImplementedException` synchronously.

The package references `KamiSama.Modules.PolicyEngine.Abstractions`, `KamiSama.Modules.ServicePlans.Abstractions`, `KamiSama.Extensions.DependencyInjection`, and `KamiSama.Modules`. Current source consumes `PolicyContext`, DI scanning, and the web-module lifecycle, but uses no ServicePlans abstraction. The module does not register PolicyEngine Core, ServicePlans Core, persistence providers, controllers, middleware, endpoints, authentication, or authorization; add any required modules and host boundaries independently.

## Runtime audit

This package is not connected to a PolicyEngine execution pipeline. PolicyEngine Abstractions carries an opaque `ResolvedPolicyAction.HandlerName` and configuration source but defines no handler or dispatcher contract. A host must implement dispatch, match the exact `service-plans` value, and manually invoke this package-specific interface.

The included handler's `HandlerName` works, but `ExecuteAsync` immediately throws before reading `PolicyContext`, configuration text, or cancellation. `ServicePlansPolicyActionConfiguration.CostExpression` has no specified serialization format, expression grammar, validation, fact-key convention, parser, or evaluator. No result is produced and no ServicePlans plan, subscriber, subscription, allowance, balance, or usage value is read or changed. These confirmed limitations are documented without runtime fixes.

## Example decisions

`ServicePlansPolicyActionHandlerNames`, `ServicePlansPolicyActionConfiguration`, `ServicePlansPolicyActionResult`, `IServicePlansPolicyActionHandler`, and `ServicePlansPolicyActionModule` have exact-full-name useful examples that identify the intended shape without claiming execution works. Static `ServicePlansPolicyActionWebApplicationBuilderExtensions` is exempt because the detailed How-to and exact `AddServicePlansPolicyActionModule` member documentation cover its only operation. The internal handler is excluded from generated public API pages but audited above.
