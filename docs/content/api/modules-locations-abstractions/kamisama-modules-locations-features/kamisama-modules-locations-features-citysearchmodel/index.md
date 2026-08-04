# CitySearchModel

<a id="citysearchmodel"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Locations.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Locations.Abstractions/Features/Dtos.cs:11](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Abstractions/Features/Dtos.cs#L11)

Namespace: `KamiSama.Modules.Locations.Features`

Kind: `Record`

## Description

Provides the `CitySearchModel` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
public record CitySearchModel(int Page, int PageSize, Guid? ProvinceId, string? ProvinceName, string? Name, string? OrderBy) : SearchModel(Page, PageSize, OrderBy)
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Abstractions/Features/Dtos.cs#L11)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
public record CitySearchModel(int Page, int PageSize, Guid? ProvinceId, string? ProvinceName, string? Name, string? OrderBy) : SearchModel(Page, PageSize, OrderBy)
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `Page` | `int` | `-` | The `Page` value passed to this member. |
| `PageSize` | `int` | `-` | The `PageSize` value passed to this member. |
| `ProvinceId` | `Guid?` | `-` | The `ProvinceId` value passed to this member. |
| `ProvinceName` | `string?` | `-` | The `ProvinceName` value passed to this member. |
| `Name` | `string?` | `-` | The `Name` value passed to this member. |
| `OrderBy` | `string?` | `-` | The `OrderBy` value passed to this member. |

## Members

### Properties

| Member | Description |
| --- | --- |
| [All](property-all-13.md) | Exposes the `All` value on `CitySearchModel`. Read or set it as part of configuring or using the type. |

