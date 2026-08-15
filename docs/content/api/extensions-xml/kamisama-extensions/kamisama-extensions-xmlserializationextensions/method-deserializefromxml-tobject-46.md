# DeserializeFromXml<TObject>

[Back to XmlSerializationExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Xml](../../index.md)

Source: [src/Xml/XmlSerializationExtensions.cs:46](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Xml/XmlSerializationExtensions.cs#L46)

Type: `KamiSama.Extensions.XmlSerializationExtensions`

Kind: `Method`

## Description

Deserializes an XML string into an instance of &lt;typeparamref name=&quot;TObject&quot;/&gt; using an optional custom serializer. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static TObject? DeserializeFromXml<TObject>(this string str, XmlSerializer? serializer = null);
```

## Type Parameters

| Name | Description |
| --- | --- |
| `TObject` | result object type |

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `str (extension receiver)` | `string` | `-` | string to be deserialized |
| `serializer` | `XmlSerializer?` | `null` | the custom xml serializer, default is null and new xml serializer will be created |

## Returns

| Type | Description |
| --- | --- |
| `TObject?` | Returns a `TObject?` value. |

## Example

No concise standalone example is available yet.

