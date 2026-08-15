# City

<a id="city"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Locations.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Locations.Core/Entities/City.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Core/Entities/City.cs#L9)

Namespace: `KamiSama.Modules.Locations.Entities`

Kind: `Class`

## Description

EF Core city entity with a required name and required virtual parent-province navigation. It exposes no separate public province-id property.

## Declaration

```csharp
public class City
```

## Remarks

The model uses the required `Province` navigation as its parent relationship and does not expose a separate public province-id property.

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Properties

| Member | Description |
| --- | --- |
| [Id](property-id-13.md) | Gets or sets the city identifier. Use it with the surrounding package APIs when composing application code. |
| [Name](property-name-21.md) | Gets or sets the required city name. Use it with the surrounding package APIs when composing application code. |
| [Province](property-province-17.md) | Gets or sets the required parent province. Use it with the surrounding package APIs when composing application code. |

