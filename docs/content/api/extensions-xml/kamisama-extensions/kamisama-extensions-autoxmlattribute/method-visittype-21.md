# VisitType

[Back to AutoXmlAttribute](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Xml](../../index.md)

Source: [src/Xml/AutoXmlAttribute.cs:21](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Xml/AutoXmlAttribute.cs#L21)

Type: `KamiSama.Extensions.AutoXmlAttribute`

Kind: `Method`

## Description

Applies this attribute&apos;s XML overrides while visiting the specified type. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public abstract void VisitType(Type type, XmlAttributeOverrides overrides, Type[] allTypes);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `type` | `Type` | `-` | The `type` value passed to this member. |
| `overrides` | `XmlAttributeOverrides` | `-` | The `overrides` value passed to this member. |
| `allTypes` | `Type[]` | `-` | The `allTypes` value passed to this member. |

## Example

```csharp
var attr = new AutoXmlArrayItemAttribute();
```

