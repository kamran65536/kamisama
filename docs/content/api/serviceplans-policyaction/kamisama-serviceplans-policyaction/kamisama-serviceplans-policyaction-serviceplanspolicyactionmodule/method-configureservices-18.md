# ConfigureServices

[Back to ServicePlansPolicyActionModule](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.ServicePlans.PolicyAction](../../index.md)

Source: [src/KamiSama.ServicePlans.PolicyAction/ServicePlansPolicyActionModule.cs:18](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ServicePlans.PolicyAction/ServicePlansPolicyActionModule.cs#L18)

Type: `KamiSama.ServicePlans.PolicyAction.ServicePlansPolicyActionModule`

Kind: `Method`

## Description

Scans this assembly and registers its internal handler as scoped `IServicePlansPolicyActionHandler`. It does not register either domain module or a dispatcher.

## Declaration

```csharp
public override void ConfigureServices(IServiceCollection services);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `services` | `IServiceCollection` | `-` | The application service collection configured before build. |

## Example

No concise standalone example is available yet.

