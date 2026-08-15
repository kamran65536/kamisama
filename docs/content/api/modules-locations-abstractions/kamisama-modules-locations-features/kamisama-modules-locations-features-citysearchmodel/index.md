# CitySearchModel

<a id="citysearchmodel"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Locations.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Locations.Abstractions/Features/Dtos.cs:31](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Abstractions/Features/Dtos.cs#L31)

Namespace: `KamiSama.Modules.Locations.Features`

Kind: `Record`

## Description

Carries city paging, city and parent-province filters, and ordering. Core supports exact province-id filtering, lowercased city/province-name substrings, and the exact `province` ordering token.

## Declaration

```csharp
public record CitySearchModel(int Page, int PageSize, Guid? ProvinceId, string? ProvinceName, string? Name, string? OrderBy) : SearchModel(Page, PageSize, OrderBy)
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Abstractions/Features/Dtos.cs#L31)

Specifies paging, province filters, city-name filtering, and ordering input for city queries. Use it with the surrounding package APIs when composing application code.

```csharp
public record CitySearchModel(int Page, int PageSize, Guid? ProvinceId, string? ProvinceName, string? Name, string? OrderBy) : SearchModel(Page, PageSize, OrderBy)
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `Page` | `int` | `-` | The one-based page number; use the paging defaults when set to . |
| `PageSize` | `int` | `-` | The requested page size; use the paging defaults when set to . |
| `ProvinceId` | `Guid?` | `-` | An optional province identifier matched exactly through the city relationship. |
| `ProvinceName` | `string?` | `-` | An optional case-normalized substring matched against the related province name. |
| `Name` | `string?` | `-` | An optional case-normalized substring matched against city names. |
| `OrderBy` | `string?` | `-` | Use `province` for province-name then city-name ordering; every other value orders by city name. |

## Members

### Properties

| Member | Description |
| --- | --- |
| [All](property-all-37.md) | Gets an unpaged search model without province or city filters. Use it with the surrounding package APIs when composing application code. |

