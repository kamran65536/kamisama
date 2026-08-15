# VisitType

[Back to AutoXmlElementAttribute](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Xml](../../index.md)

Source: [src/Xml/AutoXmlElementAttribute.cs:18](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Xml/AutoXmlElementAttribute.cs#L18)

Type: `KamiSama.Extensions.AutoXmlElementAttribute`

Kind: `Method`

## Description

Throws because `AutoXmlElementAttribute` can be applied only to fields and properties, not types. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public override void VisitType(Type? rootType, XmlAttributeOverrides? overrides, Type[]? allTypes);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `rootType` | `Type?` | `-` | The `rootType` value passed to this member. |
| `overrides` | `XmlAttributeOverrides?` | `-` | The `overrides` value passed to this member. |
| `allTypes` | `Type[]?` | `-` | The `allTypes` value passed to this member. |

## Example

```csharp
var attr = new AutoXmlArrayItemAttribute();
```

