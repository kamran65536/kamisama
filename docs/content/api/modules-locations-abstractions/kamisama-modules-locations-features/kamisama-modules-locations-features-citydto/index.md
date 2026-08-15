# CityDto

<a id="citydto"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Locations.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Locations.Abstractions/Features/Dtos.cs:53](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Abstractions/Features/Dtos.cs#L53)

Namespace: `KamiSama.Modules.Locations.Features`

Kind: `Record`

## Description

Returns a city together with the identifier and name of its parent province. Parent values are copied from the loaded province navigation when Core creates the DTO.

## Declaration

```csharp
public record CityDto(Guid Id, Guid ProvinceId, string ProvinceName, string Name);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Abstractions/Features/Dtos.cs#L53)

Represents a city and its parent province across the provider-neutral Locations feature boundary. Use it with the surrounding package APIs when composing application code.

```csharp
public record CityDto(Guid Id, Guid ProvinceId, string ProvinceName, string Name);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `Id` | `Guid` | `-` | The city identifier. |
| `ProvinceId` | `Guid` | `-` | The parent province identifier. |
| `ProvinceName` | `string` | `-` | The parent province name captured when the DTO is created. |
| `Name` | `string` | `-` | The city name. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

