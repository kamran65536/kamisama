# SubscriberSearchModel

<a id="subscribersearchmodel"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.ServicePlans.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.ServicePlans.Abstractions/Features/Subscribers/Dtos.cs:11](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Abstractions/Features/Subscribers/Dtos.cs#L11)

Namespace: `KamiSama.Modules.ServicePlans.Features.Subscribers`

Kind: `Record`

## Description

Carries paging, filtering, and ordering criteria for subscriber listing. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public record SubscriberSearchModel(int Page, int PageSize, Guid? ExternalUserId, bool? IsEnabled, string? OrderBy)
	: SearchModel(Page, PageSize, OrderBy)
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Abstractions/Features/Subscribers/Dtos.cs#L11)

Carries paging, filtering, and ordering criteria for subscriber listing. Use it with the surrounding package APIs when composing application code.

```csharp
public record SubscriberSearchModel(int Page, int PageSize, Guid? ExternalUserId, bool? IsEnabled, string? OrderBy)
	: SearchModel(Page, PageSize, OrderBy)
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `Page` | `int` | `-` | The one-based page number, or the paging convention accepted by the implementation. |
| `PageSize` | `int` | `-` | The maximum number of subscribers to return. |
| `ExternalUserId` | `Guid?` | `-` | The optional externally managed user identifier filter. |
| `IsEnabled` | `bool?` | `-` | The optional enabled-state filter. |
| `OrderBy` | `string?` | `-` | The optional implementation-defined ordering token. |

## Members

### Properties

| Member | Description |
| --- | --- |
| [All](property-all-18.md) | Gets or sets the shared search model requesting all subscribers without filters. Use it with the surrounding package APIs when composing application code. |

