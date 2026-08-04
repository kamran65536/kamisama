# AutoXmlAttribute

<a id="autoxmlattribute"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.Xml](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Xml/AutoXmlAttribute.cs:12](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Xml/AutoXmlAttribute.cs#L12)

Namespace: `KamiSama.Extensions`

Kind: `Class`

## Description

base class for all Auto...Attributes like AutoXmlElement, AutoXmlArrayItem. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public abstract class AutoXmlAttribute  : Attribute
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [GetCollectionItemType](method-getcollectionitemtype-40.md) | returns collection item type if the &lt;paramref name=&quot;type&quot;/&gt; is `Array` or `ICollection{T}`. Use it with the surrounding package APIs when composing application code. |
| [VisitField](method-visitfield-34.md) | Called when a field is visited to add proper items to `XmlAttributeOverrides`. Use it with the surrounding package APIs when composing application code. |
| [VisitProperty](method-visitproperty-27.md) | Called when a property is visited to add proper items to `XmlAttributeOverrides`. Use it with the surrounding package APIs when composing application code. |
| [VisitType](method-visittype-20.md) | Called when a type is visited to add proper items to `XmlAttributeOverrides`. Use it with the surrounding package APIs when composing application code. |

