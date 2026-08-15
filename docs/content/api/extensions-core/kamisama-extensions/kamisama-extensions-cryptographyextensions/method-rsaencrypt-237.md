# RsaEncrypt

[Back to CryptographyExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Core](../../index.md)

Source: [src/Core/CryptographyExtensions.cs:237](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Core/CryptographyExtensions.cs#L237)

Type: `KamiSama.Extensions.CryptographyExtensions`

Kind: `Method`

## Description

Encrypts data using an RSA public key represented as XML. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
#endregion
#region RSA
public static byte[] RsaEncrypt(this byte[] data, string xmlKey, RSAEncryptionPadding padding);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `data (extension receiver)` | `byte[]` | `-` | data to be encrypted |
| `xmlKey` | `string` | `-` | XML key used for encryption |
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

