# FindCityById

<a id="findcitybyid"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Locations.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Locations.Core/Features/FindCityById.cs:5](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Core/Features/FindCityById.cs#L5)

Namespace: `KamiSama.Modules.Locations.Features`

Kind: `Class`

## Description

Provides the `FindCityById` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
internal class FindCityById(ICityRepository repository) :
	GenericFindByIdFeature<City, CityDto, ICityRepository, Guid>(repository),
	IFindCityById
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Core/Features/FindCityById.cs#L5)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
internal class FindCityById(ICityRepository repository) :
	GenericFindByIdFeature<City, CityDto, ICityRepository, Guid>(repository),
	IFindCityById
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `repository` | `ICityRepository` | `-` | The `repository` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [ConvertToDto](method-converttodto-10.md) | Runs the `ConvertToDto` operation on `FindCityById`. Use it when your code needs this specific behavior from the package. |

