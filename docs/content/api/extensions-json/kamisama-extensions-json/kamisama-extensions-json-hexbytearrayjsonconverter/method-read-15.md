# Read

[Back to HexByteArrayJsonConverter](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Json](../../index.md)

Source: [src/Json/HexByteArrayJsonConverter.cs:15](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Json/HexByteArrayJsonConverter.cs#L15)

Type: `KamiSama.Extensions.Json.HexByteArrayJsonConverter`

Kind: `Method`

## Description

Reads hex value as byte array from input. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public override byte[]? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options);
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
| `byte[]?` | Returns a `byte[]?` value. |

## Example

No concise standalone example is available yet.

