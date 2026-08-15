# Encrypt

[Back to CryptographyExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Core](../../index.md)

Source: [src/Core/CryptographyExtensions.cs:38](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Core/CryptographyExtensions.cs#L38)

Type: `KamiSama.Extensions.CryptographyExtensions`

Kind: `Method`

## Description

Configures a symmetric algorithm from the supplied factory and encrypts the data. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static byte[] Encrypt(this byte[] data, Func<SymmetricAlgorithm> algorithmFactory, byte[] key, byte[]? iv = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode padding = PaddingMode.Zeros);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `data (extension receiver)` | `byte[]` | `-` | the byte data to be encrypted |
| `algorithmFactory` | `Func<SymmetricAlgorithm>` | `-` | the function to generate symmetric algorithm |
| `key` | `byte[]` | `-` | the algorithm&apos;s key |
| `iv` | `byte[]?` | `null` | initial value, default is zero vector |
| `cipherMode` | `CipherMode` | `CipherMode.CBC` | Cipher mode, such as CBC, ECB, or CFB. |
| `padding` | `PaddingMode` | `PaddingMode.Zeros` | Padding mode, such as None, Zeros, or PKCS7. |

## Returns

| Type | Description |
| --- | --- |
| `byte[]` | Returns a `byte[]` value. |

## Example

No concise standalone example is available yet.

