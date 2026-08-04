# ComputeHash

[Back to HashExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Core](../../index.md)

Source: [src/Core/HashExtensions.cs:35](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Core/HashExtensions.cs#L35)

Type: `KamiSama.Extensions.HashExtensions`

Kind: `Method`

## Description

Computes hash for byte array equivalent string data. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static byte[] ComputeHash(this string data, HashAlgorithm algorithm, Encoding? encoding = null);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `data (extension receiver)` | `string` | `-` | the data to be hashed |
| `algorithm` | `HashAlgorithm` | `-` | the hashing algorithm |
| `encoding` | `Encoding?` | `null` | encoding used to convert string to byte array, default is UTF8 |

## Returns

| Type | Description |
| --- | --- |
| `byte[]` | Returns a `byte[]` value. |

## Example

No concise standalone example is available yet.

