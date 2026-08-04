# All

[Back to ProvinceSearchModel](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Locations.Abstractions](../../index.md)

Source: [src/KamiSama.Modules.Locations.Abstractions/Features/Dtos.cs:8](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Abstractions/Features/Dtos.cs#L8)

Type: `KamiSama.Modules.Locations.Features.ProvinceSearchModel`

Kind: `Property`

## Description

Exposes the `All` value on `ProvinceSearchModel`. Read or set it as part of configuring or using the type.

## Declaration

```csharp
public static new ProvinceSearchModel All { get; } = new(default, default, default, default);
```

## Value

| Detail | Description |
| --- | --- |
| `Property` | Gets a `ProvinceSearchModel` value. |

## Example

```csharp
using KamiSama.Extensions.Paging;

var search = SearchModel.All;
```

