# DeserializeFromJson<TObject>

[Back to JsonSerializationExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Json](../../index.md)

Source: [src/Json/JsonSerializationExtensions.cs:115](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Json/JsonSerializationExtensions.cs#L115)

Type: `KamiSama.Extensions.JsonSerializationExtensions`

Kind: `Method`

## Description

Deserializes from json string using `JsonSerializer`. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static TObject? DeserializeFromJson<TObject>(this string str, JsonSerializerOptions? options = null);
```

## Type Parameters

| Name | Description |
| --- | --- |
| `TObject` |  |

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `str (extension receiver)` | `string` | `-` | The `str` value passed to this member. |
| `options` | `JsonSerializerOptions?` | `null` | The `options` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `TObject?` | Returns a `TObject?` value. |

## Example

No concise standalone example is available yet.

