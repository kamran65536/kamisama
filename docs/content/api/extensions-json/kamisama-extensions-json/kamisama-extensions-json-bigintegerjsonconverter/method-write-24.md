# Write

[Back to BigIntegerJsonConverter](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Json](../../index.md)

Source: [src/Json/BigIntegerJsonConverter.cs:24](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Json/BigIntegerJsonConverter.cs#L24)

Type: `KamiSama.Extensions.Json.BigIntegerJsonConverter`

Kind: `Method`

## Description

Writes the `BigInteger` as a JSON string containing its decimal representation. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public override void Write(Utf8JsonWriter writer, BigInteger value, JsonSerializerOptions options);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `writer` | `Utf8JsonWriter` | `-` | The `writer` value passed to this member. |
| `value` | `BigInteger` | `-` | The `value` value passed to this member. |
| `options` | `JsonSerializerOptions` | `-` | The `options` value passed to this member. |

## Example

No concise standalone example is available yet.

