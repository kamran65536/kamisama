# CryptographyExtensions

<a id="cryptographyextensions"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Core/CryptographyExtensions.cs:7](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Core/CryptographyExtensions.cs#L7)

Namespace: `KamiSama.Extensions`

Kind: `Class`

## Description

Provides byte-array encryption, decryption, and CBC-based authentication helpers for symmetric algorithms, plus RSA encryption and decryption. Legacy algorithms are included for interoperability; prefer modern authenticated encryption for new designs.

## Declaration

```csharp
public static class CryptographyExtensions
```

## Example

```csharp
using System.Security.Cryptography;
using System.Text;

byte[] key = RandomNumberGenerator.GetBytes(32);
byte[] iv = RandomNumberGenerator.GetBytes(16);
byte[] plaintext = Encoding.UTF8.GetBytes("secret");

byte[] cipher = plaintext.AesEncrypt(key, iv, padding: PaddingMode.PKCS7);
byte[] restored = cipher.AesDecrypt(key, iv, padding: PaddingMode.PKCS7);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [AesDecrypt](method-aesdecrypt-216.md) | Decrypts cipher data using AES algorithm. Use it with the surrounding package APIs when composing application code. |
| [AesEncrypt](method-aesencrypt-205.md) | Encrypts using AES algorithm. Use it with the surrounding package APIs when composing application code. |
| [AesSign](method-aessign-226.md) | Computes an AES CBC-based message authentication value and returns the final encrypted block. Use it with the surrounding package APIs when composing application code. |
| [Decrypt](method-decrypt-55.md) | Decrypts ciphertext using the configured symmetric algorithm. Use it with the surrounding package APIs when composing application code. |
| [Decrypt](method-decrypt-78.md) | Configures a symmetric algorithm from the supplied factory and decrypts the ciphertext. Use it with the surrounding package APIs when composing application code. |
| [DesDecrypt](method-desdecrypt-148.md) | Decrypts cipher data using DES algorithm. Use it with the surrounding package APIs when composing application code. |
| [DesEncrypt](method-desencrypt-137.md) | Encrypts using DES algorithm. Use it with the surrounding package APIs when composing application code. |
| [DesSign](method-dessign-158.md) | Computes a DES CBC-based message authentication value and returns the final encrypted block. Use it with the surrounding package APIs when composing application code. |
| [Encrypt](method-encrypt-16.md) | Encrypts data using the configured symmetric algorithm. Use it with the surrounding package APIs when composing application code. |
| [Encrypt](method-encrypt-38.md) | Configures a symmetric algorithm from the supplied factory and encrypts the data. Use it with the surrounding package APIs when composing application code. |
| [RsaDecrypt](method-rsadecrypt-252.md) | Decrypts ciphertext using an RSA private key represented as XML. Use it with the surrounding package APIs when composing application code. |
| [RsaEncrypt](method-rsaencrypt-237.md) | Encrypts data using an RSA public key represented as XML. Use it with the surrounding package APIs when composing application code. |
| [Sign](method-sign-95.md) | Computes a CBC-based message authentication value and returns the final encrypted block. Use it with the surrounding package APIs when composing application code. |
| [Sign](method-sign-115.md) | Computes a CBC-based message authentication value with the configured symmetric algorithm and returns the final encrypted block. Use it with the surrounding package APIs when composing application code. |
| [TripleDesDecrypt](method-tripledesdecrypt-182.md) | Decrypts cipher data using Triple DES (3DES) algorithm. Use it with the surrounding package APIs when composing application code. |
| [TripleDesEncrypt](method-tripledesencrypt-171.md) | Encrypts using Triple DES (3DES) algorithm. Use it with the surrounding package APIs when composing application code. |
| [TripleDesSign](method-tripledessign-192.md) | Computes a Triple DES CBC-based message authentication value and returns the final encrypted block. Use it with the surrounding package APIs when composing application code. |

