# VisitField

[Back to XmlAttributeOverridesExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Xml](../../index.md)

Source: [src/Xml/XmlAttributeOverridesExtensions.cs:71](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Xml/XmlAttributeOverridesExtensions.cs#L71)

Type: `KamiSama.Extensions.XmlAttributeOverridesExtensions`

Kind: `Method`

## Description

Visits the field and adds necessary overrides. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
internal static void VisitField(FieldInfo field, XmlAttributeOverrides overrides, HashSet<Type> visitedTypes, Type[] allTypes);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `field` | `FieldInfo` | `-` | The `field` value passed to this member. |
| `overrides` | `XmlAttributeOverrides` | `-` | The `overrides` value passed to this member. |
| `visitedTypes` | `HashSet<Type>` | `-` | The `visitedTypes` value passed to this member. |
| `allTypes` | `Type[]` | `-` | The `allTypes` value passed to this member. |

## Example

```csharp
var field = typeof(Wrapper2).GetField(nameof(Wrapper2.SomeField))!;
var overrides = new XmlAttributeOverrides();
var allTypes = new[] { typeof(int), typeof(double) };//some irrelevant types

var attr = new AutoXmlArrayItemAttribute();
```

