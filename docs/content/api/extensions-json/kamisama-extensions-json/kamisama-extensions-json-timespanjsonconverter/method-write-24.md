# Write

[Back to TimeSpanJsonConverter](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Json](../../index.md)

Source: [src/Json/TimeSpanJsonConverter.cs:24](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Json/TimeSpanJsonConverter.cs#L24)

Type: `KamiSama.Extensions.Json.TimeSpanJsonConverter`

Kind: `Method`

## Description

Writes the `TimeSpan` as a JSON string using its standard representation. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `writer` | `Utf8JsonWriter` | `-` | The `writer` value passed to this member. |
| `value` | `TimeSpan` | `-` | The `value` value passed to this member. |
| `options` | `JsonSerializerOptions` | `-` | The `options` value passed to this member. |

## Example

No concise standalone example is available yet.

