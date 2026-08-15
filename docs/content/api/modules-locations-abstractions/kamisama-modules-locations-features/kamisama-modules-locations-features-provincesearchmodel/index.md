# ProvinceSearchModel

<a id="provincesearchmodel"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Locations.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Locations.Abstractions/Features/Dtos.cs:13](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Abstractions/Features/Dtos.cs#L13)

Namespace: `KamiSama.Modules.Locations.Features`

Kind: `Record`

## Description

Carries province paging, optional name filtering, and an ordering token. Core performs a lowercased name substring filter and always orders by province name, ignoring the ordering token.

## Declaration

```csharp
public record ProvinceSearchModel(int Page, int PageSize, string? Name, string? OrderBy) : SearchModel(Page, PageSize, OrderBy)
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Abstractions/Features/Dtos.cs#L13)

Specifies paging, optional name filtering, and ordering input for province queries. Use it with the surrounding package APIs when composing application code.

```csharp
public record ProvinceSearchModel(int Page, int PageSize, string? Name, string? OrderBy) : SearchModel(Page, PageSize, OrderBy)
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `Page` | `int` | `-` | The one-based page number; use the paging defaults when set to . |
| `PageSize` | `int` | `-` | The requested page size; use the paging defaults when set to . |
| `Name` | `string?` | `-` | An optional case-normalized substring matched against province names by the Core repository. |
| `OrderBy` | `string?` | `-` | An optional ordering token. The current Core repository ignores its value and always orders by province name. |

## Members

### Properties

| Member | Description |
| --- | --- |
| [All](property-all-19.md) | Gets an unpaged search model without name filtering or an ordering token. Use it with the surrounding package APIs when composing application code. |

