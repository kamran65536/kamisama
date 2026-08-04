# AddCity

<a id="addcity"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Locations.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Locations.Core/Features/AddCity.cs:5](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Core/Features/AddCity.cs#L5)

Namespace: `KamiSama.Modules.Locations.Features`

Kind: `Class`

## Description

Provides the `AddCity` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
internal class AddCity(ICityRepository cityRepository, IProvinceRepository provinceRepository) :
	GenericAddFeature<AddCityRequest, ICityRepository, City, CityDto>(cityRepository),
	IAddCity
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Core/Features/AddCity.cs#L5)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
internal class AddCity(ICityRepository cityRepository, IProvinceRepository provinceRepository) :
	GenericAddFeature<AddCityRequest, ICityRepository, City, CityDto>(cityRepository),
	IAddCity
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `cityRepository` | `ICityRepository` | `-` | The `cityRepository` value passed to this member. |
| `provinceRepository` | `IProvinceRepository` | `-` | The `provinceRepository` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [ConvertToDto](method-converttodto-22.md) | Runs the `ConvertToDto` operation on `AddCity`. Use it when your code needs this specific behavior from the package. |
| [ConvertToEntity](method-converttoentity-10.md) | Runs the `ConvertToEntity` operation on `AddCity`. Use it when your code needs this specific behavior from the package. |

