# PolicyRuleDto

<a id="policyruledto"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.PolicyEngine.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.PolicyEngine.Abstractions/Features/PolicyRules/Dtos.cs:51](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Abstractions/Features/PolicyRules/Dtos.cs#L51)

Namespace: `KamiSama.Modules.PolicyEngine.Features.PolicyRules`

Kind: `Record`

## Description

Carries the complete persisted policy-rule definition returned by create and find operations. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public record PolicyRuleDto(
	Guid Id,
	string Name,
	int ProcessOrder,
	string ConditionSource,
	bool IsEnabled,
	DateTime CreatedAt,
	DateTime UpdatedAt);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Abstractions/Features/PolicyRules/Dtos.cs#L51)

Carries the complete persisted policy-rule definition returned by create and find operations. Use it with the surrounding package APIs when composing application code.

```csharp
public record PolicyRuleDto(
	Guid Id,
	string Name,
	int ProcessOrder,
	string ConditionSource,
	bool IsEnabled,
	DateTime CreatedAt,
	DateTime UpdatedAt);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `Id` | `Guid` | `-` | The persisted rule identifier. |
| `Name` | `string` | `-` | The display and duplicate-check name. |
| `ProcessOrder` | `int` | `-` | The application-defined ordering value for future evaluation. |
| `ConditionSource` | `string` | `-` | The opaque condition text; these packages do not parse or evaluate it. |
| `IsEnabled` | `bool` | `-` | Whether the rule definition is enabled. |
| `CreatedAt` | `DateTime` | `-` | The UTC creation timestamp written by Core. |
| `UpdatedAt` | `DateTime` | `-` | The UTC last-update timestamp written by Core. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

