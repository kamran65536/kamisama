# ToBytes

[Back to StringExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Core](../../index.md)

Source: [src/Core/StringExtensions.cs:14](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Core/StringExtensions.cs#L14)

Type: `KamiSama.Extensions.StringExtensions`

Kind: `Method`

## Description

Converts string to byte array using specified encoding. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static byte[] ToBytes(this string? str, Encoding? encoding = null);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `str (extension receiver)` | `string?` | `-` | the string to be converted |
| `encoding` | `Encoding?` | `null` | encoding, default is Encoding.UTF8 |

## Returns

| Type | Description |
| --- | --- |
| `byte[]` | Returns a `byte[]` value. |

## Example

```csharp
using KamiSama.Extensions;

var bytes = "hello".ToBytes();
```

