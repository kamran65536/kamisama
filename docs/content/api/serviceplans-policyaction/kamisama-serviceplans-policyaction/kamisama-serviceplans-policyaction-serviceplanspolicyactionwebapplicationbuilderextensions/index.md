# ServicePlansPolicyActionWebApplicationBuilderExtensions

<a id="serviceplanspolicyactionwebapplicationbuilderextensions"></a>

[Back to namespace](../index.md) | [Back to KamiSama.ServicePlans.PolicyAction](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.ServicePlans.PolicyAction/ServicePlansPolicyActionModule.cs:35](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ServicePlans.PolicyAction/ServicePlansPolicyActionModule.cs#L35)

Namespace: `KamiSama.ServicePlans.PolicyAction`

Kind: `Class`

## Description

Queues the package module on an `ExtendedWebApplicationBuilder`. The host must add any PolicyEngine, ServicePlans, and action-dispatch capabilities separately.

## Declaration

```csharp
public static class ServicePlansPolicyActionWebApplicationBuilderExtensions
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [AddServicePlansPolicyActionModule](method-addserviceplanspolicyactionmodule-43.md) | Queues the package module for service discovery during `BuildAsync`. PolicyEngine, ServicePlans, and host action dispatch remain separate setup responsibilities. |

