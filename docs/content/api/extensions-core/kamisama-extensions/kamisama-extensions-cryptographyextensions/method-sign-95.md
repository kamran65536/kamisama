# Sign

[Back to CryptographyExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Core](../../index.md)

Source: [src/Core/CryptographyExtensions.cs:95](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Core/CryptographyExtensions.cs#L95)

Type: `KamiSama.Extensions.CryptographyExtensions`

Kind: `Method`

## Description

Computes a CBC-based message authentication value and returns the final encrypted block. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static byte[] Sign(this byte[] data, SymmetricAlgorithm algorithm);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `data (extension receiver)` | `byte[]` | `-` | the byte data to be signed |
| `algorithm` | `SymmetricAlgorithm` | `-` | the signing algorithm |

## Returns

| Type | Description |
| --- | --- |
| `byte[]` | Returns a `byte[]` value. |

## Example

No concise standalone example is available yet.

