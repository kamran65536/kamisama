# FromPage

[Back to SearchModel](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Core](../../index.md)

Source: [src/Core/Paging/SearchModel.cs:25](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Core/Paging/SearchModel.cs#L25)

Type: `KamiSama.Extensions.Paging.SearchModel`

Kind: `Method`

## Description

creates a search model from page. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static SearchModel FromPage(int pageNo, int pageSize);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `pageNo` | `int` | `-` | The `pageNo` value passed to this member. |
| `pageSize` | `int` | `-` | The `pageSize` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `SearchModel` | Returns a `SearchModel` value. |

## Example

```csharp
using KamiSama.Extensions.Paging;

var search = SearchModel.FromPage(1, 20);
```

