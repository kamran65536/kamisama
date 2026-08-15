# ResolvedPolicyAction

<a id="resolvedpolicyaction"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.PolicyEngine.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.PolicyEngine.Abstractions/Contexts/ResolvedPolicyAction.cs:6](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Abstractions/Contexts/ResolvedPolicyAction.cs#L6)

Namespace: `KamiSama.Modules.PolicyEngine.Contexts`

Kind: `Class`

## Description

Carries a selected action identifier, handler name, opaque configuration, and order for later application. No included API resolves or executes this data.

## Declaration

```csharp
public class ResolvedPolicyAction
```

## Example

```csharp
context.Actions.Add(new ResolvedPolicyAction
{
    ActionId = actionId,
    HandlerName = "service-plan",
    ConfigurationSource = "{\"plan\":\"premium\"}",
    Order = 10
});
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Properties

| Member | Description |
| --- | --- |
| [ActionId](property-actionid-11.md) | Gets or sets the identifier of the selected policy action. Use it with the surrounding package APIs when composing application code. |
| [ConfigurationSource](property-configurationsource-21.md) | Gets or sets the configuration source interpreted by the action handler. Use it with the surrounding package APIs when composing application code. |
| [HandlerName](property-handlername-16.md) | Gets or sets the stable name of the handler that applies the action. Use it with the surrounding package APIs when composing application code. |
| [Order](property-order-26.md) | Gets or sets the action order resolved from the matching policy rules. Use it with the surrounding package APIs when composing application code. |

