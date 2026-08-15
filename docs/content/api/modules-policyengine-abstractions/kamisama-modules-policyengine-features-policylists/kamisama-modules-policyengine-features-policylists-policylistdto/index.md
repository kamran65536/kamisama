# PolicyListDto

<a id="policylistdto"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.PolicyEngine.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.PolicyEngine.Abstractions/Features/PolicyLists/Dtos.cs:52](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Abstractions/Features/PolicyLists/Dtos.cs#L52)

Namespace: `KamiSama.Modules.PolicyEngine.Features.PolicyLists`

Kind: `Record`

## Description

Carries the complete policy-list definition returned by create and find operations, without its items. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public record PolicyListDto(
	Guid Id,
	string Name,
	PolicyListType Type,
	bool IsEnabled,
	DateTime CreatedAt,
	DateTime UpdatedAt);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Abstractions/Features/PolicyLists/Dtos.cs#L52)

Carries the complete policy-list definition returned by create and find operations, without its items. Use it with the surrounding package APIs when composing application code.

```csharp
public record PolicyListDto(
	Guid Id,
	string Name,
	PolicyListType Type,
	bool IsEnabled,
	DateTime CreatedAt,
	DateTime UpdatedAt);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `Id` | `Guid` | `-` | The persisted list identifier. |
| `Name` | `string` | `-` | The display and duplicate-check name. |
| `Type` | `PolicyListType` | `-` | The declared type of values in the list. |
| `IsEnabled` | `bool` | `-` | Whether the list definition is enabled. |
| `CreatedAt` | `DateTime` | `-` | The UTC creation timestamp written by Core. |
| `UpdatedAt` | `DateTime` | `-` | The UTC last-update timestamp written by Core. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

