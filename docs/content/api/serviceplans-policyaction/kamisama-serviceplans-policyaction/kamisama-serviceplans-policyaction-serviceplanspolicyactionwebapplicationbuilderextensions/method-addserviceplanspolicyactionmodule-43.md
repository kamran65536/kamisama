# AddServicePlansPolicyActionModule

[Back to ServicePlansPolicyActionWebApplicationBuilderExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.ServicePlans.PolicyAction](../../index.md)

Source: [src/KamiSama.ServicePlans.PolicyAction/ServicePlansPolicyActionModule.cs:43](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ServicePlans.PolicyAction/ServicePlansPolicyActionModule.cs#L43)

Type: `KamiSama.ServicePlans.PolicyAction.ServicePlansPolicyActionWebApplicationBuilderExtensions`

Kind: `Method`

## Description

Queues the package module for service discovery during `BuildAsync`. PolicyEngine, ServicePlans, and host action dispatch remain separate setup responsibilities.

## Declaration

```csharp
public static ExtendedWebApplicationBuilder AddServicePlansPolicyActionModule(this ExtendedWebApplicationBuilder builder);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `builder (extension receiver)` | `ExtendedWebApplicationBuilder` | `-` | The extended builder that receives the module. |

## Returns

| Type | Description |
| --- | --- |
| `ExtendedWebApplicationBuilder` | The same extended builder for fluent module composition. |

## Example

```csharp
ExtendedWebApplicationBuilder builder = webBuilder.Extend()
    .AddServicePlansPolicyActionModule();
WebApplication app = await builder.BuildAsync(cancellationToken);
```

