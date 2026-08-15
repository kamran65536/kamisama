# VisitField

[Back to AutoXmlArrayItemAttribute](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Xml](../../index.md)

Source: [src/Xml/AutoXmlArrayItemAttribute.cs:44](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Xml/AutoXmlArrayItemAttribute.cs#L44)

Type: `KamiSama.Extensions.AutoXmlArrayItemAttribute`

Kind: `Method`

## Description

Adds an `XmlArrayItemAttribute` override for each non-abstract subclass of the field&apos;s array element type. Use it with the surrounding package APIs when composing application code.

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

