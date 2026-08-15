# Write

[Back to DynamicObjectConverter](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Json](../../index.md)

Source: [src/Json/DynamicObjectConverter.cs:12](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Json/DynamicObjectConverter.cs#L12)

Type: `KamiSama.Extensions.Json.DynamicObjectConverter`

Kind: `Method`

## Description

Serializes the value using its runtime type. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public override void Write(Utf8JsonWriter writer, object? value, JsonSerializerOptions options);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `writer` | `Utf8JsonWriter` | `-` | The `writer` value passed to this member. |
| `value` | `object?` | `-` | The `value` value passed to this member. |
| `options` | `JsonSerializerOptions` | `-` | The `options` value passed to this member. |

## Example

No concise standalone example is available yet.

