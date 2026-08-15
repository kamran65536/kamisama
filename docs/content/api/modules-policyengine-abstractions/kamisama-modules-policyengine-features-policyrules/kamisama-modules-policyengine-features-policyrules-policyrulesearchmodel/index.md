# PolicyRuleSearchModel

<a id="policyrulesearchmodel"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.PolicyEngine.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.PolicyEngine.Abstractions/Features/PolicyRules/Dtos.cs:11](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Abstractions/Features/PolicyRules/Dtos.cs#L11)

Namespace: `KamiSama.Modules.PolicyEngine.Features.PolicyRules`

Kind: `Record`

## Description

Describes a page of policy-rule definitions and the optional filters applied by Core. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public record PolicyRuleSearchModel(
	int Page,
	int PageSize,
	string? Name,
	bool? IsEnabled,
	string? OrderBy) : SearchModel(Page, PageSize, OrderBy)
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Abstractions/Features/PolicyRules/Dtos.cs#L11)

Describes a page of policy-rule definitions and the optional filters applied by Core. Use it with the surrounding package APIs when composing application code.

```csharp
public record PolicyRuleSearchModel(
	int Page,
	int PageSize,
	string? Name,
	bool? IsEnabled,
	string? OrderBy) : SearchModel(Page, PageSize, OrderBy)
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `Page` | `int` | `-` | The one-based page number, or the paging abstraction&apos;s all-items value. |
| `PageSize` | `int` | `-` | The maximum number of definitions to return. |
| `Name` | `string?` | `-` | The optional case-insensitive exact rule name. |
| `IsEnabled` | `bool?` | `-` | The optional enabled-state filter. |
| `OrderBy` | `string?` | `-` | The optional Core ordering token: `id`, `name`, `processorder`, `createdat`, or `updatedat`. |

## Members

### Properties

| Member | Description |
| --- | --- |
| [All](property-all-21.md) | Gets or sets a shared search model that requests all policy rules without filtering. Use it with the surrounding package APIs when composing application code. |

