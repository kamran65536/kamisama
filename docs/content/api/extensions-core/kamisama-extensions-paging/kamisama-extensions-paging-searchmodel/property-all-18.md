# All

[Back to SearchModel](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Core](../../index.md)

Source: [src/Core/Paging/SearchModel.cs:18](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Core/Paging/SearchModel.cs#L18)

Type: `KamiSama.Extensions.Paging.SearchModel`

Kind: `Property`

## Description

Gets search criteria that request all matching items without paging. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static SearchModel All { get; } = new SearchModel(0, 0);
```

## Value

| Detail | Description |
| --- | --- |
| `Property` | Gets a `SearchModel` value. |

## Example

```csharp
using KamiSama.Extensions.Paging;

var search = SearchModel.All;
```

