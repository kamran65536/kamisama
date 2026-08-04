# ConvertTo

[Back to ConversionExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Core](../../index.md)

Source: [src/Core/ConversionExtensions.cs:15](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Core/ConversionExtensions.cs#L15)

Type: `KamiSama.Extensions.ConversionExtensions`

Kind: `Method`

## Description

Converts an object to another type. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static object? ConvertTo(this object? obj, Type type, object? defaultValue = null);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `obj (extension receiver)` | `object?` | `-` | the source object |
| `type` | `Type` | `-` | the desired type for conversion |
| `defaultValue` | `object?` | `null` | default value if conversion is failed |

## Returns

| Type | Description |
| --- | --- |
| `object?` | Returns a `object?` value. |

## Example

No concise standalone example is available yet.

