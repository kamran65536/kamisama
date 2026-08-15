# XmlSerializationExtensions

<a id="xmlserializationextensions"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.Xml](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Xml/XmlSerializationExtensions.cs:12](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Xml/XmlSerializationExtensions.cs#L12)

Namespace: `KamiSama.Extensions`

Kind: `Class`

## Description

Provides extension methods for serializing objects to XML strings and deserializing XML strings. Custom serializers support polymorphic models and other specialized XML mappings.

## Declaration

```csharp
public static class XmlSerializationExtensions
```

## Example

```csharp
using KamiSama.Extensions;

var product = new Product { Id = 42, Name = "Keyboard" };
string xml = product.SerializeToXml(settings => settings.Indent = true);
Product? copy = xml.DeserializeFromXml<Product>();
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [DeserializeFromXml<TObject>](method-deserializefromxml-tobject-46.md) | Deserializes an XML string into an instance of &lt;typeparamref name=&quot;TObject&quot;/&gt; using an optional custom serializer. Use it with the surrounding package APIs when composing application code. |
| [SerializeToXml](method-serializetoxml-21.md) | Serializes an object to an XML string using an optional custom serializer and XML-writer configuration. Use it with the surrounding package APIs when composing application code. |

