# GetCollectionItemType

[Back to AutoXmlAttribute](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Xml](../../index.md)

Source: [src/Xml/AutoXmlAttribute.cs:41](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Xml/AutoXmlAttribute.cs#L41)

Type: `KamiSama.Extensions.AutoXmlAttribute`

Kind: `Method`

## Description

Returns an array element type or the item type of an implemented `ICollection{T}` interface; otherwise, returns the supplied type unchanged. Use it with the surrounding package APIs when composing application code.

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

