# ServicePlansPolicyActionHandlerNames

<a id="serviceplanspolicyactionhandlernames"></a>

[Back to namespace](../index.md) | [Back to KamiSama.ServicePlans.PolicyAction](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.ServicePlans.PolicyAction/ServicePlansPolicyAction.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ServicePlans.PolicyAction/ServicePlansPolicyAction.cs#L9)

Namespace: `KamiSama.ServicePlans.PolicyAction`

Kind: `Class`

## Description

Defines the exact `service-plans` routing name exposed by this package. PolicyEngine treats the value as opaque and does not dispatch it.

## Declaration

```csharp
public static class ServicePlansPolicyActionHandlerNames
```

## Example

```csharp
if (action.HandlerName == ServicePlansPolicyActionHandlerNames.ServicePlans)
{
    // A host-supplied dispatcher decides how to route the opaque action.
}
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Fields

| Member | Description |
| --- | --- |
| [ServicePlans](field-serviceplans-15.md) | Returns the exact `service-plans` routing value. A host-supplied dispatcher must compare this opaque name explicitly. |

