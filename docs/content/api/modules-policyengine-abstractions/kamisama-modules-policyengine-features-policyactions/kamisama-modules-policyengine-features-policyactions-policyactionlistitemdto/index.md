# PolicyActionListItemDto

<a id="policyactionlistitemdto"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.PolicyEngine.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.PolicyEngine.Abstractions/Features/PolicyActions/Dtos.cs:36](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Abstractions/Features/PolicyActions/Dtos.cs#L36)

Namespace: `KamiSama.Modules.PolicyEngine.Features.PolicyActions`

Kind: `Record`

## Description

Carries the policy-action fields returned by list operations, excluding handler configuration source. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public record PolicyActionListItemDto(
	Guid Id,
	string Name,
	string HandlerName,
	bool AllowsMultiple,
	bool IsEnabled,
	DateTime CreatedAt,
	DateTime UpdatedAt);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Abstractions/Features/PolicyActions/Dtos.cs#L36)

Carries the policy-action fields returned by list operations, excluding handler configuration source. Use it with the surrounding package APIs when composing application code.

```csharp
public record PolicyActionListItemDto(
	Guid Id,
	string Name,
	string HandlerName,
	bool AllowsMultiple,
	bool IsEnabled,
	DateTime CreatedAt,
	DateTime UpdatedAt);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `Id` | `Guid` | `-` | The persisted action identifier. |
| `Name` | `string` | `-` | The display and duplicate-check name. |
| `HandlerName` | `string` | `-` | The application-defined action-handler name. |
| `AllowsMultiple` | `bool` | `-` | Whether an evaluator may retain multiple resolutions of this action. |
| `IsEnabled` | `bool` | `-` | Whether the action definition is enabled. |
| `CreatedAt` | `DateTime` | `-` | The UTC creation timestamp written by Core. |
| `UpdatedAt` | `DateTime` | `-` | The UTC last-update timestamp written by Core. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

