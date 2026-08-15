# PolicyRuleAction

<a id="policyruleaction"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.PolicyEngine.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.PolicyEngine.Core/Entities/PolicyRuleAction.cs:6](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Core/Entities/PolicyRuleAction.cs#L6)

Namespace: `KamiSama.Modules.PolicyEngine.Entities`

Kind: `Class`

## Description

Represents the ordered assignment of a reusable policy action to a policy rule. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public class PolicyRuleAction
```

## Example

```csharp
rule.PolicyRuleActions.Add(new PolicyRuleAction
{
    PolicyRule = rule, PolicyAction = action, Order = 10,
    CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
});
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Properties

| Member | Description |
| --- | --- |
| [CreatedAt](property-createdat-31.md) | Gets or sets the UTC creation timestamp. Use it with the surrounding package APIs when composing application code. |
| [Id](property-id-11.md) | Gets or sets the persisted assignment identifier. Use it with the surrounding package APIs when composing application code. |
| [Order](property-order-26.md) | Gets or sets the action&apos;s application order within the rule. Use it with the surrounding package APIs when composing application code. |
| [PolicyAction](property-policyaction-21.md) | Gets or sets the required reusable action referenced by this assignment. Use it with the surrounding package APIs when composing application code. |
| [PolicyRule](property-policyrule-16.md) | Gets or sets the required rule that owns this assignment. Use it with the surrounding package APIs when composing application code. |
| [UpdatedAt](property-updatedat-36.md) | Gets or sets the UTC last-update timestamp. Use it with the surrounding package APIs when composing application code. |

