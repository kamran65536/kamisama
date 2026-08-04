# All

[Back to CitySearchModel](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Locations.Abstractions](../../index.md)

Source: [src/KamiSama.Modules.Locations.Abstractions/Features/Dtos.cs:13](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Abstractions/Features/Dtos.cs#L13)

Type: `KamiSama.Modules.Locations.Features.CitySearchModel`

Kind: `Property`

## Description

Exposes the `All` value on `CitySearchModel`. Read or set it as part of configuring or using the type.

## Declaration

```csharp
public static new CitySearchModel All { get; } = new(default, default, default, default, default, default);
```

## Value

| Detail | Description |
| --- | --- |
| `Property` | Gets a `CitySearchModel` value. |

## Example

```csharp
using KamiSama.Extensions.Paging;

var search = SearchModel.All;
```

