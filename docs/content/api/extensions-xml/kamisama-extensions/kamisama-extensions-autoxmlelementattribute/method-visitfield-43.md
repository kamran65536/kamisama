# VisitField

[Back to AutoXmlElementAttribute](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Xml](../../index.md)

Source: [src/Xml/AutoXmlElementAttribute.cs:43](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Xml/AutoXmlElementAttribute.cs#L43)

Type: `KamiSama.Extensions.AutoXmlElementAttribute`

Kind: `Method`

## Description

Adds a named `XmlElementAttribute` override for each non-abstract subclass of the field&apos;s value or collection-item type. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public override void VisitField(FieldInfo field, XmlAttributeOverrides overrides, Type[] allTypes);
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

