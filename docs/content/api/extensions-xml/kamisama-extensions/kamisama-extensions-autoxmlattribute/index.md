# AutoXmlAttribute

<a id="autoxmlattribute"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.Xml](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Xml/AutoXmlAttribute.cs:13](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Xml/AutoXmlAttribute.cs#L13)

Namespace: `KamiSama.Extensions`

Kind: `Class`

## Description

Defines the base contract for attributes that add member-specific entries to an `XmlAttributeOverrides` collection. Concrete attributes control polymorphic element or array-item mappings.

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
| [GetCollectionItemType](method-getcollectionitemtype-41.md) | Returns an array element type or the item type of an implemented `ICollection{T}` interface; otherwise, returns the supplied type unchanged. Use it with the surrounding package APIs when composing application code. |
| [VisitField](method-visitfield-35.md) | Adds this attribute&apos;s XML overrides for the specified field. Use it with the surrounding package APIs when composing application code. |
| [VisitProperty](method-visitproperty-28.md) | Adds this attribute&apos;s XML overrides for the specified property. Use it with the surrounding package APIs when composing application code. |
| [VisitType](method-visittype-21.md) | Applies this attribute&apos;s XML overrides while visiting the specified type. Use it with the surrounding package APIs when composing application code. |

