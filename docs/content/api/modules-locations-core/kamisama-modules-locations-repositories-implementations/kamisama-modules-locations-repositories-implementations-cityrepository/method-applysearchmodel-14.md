# ApplySearchModel

[Back to CityRepository](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Locations.Core](../../index.md)

Source: [src/KamiSama.Modules.Locations.Core/Repositories/Implementations/CityRepository.cs:14](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Core/Repositories/Implementations/CityRepository.cs#L14)

Type: `KamiSama.Modules.Locations.Repositories.Implementations.CityRepository`

Kind: `Method`

## Description

Runs the `ApplySearchModel` operation on `CityRepository`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
protected override IQueryable<City> ApplySearchModel(IQueryable<City> query, CitySearchModel searchModel);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `query` | `IQueryable<City>` | `-` | The `query` value passed to this member. |
| `searchModel` | `CitySearchModel` | `-` | The `searchModel` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `IQueryable<City>` | Returns a `IQueryable<City>` value. |

## Example

No concise standalone example is available yet.

