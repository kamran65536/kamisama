# Province

<a id="province"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Locations.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Locations.Core/Entities/Province.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Core/Entities/Province.cs#L9)

Namespace: `KamiSama.Modules.Locations.Entities`

Kind: `Class`

## Description

EF Core province entity with a required 100-character name and a virtual city collection. The model restricts deletion while related cities remain.

## Declaration

```csharp
public class Province
```

## Remarks

The Core model configures city deletion as restricted; a province with related cities cannot be deleted by database cascade.

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Properties

| Member | Description |
| --- | --- |
| [Cities](property-cities-22.md) | Gets or sets the cities related to this province. Use it with the surrounding package APIs when composing application code. |
| [Id](property-id-13.md) | Gets or sets the province identifier. Use it with the surrounding package APIs when composing application code. |
| [Name](property-name-17.md) | Gets or sets the required province name. Use it with the surrounding package APIs when composing application code. |

