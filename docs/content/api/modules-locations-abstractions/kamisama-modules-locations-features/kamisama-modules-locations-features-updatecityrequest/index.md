# UpdateCityRequest

<a id="updatecityrequest"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Locations.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Locations.Abstractions/Features/Dtos.cs:22](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Abstractions/Features/Dtos.cs#L22)

Namespace: `KamiSama.Modules.Locations.Features`

Kind: `Record`

## Description

Provides the `UpdateCityRequest` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
public record UpdateCityRequest(Guid ProvinceId, [property: MaxLength(100)] string Name);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Abstractions/Features/Dtos.cs#L22)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
public record UpdateCityRequest(Guid ProvinceId, [property: MaxLength(100)] string Name);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `ProvinceId` | `Guid` | `-` | The `ProvinceId` value passed to this member. |
| `Name` | `string` | `-` | The `Name` value passed to this member. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

