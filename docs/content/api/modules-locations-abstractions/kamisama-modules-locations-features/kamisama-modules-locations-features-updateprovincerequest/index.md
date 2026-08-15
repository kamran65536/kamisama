# UpdateProvinceRequest

<a id="updateprovincerequest"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Locations.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Locations.Abstractions/Features/Dtos.cs:64](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Abstractions/Features/Dtos.cs#L64)

Namespace: `KamiSama.Modules.Locations.Features`

Kind: `Record`

## Description

Carries the replacement name for an existing province. The name has a 100-character data-annotation limit, while uniqueness is not enforced by the Core update feature.

## Declaration

```csharp
public record UpdateProvinceRequest([property: MaxLength(100)] string Name);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Abstractions/Features/Dtos.cs#L64)

Supplies the replacement name for an existing province. Use it with the surrounding package APIs when composing application code.

```csharp
public record UpdateProvinceRequest([property: MaxLength(100)] string Name);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `Name` | `string` | `-` | The province name, limited to 100 characters by data annotations and the Core EF model. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

