# AddAutoXmlAttributes

[Back to XmlAttributeOverridesExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Xml](../../index.md)

Source: [src/Xml/XmlAttributeOverridesExtensions.cs:18](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Xml/XmlAttributeOverridesExtensions.cs#L18)

Type: `KamiSama.Extensions.XmlAttributeOverridesExtensions`

Kind: `Method`

## Description

Populates the overrides for the root object graph using concrete derived types discovered in the specified assemblies. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static void AddAutoXmlAttributes(this XmlAttributeOverrides overrides, Type rootType, Assembly[]? assemblies);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `overrides (extension receiver)` | `XmlAttributeOverrides` | `-` | The `overrides` value passed to this member. |
| `rootType` | `Type` | `-` | The `rootType` value passed to this member. |
| `assemblies` | `Assembly[]?` | `-` | The `assemblies` value passed to this member. |

## Example

```csharp
var parentRoot = typeof(ParentRoot);

var overrides = new XmlAttributeOverrides();

overrides.AddAutoXmlAttributes(parentRoot, default(Assembly[]));


foreach (var member in parentRoot.GetMembers())
```

