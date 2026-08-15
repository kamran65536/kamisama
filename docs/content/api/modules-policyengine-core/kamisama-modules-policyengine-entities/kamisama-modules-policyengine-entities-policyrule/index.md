# PolicyRule

<a id="policyrule"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.PolicyEngine.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.PolicyEngine.Core/Entities/PolicyRule.cs:8](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Core/Entities/PolicyRule.cs#L8)

Namespace: `KamiSama.Modules.PolicyEngine.Entities`

Kind: `Class`

## Description

Represents an ordered policy rule with a persisted condition expression. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public class PolicyRule
```

## Example

```csharp
var rule = new PolicyRule
{
    Name = "Trusted network", ProcessOrder = 10, ConditionSource = conditionSource,
    IsEnabled = true, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
};
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Properties

| Member | Description |
| --- | --- |
| [ConditionSource](property-conditionsource-29.md) | Gets or sets opaque condition-language source for a separately implemented evaluator. Use it with the surrounding package APIs when composing application code. |
| [CreatedAt](property-createdat-39.md) | Gets or sets the UTC creation timestamp. Use it with the surrounding package APIs when composing application code. |
| [Id](property-id-13.md) | Gets or sets the persisted rule identifier. Use it with the surrounding package APIs when composing application code. |
| [IsEnabled](property-isenabled-34.md) | Gets or sets whether the rule definition is enabled for separately implemented evaluation. Use it with the surrounding package APIs when composing application code. |
| [Name](property-name-18.md) | Gets or sets the required rule name, limited to 200 characters by the EF model. Use it with the surrounding package APIs when composing application code. |
| [PolicyRuleActions](property-policyruleactions-49.md) | Gets or sets the ordered action assignments belonging to this rule. Use it with the surrounding package APIs when composing application code. |
| [ProcessOrder](property-processorder-24.md) | Gets or sets the application-defined order in which a future evaluator should process the rule. Use it with the surrounding package APIs when composing application code. |
| [UpdatedAt](property-updatedat-44.md) | Gets or sets the UTC last-update timestamp. Use it with the surrounding package APIs when composing application code. |

