# Write

[Back to HierarchicalJsonConverter<T>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Json](../../index.md)

Source: [src/Json/HirerarchialJsonConverter.cs:65](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Json/HirerarchialJsonConverter.cs#L65)

Type: `KamiSama.Extensions.Json.HierarchicalJsonConverter<T>`

Kind: `Method`

## Description

Writes a channel configuration (basically this method simply calls JsonSerializer.Serialize method). Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `writer` | `Utf8JsonWriter` | `-` | The `writer` value passed to this member. |
| `value` | `T` | `-` | The `value` value passed to this member. |
| `options` | `JsonSerializerOptions` | `-` | The `options` value passed to this member. |

## Example

No concise standalone example is available yet.

