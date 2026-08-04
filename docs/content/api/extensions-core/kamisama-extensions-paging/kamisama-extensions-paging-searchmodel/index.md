# SearchModel

<a id="searchmodel"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Core/Paging/SearchModel.cs:11](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Core/Paging/SearchModel.cs#L11)

Namespace: `KamiSama.Extensions.Paging`

Kind: `Record`

## Description

Provides the `SearchModel` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
public record SearchModel(int Page, int PageSize, string? OrderBy = null)
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Core/Paging/SearchModel.cs#L11)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
public record SearchModel(int Page, int PageSize, string? OrderBy = null)
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `Page` | `int` | `-` | page number starts from 1 |
| `PageSize` | `int` | `-` | The `PageSize` value passed to this member. |
| `OrderBy` | `string?` | `null` | The `OrderBy` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [FromPage](method-frompage-25.md) | creates a search model from page. Use it with the surrounding package APIs when composing application code. |

### Properties

| Member | Description |
| --- | --- |
| [All](property-all-17.md) | Represent Search model for All items. Use it with the surrounding package APIs when composing application code. |

