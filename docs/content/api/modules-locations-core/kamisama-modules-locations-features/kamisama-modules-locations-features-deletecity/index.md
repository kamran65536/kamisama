# DeleteCity

<a id="deletecity"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Locations.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Locations.Core/Features/DeleteCity.cs:5](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Core/Features/DeleteCity.cs#L5)

Namespace: `KamiSama.Modules.Locations.Features`

Kind: `Class`

## Description

Provides the `DeleteCity` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
internal class DeleteCity(ICityRepository repository) :
	GenericDeleteFeature<City, ICityRepository, Guid>(repository),
	IDeleteCity
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Core/Features/DeleteCity.cs#L5)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
internal class DeleteCity(ICityRepository repository) :
	GenericDeleteFeature<City, ICityRepository, Guid>(repository),
	IDeleteCity
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `repository` | `ICityRepository` | `-` | The `repository` value passed to this member. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

