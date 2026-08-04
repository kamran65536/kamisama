# Read

[Back to BigIntegerJsonConverter](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Json](../../index.md)

Source: [src/Json/BigIntegerJsonConverter.cs:11](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Json/BigIntegerJsonConverter.cs#L11)

Type: `KamiSama.Extensions.Json.BigIntegerJsonConverter`

Kind: `Method`

## Description

Runs the `Read` operation on `BigIntegerJsonConverter`. Use it when your code needs this specific behavior from the package.

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

