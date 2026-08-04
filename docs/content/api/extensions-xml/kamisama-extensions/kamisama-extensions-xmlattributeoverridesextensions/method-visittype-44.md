# VisitType

[Back to XmlAttributeOverridesExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Xml](../../index.md)

Source: [src/Xml/XmlAttributeOverridesExtensions.cs:44](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Xml/XmlAttributeOverridesExtensions.cs#L44)

Type: `KamiSama.Extensions.XmlAttributeOverridesExtensions`

Kind: `Method`

## Description

Visits the type and adds necessary overrides. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
internal static void VisitType(Type rootType, XmlAttributeOverrides overrides, HashSet<Type> visitedTypes, Type[] allTypes);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `rootType` | `Type` | `-` | The `rootType` value passed to this member. |
| `overrides` | `XmlAttributeOverrides` | `-` | The `overrides` value passed to this member. |
| `visitedTypes` | `HashSet<Type>` | `-` | The `visitedTypes` value passed to this member. |
| `allTypes` | `Type[]` | `-` | The `allTypes` value passed to this member. |

## Example

```csharp
var attr = new AutoXmlArrayItemAttribute();
```

