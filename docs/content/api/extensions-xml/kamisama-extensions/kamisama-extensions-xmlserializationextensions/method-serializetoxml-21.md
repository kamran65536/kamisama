# SerializeToXml

[Back to XmlSerializationExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Xml](../../index.md)

Source: [src/Xml/XmlSerializationExtensions.cs:21](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Xml/XmlSerializationExtensions.cs#L21)

Type: `KamiSama.Extensions.XmlSerializationExtensions`

Kind: `Method`

## Description

Serializes an object to an XML string using an optional custom serializer and XML-writer configuration. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static string SerializeToXml(this object obj, Action<XmlWriterSettings>? settingsAction = null, XmlSerializer? serializer = null);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `obj (extension receiver)` | `object` | `-` | object to be serialized |
| `settingsAction` | `Action<XmlWriterSettings>?` | `null` | action to configure xml serializer |
| `serializer` | `XmlSerializer?` | `null` | the custom xml serializer, default is null and new xml serializer will be created |

## Returns

| Type | Description |
| --- | --- |
| `string` | Returns a `string` value. |

## Example

```csharp
var a = new A { X = 10 };

var result = a.SerializeToXml();
```

