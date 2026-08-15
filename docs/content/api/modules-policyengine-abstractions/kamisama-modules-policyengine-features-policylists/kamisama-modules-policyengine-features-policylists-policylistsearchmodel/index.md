# PolicyListSearchModel

<a id="policylistsearchmodel"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.PolicyEngine.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.PolicyEngine.Abstractions/Features/PolicyLists/Dtos.cs:12](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Abstractions/Features/PolicyLists/Dtos.cs#L12)

Namespace: `KamiSama.Modules.PolicyEngine.Features.PolicyLists`

Kind: `Record`

## Description

Describes a page of policy-list definitions and the optional filters applied by Core. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public record PolicyListSearchModel(
	int Page,
	int PageSize,
	string? Name,
	PolicyListType? Type,
	bool? IsEnabled,
	string? OrderBy) : SearchModel(Page, PageSize, OrderBy)
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Abstractions/Features/PolicyLists/Dtos.cs#L12)

Describes a page of policy-list definitions and the optional filters applied by Core. Use it with the surrounding package APIs when composing application code.

```csharp
public record PolicyListSearchModel(
	int Page,
	int PageSize,
	string? Name,
	PolicyListType? Type,
	bool? IsEnabled,
	string? OrderBy) : SearchModel(Page, PageSize, OrderBy)
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `Page` | `int` | `-` | The one-based page number, or the paging abstraction&apos;s all-items value. |
| `PageSize` | `int` | `-` | The maximum number of definitions to return. |
| `Name` | `string?` | `-` | The optional case-insensitive exact list name. |
| `Type` | `PolicyListType?` | `-` | The optional policy-list value type. |
| `IsEnabled` | `bool?` | `-` | The optional enabled-state filter. |
| `OrderBy` | `string?` | `-` | The optional Core ordering token: `id`, `name`, `type`, `createdat`, or `updatedat`. |

## Members

### Properties

| Member | Description |
| --- | --- |
| [All](property-all-23.md) | Gets or sets a shared search model that requests all policy lists without filtering. Use it with the surrounding package APIs when composing application code. |

