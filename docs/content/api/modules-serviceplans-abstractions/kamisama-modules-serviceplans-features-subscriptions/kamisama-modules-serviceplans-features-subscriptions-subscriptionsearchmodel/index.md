# SubscriptionSearchModel

<a id="subscriptionsearchmodel"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.ServicePlans.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.ServicePlans.Abstractions/Features/Subscriptions/Dtos.cs:12](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Abstractions/Features/Subscriptions/Dtos.cs#L12)

Namespace: `KamiSama.Modules.ServicePlans.Features.Subscriptions`

Kind: `Record`

## Description

Carries paging, filtering, and ordering criteria for subscription listing. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public record SubscriptionSearchModel(
	int Page,
	int PageSize,
	Guid? SubscriberId,
	Guid? PlanId,
	SubscriptionStatus[]? Statuses,
	string? OrderBy) : SearchModel(Page, PageSize, OrderBy)
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Abstractions/Features/Subscriptions/Dtos.cs#L12)

Carries paging, filtering, and ordering criteria for subscription listing. Use it with the surrounding package APIs when composing application code.

```csharp
public record SubscriptionSearchModel(
	int Page,
	int PageSize,
	Guid? SubscriberId,
	Guid? PlanId,
	SubscriptionStatus[]? Statuses,
	string? OrderBy) : SearchModel(Page, PageSize, OrderBy)
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `Page` | `int` | `-` | The one-based page number, or the paging convention accepted by the implementation. |
| `PageSize` | `int` | `-` | The maximum number of subscriptions to return. |
| `SubscriberId` | `Guid?` | `-` | The optional owning subscriber identifier filter. |
| `PlanId` | `Guid?` | `-` | The optional acquired plan identifier filter. |
| `Statuses` | `SubscriptionStatus[]?` | `-` | The optional set of accepted subscription statuses. |
| `OrderBy` | `string?` | `-` | The optional implementation-defined ordering token. |

## Members

### Properties

| Member | Description |
| --- | --- |
| [All](property-all-24.md) | Gets or sets the shared search model requesting all subscriptions without filters. Use it with the surrounding package APIs when composing application code. |

