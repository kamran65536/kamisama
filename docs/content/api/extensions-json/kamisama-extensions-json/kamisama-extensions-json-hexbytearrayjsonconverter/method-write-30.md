# Write

[Back to HexByteArrayJsonConverter](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Json](../../index.md)

Source: [src/Json/HexByteArrayJsonConverter.cs:30](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Json/HexByteArrayJsonConverter.cs#L30)

Type: `KamiSama.Extensions.Json.HexByteArrayJsonConverter`

Kind: `Method`

## Description

Writes the byte array as an uppercase hexadecimal JSON string. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public override void Write(Utf8JsonWriter writer, byte[] value, JsonSerializerOptions options);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `writer` | `Utf8JsonWriter` | `-` | The `writer` value passed to this member. |
| `value` | `byte[]` | `-` | The `value` value passed to this member. |
| `options` | `JsonSerializerOptions` | `-` | The `options` value passed to this member. |

## Example

No concise standalone example is available yet.

