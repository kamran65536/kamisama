# AddPolicyRuleRequest

<a id="addpolicyrulerequest"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.PolicyEngine.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.PolicyEngine.Abstractions/Features/PolicyRules/Dtos.cs:67](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Abstractions/Features/PolicyRules/Dtos.cs#L67)

Namespace: `KamiSama.Modules.PolicyEngine.Features.PolicyRules`

Kind: `Record`

## Description

Supplies the values stored for a new ordered policy-rule definition. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public record AddPolicyRuleRequest(string Name, int ProcessOrder, string ConditionSource, bool IsEnabled);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Abstractions/Features/PolicyRules/Dtos.cs#L67)

Supplies the values stored for a new ordered policy-rule definition. Use it with the surrounding package APIs when composing application code.

```csharp
public record AddPolicyRuleRequest(string Name, int ProcessOrder, string ConditionSource, bool IsEnabled);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `Name` | `string` | `-` | The rule name, which Core checks for a case-insensitive duplicate. |
| `ProcessOrder` | `int` | `-` | The application-defined ordering value stored for future evaluation. |
| `ConditionSource` | `string` | `-` | The opaque condition text; Core does not validate or evaluate it. |
| `IsEnabled` | `bool` | `-` | Whether the new definition is enabled. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

