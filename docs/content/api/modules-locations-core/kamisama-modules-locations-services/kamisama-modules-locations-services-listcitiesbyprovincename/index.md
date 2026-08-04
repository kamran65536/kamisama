# ListCitiesByProvinceName

<a id="listcitiesbyprovincename"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Locations.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Locations.Core/Services/ListCitiesByProvinceName.cs:7](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Core/Services/ListCitiesByProvinceName.cs#L7)

Namespace: `KamiSama.Modules.Locations.Services`

Kind: `Class`

## Description

Provides the `ListCitiesByProvinceName` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
internal class ListCitiesByProvinceName(ICityRepository cityRepository) : IListCitiesByProvinceName
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Core/Services/ListCitiesByProvinceName.cs#L7)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
internal class ListCitiesByProvinceName(ICityRepository cityRepository) : IListCitiesByProvinceName
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `cityRepository` | `ICityRepository` | `-` | The `cityRepository` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [ListAsync](method-listasync-10.md) | Runs the `ListAsync` operation on `ListCitiesByProvinceName`. Use it when your code needs this specific behavior from the package. |

