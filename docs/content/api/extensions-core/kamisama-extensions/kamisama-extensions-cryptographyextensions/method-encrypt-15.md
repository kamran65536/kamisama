# Encrypt

[Back to CryptographyExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Core](../../index.md)

Source: [src/Core/CryptographyExtensions.cs:15](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Core/CryptographyExtensions.cs#L15)

Type: `KamiSama.Extensions.CryptographyExtensions`

Kind: `Method`

## Description

Encrypts data using specified algorithm (symmetric). Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
#region Generic Encryption/Decryption
public static byte[] Encrypt(this byte[] data, SymmetricAlgorithm algorithm);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `data (extension receiver)` | `byte[]` | `-` | the byte data to be encrypted |
| `algorithm` | `SymmetricAlgorithm` | `-` | the encryption algorithm |

## Returns

| Type | Description |
| --- | --- |
| `byte[]` | the cipher byte array |

## Example

No concise standalone example is available yet.

