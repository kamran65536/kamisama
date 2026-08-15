# AutoXmlArrayItemAttribute

<a id="autoxmlarrayitemattribute"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.Xml](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Xml/AutoXmlArrayItemAttribute.cs:10](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Xml/AutoXmlArrayItemAttribute.cs#L10)

Namespace: `KamiSama.Extensions`

Kind: `Class`

## Description

Marks an array field or property so XML array-item overrides are added for its concrete derived element types. Candidate derived types are supplied when the object graph&apos;s overrides are built.

## Declaration

```csharp
public class AutoXmlArrayItemAttribute : AutoXmlAttribute
```

## Example

```csharp
public abstract class Content;
public sealed class TextContent : Content { public string Text { get; set; } = ""; }

public sealed class Document
{
    [AutoXmlArrayItem]
    public Content[] Items { get; set; } = [];
}
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [VisitField](method-visitfield-44.md) | Adds an `XmlArrayItemAttribute` override for each non-abstract subclass of the field&apos;s array element type. Use it with the surrounding package APIs when composing application code. |
| [VisitProperty](method-visitproperty-21.md) | Adds an `XmlArrayItemAttribute` override for each non-abstract subclass of the property&apos;s array element type. Use it with the surrounding package APIs when composing application code. |
| [VisitType](method-visittype-16.md) | Throws because `AutoXmlArrayItemAttribute` can be applied only to fields and properties, not types. Use it with the surrounding package APIs when composing application code. |

