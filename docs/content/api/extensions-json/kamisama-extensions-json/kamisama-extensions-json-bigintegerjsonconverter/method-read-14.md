# Read

[Back to BigIntegerJsonConverter](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Json](../../index.md)

Source: [src/Json/BigIntegerJsonConverter.cs:14](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Json/BigIntegerJsonConverter.cs#L14)

Type: `KamiSama.Extensions.Json.BigIntegerJsonConverter`

Kind: `Method`

## Description

Reads a `BigInteger` from a JSON string or number token. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public override BigInteger Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options);
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
| `BigInteger` | Returns a `BigInteger` value. |

## Example

No concise standalone example is available yet.

