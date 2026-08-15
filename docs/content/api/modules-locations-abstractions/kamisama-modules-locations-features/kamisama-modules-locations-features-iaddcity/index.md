# IAddCity

<a id="iaddcity"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Locations.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Locations.Abstractions/Features/Features.cs:38](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Abstractions/Features/Features.cs#L38)

Namespace: `KamiSama.Modules.Locations.Features`

Kind: `Interface`

## Description

Defines city creation beneath an existing province. Core loads the parent, saves the new city immediately, and does not check duplicate names.

## Declaration

```csharp
public interface IAddCity : IAddFeature<AddCityRequest, CityDto>;
```

## Example

```csharp
CityDto city = await addCity.AddAsync(new AddCityRequest(provinceId, "Springfield"), cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

