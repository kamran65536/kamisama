# PlanSearchModel

<a id="plansearchmodel"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.ServicePlans.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.ServicePlans.Abstractions/Features/Plans/Dtos.cs:12](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Abstractions/Features/Plans/Dtos.cs#L12)

Namespace: `KamiSama.Modules.ServicePlans.Features.Plans`

Kind: `Record`

## Description

Carries paging, filtering, and ordering criteria for plan listing. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public record PlanSearchModel(
	int Page,
	int PageSize,
	string? Name,
	SubscriptionPeriodType? PeriodType,
	bool? IsEnabled,
	string? OrderBy) : SearchModel(Page, PageSize, OrderBy)
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Abstractions/Features/Plans/Dtos.cs#L12)

Carries paging, filtering, and ordering criteria for plan listing. Use it with the surrounding package APIs when composing application code.

```csharp
public record PlanSearchModel(
	int Page,
	int PageSize,
	string? Name,
	SubscriptionPeriodType? PeriodType,
	bool? IsEnabled,
	string? OrderBy) : SearchModel(Page, PageSize, OrderBy)
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `Page` | `int` | `-` | The one-based page number, or the paging convention accepted by the implementation. |
| `PageSize` | `int` | `-` | The maximum number of plans to return. |
| `Name` | `string?` | `-` | The optional plan name filter. |
| `PeriodType` | `SubscriptionPeriodType?` | `-` | The optional allowance-period filter. |
| `IsEnabled` | `bool?` | `-` | The optional enabled-state filter. |
| `OrderBy` | `string?` | `-` | The optional implementation-defined ordering token. |

## Members

### Properties

| Member | Description |
| --- | --- |
| [All](property-all-24.md) | Gets or sets the shared search model requesting all plans without filters. Use it with the surrounding package APIs when composing application code. |

