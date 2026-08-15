# ApplyConfigurationToAsync

[Back to ServicePlansPolicyActionModule](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.ServicePlans.PolicyAction](../../index.md)

Source: [src/KamiSama.ServicePlans.PolicyAction/ServicePlansPolicyActionModule.cs:27](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ServicePlans.PolicyAction/ServicePlansPolicyActionModule.cs#L27)

Type: `KamiSama.ServicePlans.PolicyAction.ServicePlansPolicyActionModule`

Kind: `Method`

## Description

Returns a completed task without adding middleware, endpoints, dispatch, or any other post-build behavior.

## Declaration

```csharp
public override Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `app` | `WebApplication` | `-` | The built application; this implementation does not use it. |
| `cancellationToken` | `CancellationToken` | `-` | The build token; this implementation does not observe it. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | An already-completed task. |

## Example

No concise standalone example is available yet.

