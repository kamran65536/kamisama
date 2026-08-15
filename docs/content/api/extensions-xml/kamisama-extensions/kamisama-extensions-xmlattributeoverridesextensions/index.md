# XmlAttributeOverridesExtensions

<a id="xmlattributeoverridesextensions"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.Xml](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Xml/XmlAttributeOverridesExtensions.cs:10](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Xml/XmlAttributeOverridesExtensions.cs#L10)

Namespace: `KamiSama.Extensions`

Kind: `Class`

## Description

Provides extension methods that populate `XmlAttributeOverrides` from `AutoXmlElementAttribute` and `AutoXmlArrayItemAttribute` annotations. Use the resulting overrides to construct an `XmlSerializer` for polymorphic object graphs.

## Declaration

```csharp
public static class XmlAttributeOverridesExtensions
```

## Example

```csharp
using System.Xml.Serialization;
using KamiSama.Extensions;

var overrides = new XmlAttributeOverrides();
overrides.AddAutoXmlAttributes(typeof(Document), [typeof(TextContent), typeof(ImageContent)]);

var serializer = new XmlSerializer(typeof(Document), overrides);
string xml = document.SerializeToXml(serializer: serializer);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [AddAutoXmlAttributes](method-addautoxmlattributes-18.md) | Populates the overrides for the root object graph using concrete derived types discovered in the specified assemblies. Use it with the surrounding package APIs when composing application code. |
| [AddAutoXmlAttributes](method-addautoxmlattributes-32.md) | Populates the overrides for the root object graph using the supplied types as candidates for polymorphic members. Use it with the surrounding package APIs when composing application code. |

