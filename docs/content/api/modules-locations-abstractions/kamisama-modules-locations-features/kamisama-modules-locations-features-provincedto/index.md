# ProvinceDto

<a id="provincedto"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Locations.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Locations.Abstractions/Features/Dtos.cs:45](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Abstractions/Features/Dtos.cs#L45)

Namespace: `KamiSama.Modules.Locations.Features`

Kind: `Record`

## Description

Returns a province identifier and name across the provider-neutral feature boundary. It contains no child-city collection.

## Declaration

```csharp
public record ProvinceDto(Guid Id, string Name);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Abstractions/Features/Dtos.cs#L45)

Represents a province returned across the provider-neutral Locations feature boundary. Use it with the surrounding package APIs when composing application code.

```csharp
public record ProvinceDto(Guid Id, string Name);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `Id` | `Guid` | `-` | The province identifier. |
| `Name` | `string` | `-` | The province name. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

