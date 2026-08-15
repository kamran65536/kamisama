# AddAutoXmlAttributes

[Back to XmlAttributeOverridesExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Xml](../../index.md)

Source: [src/Xml/XmlAttributeOverridesExtensions.cs:32](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Xml/XmlAttributeOverridesExtensions.cs#L32)

Type: `KamiSama.Extensions.XmlAttributeOverridesExtensions`

Kind: `Method`

## Description

Populates the overrides for the root object graph using the supplied types as candidates for polymorphic members. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static void AddAutoXmlAttributes(this XmlAttributeOverrides overrides, Type rootType, Type[] allTypes);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `overrides (extension receiver)` | `XmlAttributeOverrides` | `-` | The `overrides` value passed to this member. |
| `rootType` | `Type` | `-` | The `rootType` value passed to this member. |
| `allTypes` | `Type[]` | `-` | The `allTypes` value passed to this member. |

## Example

```csharp
var parentRoot = typeof(ParentRoot);

var overrides = new XmlAttributeOverrides();

overrides.AddAutoXmlAttributes(parentRoot, default(Assembly[]));


foreach (var member in parentRoot.GetMembers())
```

