# AesSign

[Back to CryptographyExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Core](../../index.md)

Source: [src/Core/CryptographyExtensions.cs:226](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Core/CryptographyExtensions.cs#L226)

Type: `KamiSama.Extensions.CryptographyExtensions`

Kind: `Method`

## Description

Computes an AES CBC-based message authentication value and returns the final encrypted block. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static byte[] AesSign(this byte[] data, byte[] key, byte[]? iv = null, PaddingMode padding = PaddingMode.Zeros);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `data (extension receiver)` | `byte[]` | `-` | the byte data to be signed |
| `key` | `byte[]` | `-` | the encryption key |
| `iv` | `byte[]?` | `null` | initial value |
| `padding` | `PaddingMode` | `PaddingMode.Zeros` | Padding mode, such as None, Zeros, or PKCS7. |

## Returns

| Type | Description |
| --- | --- |
| `byte[]` | Returns a `byte[]` value. |

## Example

```csharp
var data = "01020304050607080102030405060708090A".FromHex();
var key = "000102030405060708090A0B0C0D0E0F0102030405060708".FromHex();

data = data.Pad(len => len % 16 == 0);

var encrypted = data
.AesEncrypt(key, padding: PaddingMode.Zeros);

var result = "E30F86A64FD1BD77137E07DBE1E592583975CD440B3B29B608E9F56EFB779DA0".FromHex();


var decrypted = encrypted
.AesDecrypt(key, padding: PaddingMode.None);


var sign = data.AesSign(key);
```

