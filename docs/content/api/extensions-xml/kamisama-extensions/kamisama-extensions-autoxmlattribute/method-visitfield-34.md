# VisitField

[Back to AutoXmlAttribute](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Xml](../../index.md)

Source: [src/Xml/AutoXmlAttribute.cs:34](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Xml/AutoXmlAttribute.cs#L34)

Type: `KamiSama.Extensions.AutoXmlAttribute`

Kind: `Method`

## Description

Called when a field is visited to add proper items to `XmlAttributeOverrides`. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public abstract void VisitField(FieldInfo field, XmlAttributeOverrides overrides, Type[] allTypes);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `field` | `FieldInfo` | `-` | The `field` value passed to this member. |
| `overrides` | `XmlAttributeOverrides` | `-` | The `overrides` value passed to this member. |
| `allTypes` | `Type[]` | `-` | The `allTypes` value passed to this member. |

## Example

```csharp
var field = typeof(Wrapper2).GetField(nameof(Wrapper2.SomeField))!;
var overrides = new XmlAttributeOverrides();
var allTypes = new[] { typeof(int), typeof(double) };//some irrelevant types

var attr = new AutoXmlArrayItemAttribute();
```

