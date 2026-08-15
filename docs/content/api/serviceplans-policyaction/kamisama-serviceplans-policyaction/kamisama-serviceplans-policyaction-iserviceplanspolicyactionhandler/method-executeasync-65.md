# ExecuteAsync

[Back to IServicePlansPolicyActionHandler](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.ServicePlans.PolicyAction](../../index.md)

Source: [src/KamiSama.ServicePlans.PolicyAction/ServicePlansPolicyAction.cs:65](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ServicePlans.PolicyAction/ServicePlansPolicyAction.cs#L65)

Type: `KamiSama.ServicePlans.PolicyAction.IServicePlansPolicyActionHandler`

Kind: `Method`

## Description

Would apply serialized configuration to policy facts and return computation units. The included implementation instead throws `NotImplementedException` synchronously without observing any argument.

## Declaration

```csharp
Task<ServicePlansPolicyActionResult> ExecuteAsync(PolicyContext context, string configurationSource, CancellationToken cancellationToken = default);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `context` | `PolicyContext` | `-` | The PolicyEngine context whose ordinally keyed `Facts` would supply expression inputs. |
| `configurationSource` | `string` | `-` | The caller-serialized configuration text; no format is currently implemented or validated. |
| `cancellationToken` | `CancellationToken` | `default` | The token intended to cancel execution; the included implementation does not observe it. |

## Returns

| Type | Description |
| --- | --- |
| `Task<ServicePlansPolicyActionResult>` | A task whose result would contain the computed units if a working implementation were supplied. |

## Example

```csharp
// The included handler always throws; provide a replacement before execution.
ServicePlansPolicyActionResult result = await handler.ExecuteAsync(context, configurationSource, cancellationToken);
```

