# PolicyActionSearchModel

<a id="policyactionsearchmodel"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.PolicyEngine.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.PolicyEngine.Abstractions/Features/PolicyActions/Dtos.cs:12](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Abstractions/Features/PolicyActions/Dtos.cs#L12)

Namespace: `KamiSama.Modules.PolicyEngine.Features.PolicyActions`

Kind: `Record`

## Description

Describes a page of policy-action definitions and the optional filters applied by Core. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public record PolicyActionSearchModel(
	int Page,
	int PageSize,
	string? Name,
	string? HandlerName,
	bool? IsEnabled,
	string? OrderBy) : SearchModel(Page, PageSize, OrderBy)
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Abstractions/Features/PolicyActions/Dtos.cs#L12)

Describes a page of policy-action definitions and the optional filters applied by Core. Use it with the surrounding package APIs when composing application code.

```csharp
public record PolicyActionSearchModel(
	int Page,
	int PageSize,
	string? Name,
	string? HandlerName,
	bool? IsEnabled,
	string? OrderBy) : SearchModel(Page, PageSize, OrderBy)
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `Page` | `int` | `-` | The one-based page number, or the paging abstraction&apos;s all-items value. |
| `PageSize` | `int` | `-` | The maximum number of definitions to return. |
| `Name` | `string?` | `-` | The optional case-insensitive exact action name. |
| `HandlerName` | `string?` | `-` | The optional case-insensitive exact handler name. |
| `IsEnabled` | `bool?` | `-` | The optional enabled-state filter. |
| `OrderBy` | `string?` | `-` | The optional Core ordering token: `id`, `name`, `handlername`, `createdat`, or `updatedat`. |

## Members

### Properties

| Member | Description |
| --- | --- |
| [All](property-all-23.md) | Gets or sets a shared search model that requests all policy actions without filtering. Use it with the surrounding package APIs when composing application code. |

