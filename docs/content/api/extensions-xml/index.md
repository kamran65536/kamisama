# KamiSama.Extensions.Xml

[Back to package index](../index.md)

Version: `10.0.0`

## Description

Serialize objects to XML strings and deserialize XML strings using configurable XmlSerializer and XmlWriterSettings instances. Build attribute-driven XmlAttributeOverrides for polymorphic elements and array items.

## How to use

```shell
dotnet add package KamiSama.Extensions.Xml --version 10.0.0
```

Use `KamiSama.Extensions` for both string serialization and polymorphic override helpers. Decorate polymorphic members, discover their concrete types, and pass the resulting serializer to the string helpers:

```csharp
using System.Xml.Serialization;
using KamiSama.Extensions;

var overrides = new XmlAttributeOverrides();
overrides.AddAutoXmlAttributes(typeof(Document), [typeof(TextContent)]);
var serializer = new XmlSerializer(typeof(Document), overrides);

string xml = document.SerializeToXml(serializer: serializer);
Document? copy = xml.DeserializeFromXml<Document>(serializer);
```

`SerializeToXml` and `DeserializeFromXml<T>` operate on strings. Models must still satisfy the normal `XmlSerializer` requirements; `AutoXmlArrayItemAttribute` supports array members, and candidate discovery finds non-abstract subclasses rather than interface implementations.

## Namespaces

- [KamiSama.Extensions](kamisama-extensions/index.md) (6 types)

## Types

- [KamiSama.Extensions.AutoXmlArrayItemAttribute](kamisama-extensions/kamisama-extensions-autoxmlarrayitemattribute/index.md) - Marks an array field or property so XML array-item overrides are added for its concrete derived element types. Candidate derived types are supplied when the object graph&apos;s overrides are built.
- [KamiSama.Extensions.AutoXmlAttribute](kamisama-extensions/kamisama-extensions-autoxmlattribute/index.md) - Defines the base contract for attributes that add member-specific entries to an `XmlAttributeOverrides` collection. Concrete attributes control polymorphic element or array-item mappings.
- [KamiSama.Extensions.AutoXmlElement<TValue>](kamisama-extensions/kamisama-extensions-autoxmlelement-tvalue/index.md) - Wraps a polymorphic value so its containing XML element can retain a stable name while the nested value uses its concrete type. The implicit conversion makes wrapper creation transparent to callers.
- [KamiSama.Extensions.AutoXmlElementAttribute](kamisama-extensions/kamisama-extensions-autoxmlelementattribute/index.md) - Marks a field or property so XML-element overrides are added for its concrete derived value types. Collection members are mapped using their item type.
- [KamiSama.Extensions.XmlAttributeOverridesExtensions](kamisama-extensions/kamisama-extensions-xmlattributeoverridesextensions/index.md) - Provides extension methods that populate `XmlAttributeOverrides` from `AutoXmlElementAttribute` and `AutoXmlArrayItemAttribute` annotations. Use the resulting overrides to construct an `XmlSerializer` for polymorphic object graphs.
- [KamiSama.Extensions.XmlSerializationExtensions](kamisama-extensions/kamisama-extensions-xmlserializationextensions/index.md) - Provides extension methods for serializing objects to XML strings and deserializing XML strings. Custom serializers support polymorphic models and other specialized XML mappings.
