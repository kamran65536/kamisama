# Sign

[Back to CryptographyExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Core](../../index.md)

Source: [src/Core/CryptographyExtensions.cs:115](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Core/CryptographyExtensions.cs#L115)

Type: `KamiSama.Extensions.CryptographyExtensions`

Kind: `Method`

## Description

Computes a CBC-based message authentication value with the configured symmetric algorithm and returns the final encrypted block. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static byte[] Sign(this byte[] data, Func<SymmetricAlgorithm> algorithmFactory, byte[] key, byte[]? iv = null, PaddingMode padding = PaddingMode.Zeros);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `data (extension receiver)` | `byte[]` | `-` | the byte data to be signed |
| `algorithmFactory` | `Func<SymmetricAlgorithm>` | `-` | the function to generate symmetric algorithm |
| `key` | `byte[]` | `-` | the algorithm&apos;s key |
| `iv` | `byte[]?` | `null` | initial value, default is zero vector |
| `padding` | `PaddingMode` | `PaddingMode.Zeros` | Padding mode, such as None, Zeros, or PKCS7. |

## Returns

| Type | Description |
| --- | --- |
| `byte[]` | Returns a `byte[]` value. |

## Example

No concise standalone example is available yet.

