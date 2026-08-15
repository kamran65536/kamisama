# KamiSama.ServicePlans.PolicyAction

[Back to package index](../index.md)

Version: `10.0.0`

## Description

ASP.NET Core registration and contracts for a ServicePlans-oriented handler over PolicyEngine contexts. The registered handler is currently unimplemented, and the package does not dispatch resolved actions or call ServicePlans features.

## How to use

```shell
dotnet add package KamiSama.ServicePlans.PolicyAction --version 10.0.0
```

**Publication mismatch:** `10.0.0` in the required install command is the current workspace/root documentation version. NuGet returned no published package or version for this exact package ID when reviewed.

Add the package module to an `ExtendedWebApplicationBuilder`, finish the two-phase module lifecycle with `BuildAsync`, and resolve the package-specific handler from a scope:

```csharp
using KamiSama.Modules;
using KamiSama.ServicePlans.PolicyAction;
using Microsoft.Extensions.DependencyInjection;

ExtendedWebApplicationBuilder builder = webBuilder.Extend()
    .AddServicePlansPolicyActionModule();
WebApplication app = await builder.BuildAsync(cancellationToken);

using IServiceScope scope = app.Services.CreateScope();
IServicePlansPolicyActionHandler handler = scope.ServiceProvider
    .GetRequiredService<IServicePlansPolicyActionHandler>();
string handlerName = handler.HandlerName; // service-plans
// Do not call ExecuteAsync in 10.0.0: the registered implementation always throws.
```

`ConfigureServices` scans this assembly and registers its internal implementation as scoped. `ApplyConfigurationToAsync` returns a completed task and adds no middleware, endpoints, or dispatcher. The module does not add PolicyEngine Core or ServicePlans Core; register those independently if the host needs their CRUD or persistence features. Although the project carries both abstractions as package dependencies, current source uses only PolicyEngine's `PolicyContext` and calls no ServicePlans contract.

This is not an end-to-end PolicyEngine integration. PolicyEngine Abstractions stores `ResolvedPolicyAction.HandlerName` and configuration as opaque values and defines no action-handler or dispatcher contract. A host would have to match `ServicePlansPolicyActionHandlerNames.ServicePlans`, select this package-specific interface, and invoke it manually. The current `ExecuteAsync` throws `NotImplementedException` synchronously before reading the context, configuration, or cancellation token. `CostExpression` has no defined serialization format, grammar, validation, fact-key convention, or evaluator, and no computation units are applied to ServicePlans plans, subscribers, or subscriptions. Supply a separate working implementation and dispatcher before relying on this boundary.

## Namespaces

- [KamiSama.ServicePlans.PolicyAction](kamisama-serviceplans-policyaction/index.md) (6 types)

## Types

- [KamiSama.ServicePlans.PolicyAction.IServicePlansPolicyActionHandler](kamisama-serviceplans-policyaction/kamisama-serviceplans-policyaction-iserviceplanspolicyactionhandler/index.md) - Defines this package's handler identity and execution boundary over a PolicyEngine `PolicyContext`. It is not a PolicyEngine contract, and the included scoped implementation always throws from execution.
- [KamiSama.ServicePlans.PolicyAction.ServicePlansPolicyActionConfiguration](kamisama-serviceplans-policyaction/kamisama-serviceplans-policyaction-serviceplanspolicyactionconfiguration/index.md) - Carries an intended computation-unit cost expression. The current package defines no serialization format, expression grammar, validation, or evaluator.
- [KamiSama.ServicePlans.PolicyAction.ServicePlansPolicyActionHandlerNames](kamisama-serviceplans-policyaction/kamisama-serviceplans-policyaction-serviceplanspolicyactionhandlernames/index.md) - Defines the exact `service-plans` routing name exposed by this package. PolicyEngine treats the value as opaque and does not dispatch it.
- [KamiSama.ServicePlans.PolicyAction.ServicePlansPolicyActionModule](kamisama-serviceplans-policyaction/kamisama-serviceplans-policyaction-serviceplanspolicyactionmodule/index.md) - Scans this assembly to register the internal handler as scoped and performs no post-build work. It does not register PolicyEngine, ServicePlans, dispatch, middleware, or endpoints.
- [KamiSama.ServicePlans.PolicyAction.ServicePlansPolicyActionResult](kamisama-serviceplans-policyaction/kamisama-serviceplans-policyaction-serviceplanspolicyactionresult/index.md) - Carries a decimal computation-unit amount. The registered handler cannot currently produce this result because execution always throws.
- [KamiSama.ServicePlans.PolicyAction.ServicePlansPolicyActionWebApplicationBuilderExtensions](kamisama-serviceplans-policyaction/kamisama-serviceplans-policyaction-serviceplanspolicyactionwebapplicationbuilderextensions/index.md) - Queues the package module on an `ExtendedWebApplicationBuilder`. The host must add any PolicyEngine, ServicePlans, and action-dispatch capabilities separately.
