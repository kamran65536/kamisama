# ServicePlansPolicyActionModule

<a id="serviceplanspolicyactionmodule"></a>

[Back to namespace](../index.md) | [Back to KamiSama.ServicePlans.PolicyAction](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.ServicePlans.PolicyAction/ServicePlansPolicyActionModule.cs:12](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ServicePlans.PolicyAction/ServicePlansPolicyActionModule.cs#L12)

Namespace: `KamiSama.ServicePlans.PolicyAction`

Kind: `Class`

## Description

Scans this assembly to register the internal handler as scoped and performs no post-build work. It does not register PolicyEngine, ServicePlans, dispatch, middleware, or endpoints.

## Declaration

```csharp
public class ServicePlansPolicyActionModule : WebModule
```

## Example

```csharp
ExtendedWebApplicationBuilder builder = webBuilder.Extend()
    .AddModule(new ServicePlansPolicyActionModule());
WebApplication app = await builder.BuildAsync(cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [ApplyConfigurationToAsync](method-applyconfigurationtoasync-27.md) | Returns a completed task without adding middleware, endpoints, dispatch, or any other post-build behavior. |
| [ConfigureServices](method-configureservices-18.md) | Scans this assembly and registers its internal handler as scoped `IServicePlansPolicyActionHandler`. It does not register either domain module or a dispatcher. |

