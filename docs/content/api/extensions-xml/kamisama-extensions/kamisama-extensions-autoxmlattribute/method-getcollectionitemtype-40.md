# GetCollectionItemType

[Back to AutoXmlAttribute](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Xml](../../index.md)

Source: [src/Xml/AutoXmlAttribute.cs:40](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Xml/AutoXmlAttribute.cs#L40)

Type: `KamiSama.Extensions.AutoXmlAttribute`

Kind: `Method`

## Description

returns collection item type if the &lt;paramref name=&quot;type&quot;/&gt; is `Array` or `ICollection{T}`. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
protected static Type? GetCollectionItemType(Type type);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `type` | `Type` | `-` | The `type` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Type?` | Returns a `Type?` value. |

## Example

No concise standalone example is available yet.

