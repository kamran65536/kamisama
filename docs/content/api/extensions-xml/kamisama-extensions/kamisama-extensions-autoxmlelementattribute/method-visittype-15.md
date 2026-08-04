# VisitType

[Back to AutoXmlElementAttribute](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Xml](../../index.md)

Source: [src/Xml/AutoXmlElementAttribute.cs:15](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Xml/AutoXmlElementAttribute.cs#L15)

Type: `KamiSama.Extensions.AutoXmlElementAttribute`

Kind: `Method`

## Description

Runs the `VisitType` operation on `AutoXmlElementAttribute`. Use it when your code needs this specific behavior from the package.

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

