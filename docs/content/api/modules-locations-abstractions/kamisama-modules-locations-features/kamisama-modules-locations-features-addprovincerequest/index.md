# AddProvinceRequest

<a id="addprovincerequest"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Locations.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Locations.Abstractions/Features/Dtos.cs:59](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Abstractions/Features/Dtos.cs#L59)

Namespace: `KamiSama.Modules.Locations.Features`

Kind: `Record`

## Description

Carries the name for a new province. The name has a 100-character data-annotation limit, while uniqueness is not enforced by the Core add feature.

## Declaration

```csharp
public record AddProvinceRequest([property: MaxLength(100)] string Name);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Abstractions/Features/Dtos.cs#L59)

Supplies the name for a new province. Use it with the surrounding package APIs when composing application code.

```csharp
public record AddProvinceRequest([property: MaxLength(100)] string Name);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `Name` | `string` | `-` | The province name, limited to 100 characters by data annotations and the Core EF model. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

