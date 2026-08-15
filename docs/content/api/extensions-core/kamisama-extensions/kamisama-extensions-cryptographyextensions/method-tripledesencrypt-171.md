# TripleDesEncrypt

[Back to CryptographyExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Core](../../index.md)

Source: [src/Core/CryptographyExtensions.cs:171](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Core/CryptographyExtensions.cs#L171)

Type: `KamiSama.Extensions.CryptographyExtensions`

Kind: `Method`

## Description

Encrypts using Triple DES (3DES) algorithm. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
#endregion
#region TripleDES
public static byte[] TripleDesEncrypt(this byte[] data, byte[] key, byte[]? iv = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode padding = PaddingMode.Zeros);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `data (extension receiver)` | `byte[]` | `-` | data to be encrypted |
| `key` | `byte[]` | `-` | the encryption key |
| `iv` | `byte[]?` | `null` | initial value |
| `cipherMode` | `CipherMode` | `CipherMode.CBC` | Cipher mode, such as CBC, ECB, or CFB. |
| `padding` | `PaddingMode` | `PaddingMode.Zeros` | Padding mode, such as None, Zeros, or PKCS7. |

## Returns

| Type | Description |
| --- | --- |
| `byte[]` | Returns a `byte[]` value. |

## Example

```csharp
var data = "01020304050607080102030405060708090A".FromHex();
var key = "000102030405060708090A0B0C0D0E0F0102030405060708".FromHex();

data = data.Pad(len => len % 8 == 0);

var encrypted = data
.TripleDesEncrypt(key, padding: PaddingMode.Zeros, cipherMode: CipherMode.CBC);
var result = "8E86D9125D3E07413286D13A197DCDD2B17312AA9D593ABC".FromHex();


var decrypted = result
.TripleDesDecrypt(key, padding: PaddingMode.None);


var sign = data.TripleDesSign(key);
```

