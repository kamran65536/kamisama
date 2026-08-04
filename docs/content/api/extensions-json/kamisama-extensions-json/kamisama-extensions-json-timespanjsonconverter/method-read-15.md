# Read

[Back to TimeSpanJsonConverter](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Json](../../index.md)

Source: [src/Json/TimeSpanJsonConverter.cs:15](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Json/TimeSpanJsonConverter.cs#L15)

Type: `KamiSama.Extensions.Json.TimeSpanJsonConverter`

Kind: `Method`

## Description

parses string as timespan. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options);
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
| `TimeSpan` | Returns a `TimeSpan` value. |

## Example

No concise standalone example is available yet.

