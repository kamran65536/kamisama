# Read

[Back to DynamicObjectConverter](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Json](../../index.md)

Source: [src/Json/DynamicObjectConverter.cs:12](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Json/DynamicObjectConverter.cs#L12)

Type: `KamiSama.Extensions.Json.DynamicObjectConverter`

Kind: `Method`

## Description

Runs the `Read` operation on `DynamicObjectConverter`. Use it when your code needs this specific behavior from the package.

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

