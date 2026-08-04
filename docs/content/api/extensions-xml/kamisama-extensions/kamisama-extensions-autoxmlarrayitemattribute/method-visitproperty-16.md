# VisitProperty

[Back to AutoXmlArrayItemAttribute](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Xml](../../index.md)

Source: [src/Xml/AutoXmlArrayItemAttribute.cs:16](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Xml/AutoXmlArrayItemAttribute.cs#L16)

Type: `KamiSama.Extensions.AutoXmlArrayItemAttribute`

Kind: `Method`

## Description

Runs the `VisitProperty` operation on `AutoXmlArrayItemAttribute`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
public override void VisitProperty(PropertyInfo property, XmlAttributeOverrides overrides, Type[] allTypes);
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

