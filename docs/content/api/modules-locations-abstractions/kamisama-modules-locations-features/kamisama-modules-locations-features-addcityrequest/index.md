# AddCityRequest

<a id="addcityrequest"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Locations.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Locations.Abstractions/Features/Dtos.cs:70](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Abstractions/Features/Dtos.cs#L70)

Namespace: `KamiSama.Modules.Locations.Features`

Kind: `Record`

## Description

Carries an existing parent-province identifier and city name for creation. Core throws `NotFoundException<Province>` when the parent does not exist.

## Declaration

```csharp
public record AddCityRequest(Guid ProvinceId, [property: MaxLength(100)] string Name);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Abstractions/Features/Dtos.cs#L70)

Supplies the parent province and name for a new city. Use it with the surrounding package APIs when composing application code.

```csharp
public record AddCityRequest(Guid ProvinceId, [property: MaxLength(100)] string Name);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `ProvinceId` | `Guid` | `-` | The identifier of an existing parent province. |
| `Name` | `string` | `-` | The city name, limited to 100 characters by data annotations and the Core EF model. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

