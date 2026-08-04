# Decrypt

[Back to CryptographyExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Core](../../index.md)

Source: [src/Core/CryptographyExtensions.cs:77](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Core/CryptographyExtensions.cs#L77)

Type: `KamiSama.Extensions.CryptographyExtensions`

Kind: `Method`

## Description

Decrypts cipher data using the specified algorithm. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static byte[] Decrypt(this byte[] cipher, Func<SymmetricAlgorithm> algorithmFactory, byte[] key, byte[]? iv = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode padding = PaddingMode.Zeros);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `cipher (extension receiver)` | `byte[]` | `-` | the cipher data |
| `algorithmFactory` | `Func<SymmetricAlgorithm>` | `-` | the function to generate symmetric algorithm |
| `key` | `byte[]` | `-` | the algorithm&apos;s key |
| `iv` | `byte[]?` | `null` | initial value, default is zero vector |
| `cipherMode` | `CipherMode` | `CipherMode.CBC` | cipher mode, such as cbc, ecb, fcb, ... |
| `padding` | `PaddingMode` | `PaddingMode.Zeros` | padding mode, such as none, zeros, pkcs5... |

## Returns

| Type | Description |
| --- | --- |
| `byte[]` | Returns a `byte[]` value. |

## Example

No concise standalone example is available yet.

