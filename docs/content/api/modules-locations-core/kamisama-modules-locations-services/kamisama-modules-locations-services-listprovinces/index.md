# ListProvinces

<a id="listprovinces"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Locations.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Locations.Core/Services/ListProvinces.cs:6](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Core/Services/ListProvinces.cs#L6)

Namespace: `KamiSama.Modules.Locations.Services`

Kind: `Class`

## Description

Provides the `ListProvinces` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
internal class ListProvinces(IProvinceRepository repository) :
	GenericListFeature<Province, ProvinceDto, ProvinceSearchModel, IProvinceRepository>(repository),
	IListProvinces
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Core/Services/ListProvinces.cs#L6)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
internal class ListProvinces(IProvinceRepository repository) :
	GenericListFeature<Province, ProvinceDto, ProvinceSearchModel, IProvinceRepository>(repository),
	IListProvinces
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `repository` | `IProvinceRepository` | `-` | The `repository` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [ConvertToDto](method-converttodto-11.md) | Runs the `ConvertToDto` operation on `ListProvinces`. Use it when your code needs this specific behavior from the package. |

