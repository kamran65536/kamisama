# SearchModel

<a id="searchmodel"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Core/Paging/SearchModel.cs:12](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Core/Paging/SearchModel.cs#L12)

Namespace: `KamiSama.Extensions.Paging`

Kind: `Record`

## Description

Represents paging and optional ordering criteria for a query. A page size of zero requests all matching items.

## Declaration

```csharp
public record SearchModel(int Page, int PageSize, string? OrderBy = null)
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Core/Paging/SearchModel.cs#L12)

Represents paging and optional ordering criteria for a query. A page size of zero requests all matching items.

```csharp
public record SearchModel(int Page, int PageSize, string? OrderBy = null)
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `Page` | `int` | `-` | The one-based page number. |
| `PageSize` | `int` | `-` | The maximum number of items in a page; zero requests all items. |
| `OrderBy` | `string?` | `null` | The optional ordering expression or field name. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [FromPage](method-frompage-26.md) | Creates search criteria for the specified one-based page number and page size. Use it with the surrounding package APIs when composing application code. |

### Properties

| Member | Description |
| --- | --- |
| [All](property-all-18.md) | Gets search criteria that request all matching items without paging. Use it with the surrounding package APIs when composing application code. |

