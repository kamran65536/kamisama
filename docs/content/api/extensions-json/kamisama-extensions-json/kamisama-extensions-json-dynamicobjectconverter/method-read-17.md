# Read

[Back to DynamicObjectConverter](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Json](../../index.md)

Source: [src/Json/DynamicObjectConverter.cs:17](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Json/DynamicObjectConverter.cs#L17)

Type: `KamiSama.Extensions.Json.DynamicObjectConverter`

Kind: `Method`

## Description

Reads a JSON value and converts it to an `ExpandoObject`, array, scalar value, or . Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public override object Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `reader (ref)` | `Utf8JsonReader` | `-` | The `reader` value passed to this member. |
| `typeToConvert` | `Type` | `-` | The `typeToConvert` value passed to this member. |
| `options` | `JsonSerializerOptions` | `-` | The `options` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `object` | Returns a `object` value. |

## Example

No concise standalone example is available yet.

