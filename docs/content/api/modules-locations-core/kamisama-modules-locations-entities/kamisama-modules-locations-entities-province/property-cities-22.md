# Cities

[Back to Province](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Locations.Core](../../index.md)

Source: [src/KamiSama.Modules.Locations.Core/Entities/Province.cs:22](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Core/Entities/Province.cs#L22)

Type: `KamiSama.Modules.Locations.Entities.Province`

Kind: `Property`

## Description

Gets or sets the cities related to this province. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public virtual ICollection<City> Cities { get; set; } = [];
```

## Value

| Detail | Description |
| --- | --- |
| `Property` | The mutable navigation collection; provider registrations enable lazy-loading proxies for virtual navigations. |

## Example

No concise standalone example is available yet.

