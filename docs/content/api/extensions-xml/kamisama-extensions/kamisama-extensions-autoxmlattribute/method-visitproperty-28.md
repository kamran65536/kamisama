# VisitProperty

[Back to AutoXmlAttribute](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Xml](../../index.md)

Source: [src/Xml/AutoXmlAttribute.cs:28](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Xml/AutoXmlAttribute.cs#L28)

Type: `KamiSama.Extensions.AutoXmlAttribute`

Kind: `Method`

## Description

Adds this attribute&apos;s XML overrides for the specified property. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public abstract void VisitProperty(PropertyInfo property, XmlAttributeOverrides overrides, Type[] allTypes);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `property` | `PropertyInfo` | `-` | The `property` value passed to this member. |
| `overrides` | `XmlAttributeOverrides` | `-` | The `overrides` value passed to this member. |
| `allTypes` | `Type[]` | `-` | The `allTypes` value passed to this member. |

## Example

```csharp
var property = typeof(Wrapper1).GetProperty(nameof(Wrapper1.SomeProperty))!;
var overrides = new XmlAttributeOverrides();
var allTypes = new[] { typeof(int), typeof(double) };//some irrelevant types

var attr = new AutoXmlArrayItemAttribute();
```

