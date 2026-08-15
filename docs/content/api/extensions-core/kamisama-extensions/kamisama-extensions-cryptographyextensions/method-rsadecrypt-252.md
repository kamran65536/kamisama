# RsaDecrypt

[Back to CryptographyExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Core](../../index.md)

Source: [src/Core/CryptographyExtensions.cs:252](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Core/CryptographyExtensions.cs#L252)

Type: `KamiSama.Extensions.CryptographyExtensions`

Kind: `Method`

## Description

Decrypts ciphertext using an RSA private key represented as XML. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static byte[] RsaDecrypt(this byte[] cipher, string xmlKey, RSAEncryptionPadding padding);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `cipher (extension receiver)` | `byte[]` | `-` | Ciphertext to be decrypted. |
| `xmlKey` | `string` | `-` | XML key containing the private key material used for decryption. |
| `padding` | `RSAEncryptionPadding` | `-` | padding mode |

## Returns

| Type | Description |
| --- | --- |
| `byte[]` | Returns a `byte[]` value. |

## Example

```csharp
var key = Resources.RsaKey;
var data = "Salaam".ToBytes();
var encrypted = data.RsaEncrypt(key, RSAEncryptionPadding.Pkcs1);
var decrypted = encrypted.RsaDecrypt(key, RSAEncryptionPadding.Pkcs1);
```

