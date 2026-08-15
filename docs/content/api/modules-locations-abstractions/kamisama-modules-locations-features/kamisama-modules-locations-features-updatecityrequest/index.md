# UpdateCityRequest

<a id="updatecityrequest"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Locations.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Locations.Abstractions/Features/Dtos.cs:76](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Abstractions/Features/Dtos.cs#L76)

Namespace: `KamiSama.Modules.Locations.Features`

Kind: `Record`

## Description

Carries the parent-province identifier and replacement city name. Core loads the requested parent before assigning both values and throws when that province does not exist.

## Declaration

```csharp
public record UpdateCityRequest(Guid ProvinceId, [property: MaxLength(100)] string Name);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Abstractions/Features/Dtos.cs#L76)

Supplies the parent province and replacement name for an existing city. Use it with the surrounding package APIs when composing application code.

```csharp
public record UpdateCityRequest(Guid ProvinceId, [property: MaxLength(100)] string Name);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `ProvinceId` | `Guid` | `-` | The identifier of an existing province to assign as the parent. |
| `Name` | `string` | `-` | The city name, limited to 100 characters by data annotations and the Core EF model. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

