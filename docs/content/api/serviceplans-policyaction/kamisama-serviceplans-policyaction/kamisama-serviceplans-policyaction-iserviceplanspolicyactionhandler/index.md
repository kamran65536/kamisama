# IServicePlansPolicyActionHandler

<a id="iserviceplanspolicyactionhandler"></a>

[Back to namespace](../index.md) | [Back to KamiSama.ServicePlans.PolicyAction](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.ServicePlans.PolicyAction/ServicePlansPolicyAction.cs:48](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ServicePlans.PolicyAction/ServicePlansPolicyAction.cs#L48)

Namespace: `KamiSama.ServicePlans.PolicyAction`

Kind: `Interface`

## Description

Defines this package's handler identity and execution boundary over a PolicyEngine `PolicyContext`. It is not a PolicyEngine contract, and the included scoped implementation always throws from execution.

## Declaration

```csharp
public interface IServicePlansPolicyActionHandler
```

## Example

```csharp
IServicePlansPolicyActionHandler handler = scope.ServiceProvider
    .GetRequiredService<IServicePlansPolicyActionHandler>();
string handlerName = handler.HandlerName;
// ExecuteAsync currently throws NotImplementedException synchronously.
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [ExecuteAsync](method-executeasync-65.md) | Would apply serialized configuration to policy facts and return computation units. The included implementation instead throws `NotImplementedException` synchronously without observing any argument. |

### Properties

| Member | Description |
| --- | --- |
| [HandlerName](property-handlername-54.md) | Gets the routing name exposed by an implementation. The package's scoped implementation returns `service-plans`. |

