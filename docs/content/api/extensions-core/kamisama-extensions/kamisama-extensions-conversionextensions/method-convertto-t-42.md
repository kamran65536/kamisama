# ConvertTo<T>

[Back to ConversionExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Core](../../index.md)

Source: [src/Core/ConversionExtensions.cs:42](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Core/ConversionExtensions.cs#L42)

Type: `KamiSama.Extensions.ConversionExtensions`

Kind: `Method`

## Description

Converts an object to another type. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static T? ConvertTo<T>(this object? obj, T? defaultValue = default);
```

## Type Parameters

| Name | Description |
| --- | --- |
| `T` | the desired type for conversion |

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `obj (extension receiver)` | `object?` | `-` | the source object |
| `defaultValue` | `T?` | `default` | default value if conversion is failed |

## Returns

| Type | Description |
| --- | --- |
| `T?` | Returns a `T?` value. |

## Example

No concise standalone example is available yet.

