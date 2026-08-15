# ServicePlansPolicyActionResult

<a id="serviceplanspolicyactionresult"></a>

[Back to namespace](../index.md) | [Back to KamiSama.ServicePlans.PolicyAction](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.ServicePlans.PolicyAction/ServicePlansPolicyAction.cs:35](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ServicePlans.PolicyAction/ServicePlansPolicyAction.cs#L35)

Namespace: `KamiSama.ServicePlans.PolicyAction`

Kind: `Class`

## Description

Carries a decimal computation-unit amount. The registered handler cannot currently produce this result because execution always throws.

## Declaration

```csharp
public sealed class ServicePlansPolicyActionResult
```

## Example

```csharp
var result = new ServicePlansPolicyActionResult
{
    ComputationUnits = 12.5m
};
// A replacement handler can return this shape; the included handler cannot.
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Properties

| Member | Description |
| --- | --- |
| [ComputationUnits](property-computationunits-41.md) | Gets or sets a decimal computation-unit amount without domain validation. The included handler never produces it because execution throws. |

