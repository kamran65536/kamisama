# JsonSerializationExtensions

<a id="jsonserializationextensions"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.Json](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Json/JsonSerializationExtensions.cs:10](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Json/JsonSerializationExtensions.cs#L10)

Namespace: `KamiSama.Extensions`

Kind: `Class`

## Description

Provides extensions for JSON serialization, deserialization, dynamic conversion, and converter registration. The registration helpers mutate and return the supplied `JsonSerializerOptions` instance.

## Declaration

```csharp
public static class JsonSerializationExtensions
```

## Example

```csharp
using KamiSama.Extensions;

var payload = new { Id = 42, Name = "KamiSama" };
string json = payload.SerializeToJson(options => options.WriteIndented = true);
dynamic? value = json.ConvertJsonToDynamicObject();
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [AddHexByteConverter](method-addhexbyteconverter-165.md) | Adds a `HexByteArrayJsonConverter` to these serializer options. Use it with the surrounding package APIs when composing application code. |
| [AddHierarchicalConverter<T>](method-addhierarchicalconverter-t-143.md) | Adds a `HierarchicalJsonConverter{T}` to these serializer options. Use it with the surrounding package APIs when composing application code. |
| [AddTimeSpanJsonConverter](method-addtimespanjsonconverter-154.md) | Adds a `TimeSpanJsonConverter` to these serializer options. Use it with the surrounding package APIs when composing application code. |
| [ConvertJsonToDynamicObject](method-convertjsontodynamicobject-25.md) | Converts a JSON element to an `ExpandoObject`, object array, scalar CLR value, or . Use it with the surrounding package APIs when composing application code. |
| [ConvertJsonToDynamicObject](method-convertjsontodynamicobject-71.md) | Parses a JSON string with the specified document options and converts it to a dynamic CLR object graph. Use it with the surrounding package APIs when composing application code. |
| [ConvertJsonToDynamicObject](method-convertjsontodynamicobject-83.md) | Parses a JSON string using configured document options and converts it to a dynamic CLR object graph. Use it with the surrounding package APIs when composing application code. |
| [DeserializeFromJson<TObject>](method-deserializefromjson-tobject-116.md) | Deserializes the JSON string as &lt;typeparamref name=&quot;TObject&quot;/&gt; using the supplied options. Use it with the surrounding package APIs when composing application code. |
| [DeserializeFromJson<TObject>](method-deserializefromjson-tobject-125.md) | Deserializes the JSON string as &lt;typeparamref name=&quot;TObject&quot;/&gt; using options configured by the supplied callback. Use it with the surrounding package APIs when composing application code. |
| [SerializeToJson](method-serializetojson-18.md) | Serializes the object to JSON using `JsonSerializer` and the supplied options. Use it with the surrounding package APIs when composing application code. |
| [SerializeToJson](method-serializetojson-97.md) | Serializes the object to JSON using serializer options configured by the supplied callback. Use it with the surrounding package APIs when composing application code. |

