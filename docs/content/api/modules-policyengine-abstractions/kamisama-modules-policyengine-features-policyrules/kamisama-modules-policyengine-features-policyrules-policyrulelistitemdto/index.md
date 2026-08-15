# PolicyRuleListItemDto

<a id="policyrulelistitemdto"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.PolicyEngine.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.PolicyEngine.Abstractions/Features/PolicyRules/Dtos.cs:33](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Abstractions/Features/PolicyRules/Dtos.cs#L33)

Namespace: `KamiSama.Modules.PolicyEngine.Features.PolicyRules`

Kind: `Record`

## Description

Carries the policy-rule fields returned by list operations, excluding condition source. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public record PolicyRuleListItemDto(
	Guid Id,
	string Name,
	int ProcessOrder,
	bool IsEnabled,
	DateTime CreatedAt,
	DateTime UpdatedAt);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Abstractions/Features/PolicyRules/Dtos.cs#L33)

Carries the policy-rule fields returned by list operations, excluding condition source. Use it with the surrounding package APIs when composing application code.

```csharp
public record PolicyRuleListItemDto(
	Guid Id,
	string Name,
	int ProcessOrder,
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
| `IsEnabled` | `bool` | `-` | Whether the rule definition is enabled. |
| `CreatedAt` | `DateTime` | `-` | The UTC creation timestamp written by Core. |
| `UpdatedAt` | `DateTime` | `-` | The UTC last-update timestamp written by Core. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

