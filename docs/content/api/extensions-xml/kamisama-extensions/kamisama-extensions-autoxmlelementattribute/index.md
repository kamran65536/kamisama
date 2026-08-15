# AutoXmlElementAttribute

<a id="autoxmlelementattribute"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.Xml](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Xml/AutoXmlElementAttribute.cs:12](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Xml/AutoXmlElementAttribute.cs#L12)

Namespace: `KamiSama.Extensions`

Kind: `Class`

## Description

Marks a field or property so XML-element overrides are added for its concrete derived value types. Collection members are mapped using their item type.

## Declaration

```csharp
public class AutoXmlElementAttribute : AutoXmlAttribute
```

## Example

```csharp
public abstract class Content;
public sealed class TextContent : Content { public string Text { get; set; } = ""; }

public sealed class Document
{
    [AutoXmlElement]
    public Content? Content { get; set; }
}
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [VisitField](method-visitfield-43.md) | Adds a named `XmlElementAttribute` override for each non-abstract subclass of the field&apos;s value or collection-item type. Use it with the surrounding package APIs when composing application code. |
| [VisitProperty](method-visitproperty-23.md) | Adds a named `XmlElementAttribute` override for each non-abstract subclass of the property&apos;s value or collection-item type. Use it with the surrounding package APIs when composing application code. |
| [VisitType](method-visittype-18.md) | Throws because `AutoXmlElementAttribute` can be applied only to fields and properties, not types. Use it with the surrounding package APIs when composing application code. |

