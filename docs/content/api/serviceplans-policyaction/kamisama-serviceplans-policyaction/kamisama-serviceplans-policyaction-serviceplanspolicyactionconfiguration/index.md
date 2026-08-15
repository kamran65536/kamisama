# ServicePlansPolicyActionConfiguration

<a id="serviceplanspolicyactionconfiguration"></a>

[Back to namespace](../index.md) | [Back to KamiSama.ServicePlans.PolicyAction](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.ServicePlans.PolicyAction/ServicePlansPolicyAction.cs:22](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ServicePlans.PolicyAction/ServicePlansPolicyAction.cs#L22)

Namespace: `KamiSama.ServicePlans.PolicyAction`

Kind: `Class`

## Description

Carries an intended computation-unit cost expression. The current package defines no serialization format, expression grammar, validation, or evaluator.

## Declaration

```csharp
public sealed class ServicePlansPolicyActionConfiguration
```

## Example

```csharp
var configuration = new ServicePlansPolicyActionConfiguration
{
    CostExpression = "request.units * 0.5"
};
// The current package does not serialize, parse, or evaluate this value.
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Properties

| Member | Description |
| --- | --- |
| [CostExpression](property-costexpression-28.md) | Gets or sets opaque intended expression text. The current package defines no format, parser, validation, fact binding, or evaluation semantics. |

