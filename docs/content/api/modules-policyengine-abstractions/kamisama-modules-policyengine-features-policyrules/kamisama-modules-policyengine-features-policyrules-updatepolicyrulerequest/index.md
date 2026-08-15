# UpdatePolicyRuleRequest

<a id="updatepolicyrulerequest"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.PolicyEngine.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.PolicyEngine.Abstractions/Features/PolicyRules/Dtos.cs:76](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Abstractions/Features/PolicyRules/Dtos.cs#L76)

Namespace: `KamiSama.Modules.PolicyEngine.Features.PolicyRules`

Kind: `Record`

## Description

Supplies replacement values for an existing ordered policy-rule definition. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public record UpdatePolicyRuleRequest(string Name, int ProcessOrder, string ConditionSource, bool IsEnabled);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Abstractions/Features/PolicyRules/Dtos.cs#L76)

Supplies replacement values for an existing ordered policy-rule definition. Use it with the surrounding package APIs when composing application code.

```csharp
public record UpdatePolicyRuleRequest(string Name, int ProcessOrder, string ConditionSource, bool IsEnabled);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `Name` | `string` | `-` | The replacement name, which Core checks against other rule names. |
| `ProcessOrder` | `int` | `-` | The replacement application-defined ordering value. |
| `ConditionSource` | `string` | `-` | The replacement opaque condition text. |
| `IsEnabled` | `bool` | `-` | Whether the updated definition is enabled. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

